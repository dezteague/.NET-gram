using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet_gram.Models.Util
{
    public class Blob
    {
        public CloudStorageAccount CloudStorageAccount { get; set; }
        public CloudBlobClient CloudBlobClient { get; set; }

        public Blob(IConfiguration configuration)
        {
            CloudStorageAccount = CloudStorageAccount.Parse(configuration["ConnectionStrings:BlobConnectionString"]);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();
        }

        //get container
        /// <summary>
        /// Gets container
        /// </summary>
        /// <param name="containerName">name of container</param>
        /// <returns>cloud blob client</returns>
        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            CloudBlobContainer cbc = CloudBlobClient.GetContainerReference(containerName);
            await cbc.CreateIfNotExistsAsync();
            await cbc.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob});

            return cbc;
        }

        //get a blob
        /// <summary>
        /// Get a blob
        /// </summary>
        /// <param name="imageName">name of image</param>
        /// <param name="containerName">name of container</param>
        /// <returns>blob</returns>
        public async Task<CloudBlob> GetBlob(string imageName, string containerName)
        {
            //var container = CloudBlobClient.GetContainerReference(containerName);
            CloudBlobContainer container = await GetContainer(containerName);

            CloudBlob blob = container.GetBlockBlobReference(imageName);

            return blob;
        }

        //to upload a file, bring in container, name and path
        /// <summary>
        /// Upload a file
        /// </summary>
        /// <param name="cloudBlobContainer">name of container</param>
        /// <param name="fileName">name of file</param>
        /// <param name="filePath">path file</param>
        public void UploadFile(CloudBlobContainer cloudBlobContainer, string fileName, string filePath)
        {
            var blobFile = cloudBlobContainer.GetBlockBlobReference(fileName);
            blobFile.UploadFromFileAsync(filePath);
        }
    }
}
