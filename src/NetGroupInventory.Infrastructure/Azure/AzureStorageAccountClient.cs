using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using NetGroupInventory.Application.Interfaces.Clients;

namespace NetGroupInventory.Infrastructure.Azure
{
    public class AzureStorageAccountClient : IFileStorageClient
    {
        readonly BlobServiceClient blobServiceClient;
        
        public AzureStorageAccountClient(IConfiguration configuration)
        {
            blobServiceClient = new BlobServiceClient(configuration["AzureStorageConnection"]);
        }

        public async Task<string> Upload(string fileName, string container, Stream fileStream)
        {
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(container);
            await containerClient.CreateIfNotExistsAsync();

            containerClient.SetAccessPolicy(PublicAccessType.Blob);

            BlobClient blobClient;


            blobClient = containerClient.GetBlobClient(fileName);

            await blobClient.UploadAsync(fileStream);

            return blobClient.Uri.ToString();
        }

        public async Task Delete(string container, string fileName)
        {
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(container);
            await containerClient.CreateIfNotExistsAsync();

            containerClient.SetAccessPolicy(PublicAccessType.Blob);

            BlobClient blobClient;

            blobClient = containerClient.GetBlobClient(fileName);

            await blobClient.DeleteIfExistsAsync();
        }
    }
}
