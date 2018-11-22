using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace Difi.Sjalvdeklaration.wwwroot
{
    public class FineUploaderAzureServer
    {
        private const string StorageAccountName = "difiimagetest.blob.core.windows.net";
        private const string StorageAccountKey = "U60XxOSSbywQSAqlSZfRuj6C/4KOVaMnjRWvltkGr6W1GjYmdUR9Z/8UtnQoObs65QPDi5VG4Z8lJXPJs9Ar7A==";
        private static readonly List<String> AllowedCorsOrigins = new List<String> { "https://localhost:44343" };
        private static readonly List<String> AllowedCorsHeaders = new List<String> { "x-ms-meta-qqfilename", "Content-Type", "x-ms-blob-type", "x-ms-blob-content-type" };
        private const CorsHttpMethods AllowedCorsMethods = CorsHttpMethods.Delete | CorsHttpMethods.Put;
        private const int AllowedCorsAgeDays = 5;
        private const string SignatureServerEndpointAddress = "http://*:8080/sas/";
        private const string UploadSuccessEndpointAddress = "http://*:8080/success/";

        public FineUploaderAzureServer()
        {
            var accountAndKey = new StorageCredentials(StorageAccountName, StorageAccountKey);

            var storageAccount = new CloudStorageAccount(accountAndKey, true);

            ConfigureCors(storageAccount);

            StartServer(accountAndKey);
        }

        private static void StartServer(StorageCredentials accountAndKey)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(SignatureServerEndpointAddress);
            listener.Prefixes.Add(UploadSuccessEndpointAddress);
            listener.Start();

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                if (request.HttpMethod == "GET")
                {
                    var blobUri = request.QueryString.Get("bloburi");
                    var verb = request.QueryString.Get("_method");
                    var sas = GetSasForBlob(accountAndKey, blobUri, verb);
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(sas);
                    response.ContentLength64 = buffer.Length;
                    System.IO.Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();
                }
                else if (request.HttpMethod == "POST")
                {
                    response.StatusCode = 200;
                    // TODO insert uploadSuccess handling logic here
                    response.Close();
                }
                else
                {
                    response.StatusCode = 405;
                }
            }
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
                Console.ReadLine();
            }
        }

        private static ServiceProperties CurrentProperties(CloudBlobClient blobClient)
        {
            var currentProperties = blobClient.GetServicePropertiesAsync().Result;

            if (currentProperties != null)
            {
                if (currentProperties.Cors != null)
                {
                    Console.WriteLine("Cors.CorsRules.Count          : " + currentProperties.Cors.CorsRules.Count);
                    for (int index = 0; index < currentProperties.Cors.CorsRules.Count; index++)
                    {
                        var corsRule = currentProperties.Cors.CorsRules[index];
                        Console.WriteLine("corsRule[index]              : " + index);
                        foreach (var allowedHeader in corsRule.AllowedHeaders)
                        {
                            Console.WriteLine("corsRule.AllowedHeaders      : " + allowedHeader);
                        }

                        Console.WriteLine("corsRule.AllowedMethods      : " + corsRule.AllowedMethods);

                        foreach (var allowedOrigins in corsRule.AllowedOrigins)
                        {
                            Console.WriteLine("corsRule.AllowedOrigins      : " + allowedOrigins);
                        }

                        foreach (var exposedHeaders in corsRule.ExposedHeaders)
                        {
                            Console.WriteLine("corsRule.ExposedHeaders      : " + exposedHeaders);
                        }

                        Console.WriteLine("corsRule.MaxAgeInSeconds     : " + corsRule.MaxAgeInSeconds);
                    }
                }

                Console.WriteLine("DefaultServiceVersion         : " + currentProperties.DefaultServiceVersion);
                Console.WriteLine("HourMetrics.MetricsLevel      : " + currentProperties.HourMetrics.MetricsLevel);
                Console.WriteLine("HourMetrics.RetentionDays     : " + currentProperties.HourMetrics.RetentionDays);
                Console.WriteLine("HourMetrics.Version           : " + currentProperties.HourMetrics.Version);
                Console.WriteLine("Logging.LoggingOperations     : " + currentProperties.Logging.LoggingOperations);
                Console.WriteLine("Logging.RetentionDays         : " + currentProperties.Logging.RetentionDays);
                Console.WriteLine("Logging.Version               : " + currentProperties.Logging.Version);
                Console.WriteLine("MinuteMetrics.MetricsLevel    : " + currentProperties.MinuteMetrics.MetricsLevel);
                Console.WriteLine("MinuteMetrics.RetentionDays   : " + currentProperties.MinuteMetrics.RetentionDays);
                Console.WriteLine("MinuteMetrics.Version         : " + currentProperties.MinuteMetrics.Version);
            }

            return currentProperties;
        }
    }
}