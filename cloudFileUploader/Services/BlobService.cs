using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;

namespace cloudFileUploader.Services
{
    public class blobService : IBlobService
    {
        private readonly BlobServiceClient _blobClient;

        public blobService(BlobServiceClient blobClient)
        {
            _blobClient = blobClient;
        }


        public async Task<string> GetBlob(string name, string containerName)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<string>> AllBlobs(string containerName)
        {
            //Allow us to access the data inside the container.
            var containerClient = _blobClient.GetBlobContainerClient(containerName);
            
            //Create a new list of strings
            var files = new List<string>();
            
            //Get the Blobs in the container
            var blobs = containerClient.GetBlobsAsync();
            
            //Iterate through the each item in Blobs and return it back to the user. 
            await foreach (var item in blobs)
            {
                files.Add(item.Name);
            }

            return files;
        }

        public Task<bool> UploadBlob(string name, IFormFile file, string containerName)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteBlob(string name, string containerName)
        {
            throw new System.NotImplementedException();
        }
    }
}