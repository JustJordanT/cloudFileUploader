using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace cloudFileUploader.Services
{
    public class BlobService : IBlobService
    {
        public Task<string> GetBlob(string name, string containerName)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<string>> AllBlobs(string containerName)
        {
            throw new System.NotImplementedException();
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