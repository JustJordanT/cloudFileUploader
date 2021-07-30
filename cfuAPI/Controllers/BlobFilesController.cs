using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using cfuAPI.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;

//TODO need to find our why the rest of the methods are not working and need to have some unit tests as well.
namespace cfuAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    // [ApiController]
    // [Route("[controller]")]
    public class blobFilesController : ControllerBase
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
        public async Task<IActionResult> ViewFile(string name)
        {
            var res = await _blobService.GetBlob(name, "images");
            return Redirect(res);
        }

        // [HttpGet]
        // public IActionResult AddFile()
        // {
        //     return Ok();
        // }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile file, string name)
        {

            if(file == null || file.Length < 1) return Ok();

            // var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var fileName = name + Path.GetExtension(file.FileName);

            var res = await _blobService.UploadBlob(fileName, file, "images");

            if (res)
                return RedirectToAction("Index");
            return Ok(); 
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string name)
        {
            await _blobService.DeleteBlob(name, "images");
            return RedirectToAction("Index");
        }
    }
}