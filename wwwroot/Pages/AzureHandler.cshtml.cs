using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;

namespace Difi.Sjalvdeklaration.wwwroot.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class AzureHandlerModel : PageModel
    {
        private readonly IApiHttpClient apiHttpClient;
        private const string StorageAccountName = "difiimagetest";
        private const string StorageAccountKey = "U60XxOSSbywQSAqlSZfRuj6C/4KOVaMnjRWvltkGr6W1GjYmdUR9Z/8UtnQoObs65QPDi5VG4Z8lJXPJs9Ar7A==";
        private static readonly List<String> AllowedCorsOrigins = new List<String> { "https://localhost:44343" };
        private static readonly List<String> AllowedCorsHeaders = new List<String> { "x-ms-meta-qqfilename", "Content-Type", "x-ms-blob-type", "x-ms-blob-content-type" };
        private const CorsHttpMethods AllowedCorsMethods = CorsHttpMethods.Delete | CorsHttpMethods.Put;
        private const int AllowedCorsAgeDays = 5;

        public AzureHandlerModel(IApiHttpClient apiHttpClient)
        {
            this.apiHttpClient = apiHttpClient;
        }

        public void OnGet()
        {
            var accountAndKey = new StorageCredentials(StorageAccountName, StorageAccountKey);
            var blobUri = Request.Query["bloburi"];
            var method = Request.Query["_method"];
            var qqtimestamp = Request.Query["qqtimestamp"];

            ConfigureCors(new CloudStorageAccount(accountAndKey, true));

            var sas = GetSasForBlob(accountAndKey, blobUri, method);

            byte[] buffer = Encoding.UTF8.GetBytes(sas);

            Response.ContentLength = buffer.Length;
            Response.Body.WriteAsync(buffer);
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult OnPost()
        {
            var imageItem = new ImageItem
            {
                Blob = Request.Form["blob"],
                Uuid = Request.Form["uuid"],
                Name = Request.Form["name"],
                Container = Request.Form["container"]
            };

            var item = apiHttpClient.Post<ApiResult>("/api/Image/Add", imageItem);

            Response.StatusCode = 200;
            Response.Body.Close();

            return null;
        }

        private static String GetSasForBlob(StorageCredentials credentials, String blobUri, String verb)
        {
            CloudBlockBlob blob = new CloudBlockBlob(new Uri(blobUri), credentials);
            var permission = SharedAccessBlobPermissions.Write;

            if (verb == "DELETE")
            {
                permission = SharedAccessBlobPermissions.Delete;
            }

            var sas = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy()
            {
                Permissions = permission,
                SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(15),
            });

            return string.Format(CultureInfo.InvariantCulture, "{0}{1}", blob.Uri, sas);
        }

        private static void ConfigureCors(CloudStorageAccount storageAccount)
        {
            var blobClient = storageAccount.CreateCloudBlobClient();

            Console.WriteLine("Storage Account: " + storageAccount.BlobEndpoint);
            var newProperties = CurrentProperties(blobClient);
            newProperties.DefaultServiceVersion = "2013-08-15";
            blobClient.SetServicePropertiesAsync(newProperties);
            var addRule = true;

            if (addRule)
            {
                var ruleWideOpenWriter = new CorsRule()
                {
                    AllowedHeaders = AllowedCorsHeaders,
                    AllowedOrigins = AllowedCorsOrigins,
                    AllowedMethods = AllowedCorsMethods,
                    MaxAgeInSeconds = (int)TimeSpan.FromDays(AllowedCorsAgeDays).TotalSeconds
                };

                newProperties.Cors.CorsRules.Clear();
                newProperties.Cors.CorsRules.Add(ruleWideOpenWriter);
                blobClient.SetServicePropertiesAsync(newProperties);
                Console.WriteLine("New Properties:");
                CurrentProperties(blobClient);
            }
        }

        private static ServiceProperties CurrentProperties(CloudBlobClient blobClient)
        {
            var currentProperties = blobClient.GetServicePropertiesAsync().Result;

            if (currentProperties != null)
            {
                if (currentProperties.Cors != null)
                {
                    for (int index = 0; index < currentProperties.Cors.CorsRules.Count; index++)
                    {
                        var corsRule = currentProperties.Cors.CorsRules[index];
                    }
                }
            }

            return currentProperties;
        }
    }
}