using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.wwwroot.Business.Interface;
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
using Microsoft.Extensions.Configuration;

namespace Difi.Sjalvdeklaration.wwwroot.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class AzureHandlerModel : PageModel
    {
        private readonly IErrorHandler errorHandler;
        private readonly IConfiguration configuration;
        private readonly IApiHttpClient apiHttpClient;
        private static readonly List<string> AllowedCorsOrigins = new List<string> { "https://localhost:44343", "https://sjalvdeklaration-test.azurewebsites.net", "https://egenkontroll-test.azurewebsites.net" };
        private static readonly List<string> AllowedCorsHeaders = new List<string> { "x-ms-meta-qqfilename", "Content-Type", "x-ms-blob-type", "x-ms-blob-content-type" };
        private const CorsHttpMethods AllowedCorsMethods = CorsHttpMethods.Delete | CorsHttpMethods.Put;
        private const int AllowedCorsAgeDays = 5;

        public AzureHandlerModel(IApiHttpClient apiHttpClient, IErrorHandler errorHandler, IConfiguration configuration)
        {
            this.apiHttpClient = apiHttpClient;
            this.errorHandler = errorHandler;
            this.configuration = configuration;
        }

        public void OnGet()
        {
            var accountAndKey = new StorageCredentials(configuration["Azure:StorageAccountName"], configuration["Azure:StorageAccountKey"]);
            var blobUri = Request.Query["bloburi"];
            var method = Request.Query["_method"];

            ConfigureCors(new CloudStorageAccount(accountAndKey, true));

            var sas = GetSasForBlob(accountAndKey, blobUri, method);
            var buffer = Encoding.UTF8.GetBytes(sas);

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

            var apiResult = apiHttpClient.Post<ApiResult>("/api/Image/Add", imageItem).Result;

            if (apiResult.Succeeded)
            {
                var buffer = Encoding.UTF8.GetBytes("{\"success\":true, \"id\":\"" + apiResult.Id + "\"}");

                Response.ContentType = "application/json; charset=utf-8";
                Response.StatusCode = 200;
                Response.ContentLength = buffer.Length;
                Response.Body.WriteAsync(buffer);
            }
            else
            {
                var buffer = Encoding.UTF8.GetBytes("{\"success\":false}");

                Response.ContentType = "application/json; charset=utf-8";
                Response.StatusCode = 500;
                Response.ContentLength = buffer.Length;
                Response.Body.WriteAsync(buffer);
            }

            return null;
        }

        private static string GetSasForBlob(StorageCredentials credentials, String blobUri, String verb)
        {
            var blob = new CloudBlockBlob(new Uri(blobUri), credentials);
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

            var newProperties = CurrentProperties(blobClient);
            newProperties.DefaultServiceVersion = "2013-08-15";
            blobClient.SetServicePropertiesAsync(newProperties);
            const bool addRule = true;

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

            if (currentProperties?.Cors == null)
            {
                return currentProperties;
            }

            for (var index = 0; index < currentProperties.Cors.CorsRules.Count; index++)
            {
                var corsRule = currentProperties.Cors.CorsRules[index];
            }

            return currentProperties;
        }
    }
}