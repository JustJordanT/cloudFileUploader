using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace cfuWebUI.Controllers
{
    public class BlobActionsController : Controller
    {
        // private readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        // {
        //     PropertyNameCaseInsensitive = true,
        //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        // };

        private readonly HttpClient client;

        public BlobActionsController(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Stream> GetFilesAsync()
        {
            var responseMessage = await client.GetAsync("https://localhost:5002/api/blobFiles/Index");
            Stream content = await responseMessage.Content.ReadAsStreamAsync();
            return content;
            // return await JsonSerializer.DeserializeAsync<BlobActionsController[]>(stream, _options);

        }

    }
}