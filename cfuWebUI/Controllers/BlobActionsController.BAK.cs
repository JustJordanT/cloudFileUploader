using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace cfuWebUI.Controllers
{
    public class BlobActionsController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public BlobActionsController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        
        // GET  --- https://www.tutorialsteacher.com/webapi/consuming-web-api-in-dotnet-using-httpclient
        // https://www.youtube.com/watch?v=B_4X3ltGCbY
        [HttpGet]
        // public IActionResult ViewFiles()
        public async Task<HttpContent> ViewFiles()
        {
            var request  = new HttpRequestMessage(HttpMethod.Get, "api/blobFiles/Index");

            var client   = _clientFactory.CreateClient("ViewFiles");

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Content;
            }
            // using Stream responseStream = await response.Content.ReadAsStreamAsync();
            return null;
        }
    }
}