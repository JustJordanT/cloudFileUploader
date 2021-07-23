using System;
using System.IO;
using System.Threading.Tasks;
using cloudFileUploader.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//TODO need to find our why the rest of the methods are not working and need to have some unit tests as well.
namespace cfuAPI.Controllers
{
    // [Route("api/[controller]")]
    // [ApiController]
    public class blobFilesController : Controller
    {
        private readonly IBlobService _blobService;

        public blobFilesController(IBlobService blobService)
        {
            _blobService = blobService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var files = await _blobService.AllBlobs("images");
            return Ok(files);
        }

        [HttpGet]
        public IActionResult AddFile()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile file)
        {
            if(file == null || file.Length < 1) return Ok();

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            var res = await _blobService.UploadBlob(fileName, file, "images");

            if (res)
                return RedirectToAction("Index");
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ViewFile(string name)
        {
            var res = await _blobService.GetBlob(name, "images");
            return Redirect(res);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string name)
        {
            await _blobService.DeleteBlob(name, "images");
            return RedirectToAction("Index");
        }
    }
}