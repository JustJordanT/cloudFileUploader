using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using cloudFileUploader.Services;
using Microsoft.AspNetCore.Http;

namespace cfuAPI.Services
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
            //Allow us to access the data inside the container.
            var containerClient = _blobClient.GetBlobContainerClient(containerName);
            
            //Get access to a certain file, inside the container, ie (FILENAME).
            var blobClient = containerClient.GetBlobClient(name);

            return blobClient.Uri.AbsoluteUri;
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

        public async Task<bool> UploadBlob(string name, IFormFile file, string containerName)
        {
            //Allow us to access the data inside the container.
            var containerClient = _blobClient.GetBlobContainerClient(containerName);
            
            //Checking if file exists, if not a temp space untill it is uploaded.
            var blobClient = containerClient.GetBlobClient(name);

            var httpHeaders = new BlobHttpHeaders()
            {
                ContentType = file.ContentType
            };

            var res = await blobClient.UploadAsync(file.OpenReadStream(), httpHeaders);

            if (res is not null)
                    return true;
            return false;
        }

        public async Task<bool> DeleteBlob(string name, string containerName)
        {
            //Allow us to access the data inside the container.
            var containerClient = _blobClient.GetBlobContainerClient(containerName);
            
            //Get access to a certain file, inside the container, ie (FILENAME).
            var blobClient = containerClient.GetBlobClient(name);
            
            //if the file exists the file wi;; be deleted.
            return await containerClient.DeleteIfExistsAsync();
        }
    }
}