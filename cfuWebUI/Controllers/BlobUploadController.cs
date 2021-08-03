using System;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace cfuWebUI.Controllers
{
    public class BlobUploadController : Controller
    {
        // GET: BlobUpload
        public async Task<ActionResult> ListBlobs()
        {
            var apiURL = "https://localhost:5001/api/blobFiles/Index";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var reponse = await client.GetAsync(apiURL);
                if (reponse.IsSuccessStatusCode)
                {
                    var data = await reponse.Content.ReadAsStringAsync();
                    // var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    var table = JsonConvert.DeserializeObject<DataTable>(data);
                }
            }

            return View();
        }

        // // GET: BlobUpload/Details/5
        // public ActionResult Details(int id)
        // {
        //     return View();
        // }
        //
        // // GET: BlobUpload/Create
        // public ActionResult Create()
        // {
        //     return View();
        // }
        //
        // // POST: BlobUpload/Create
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Create(IFormCollection collection)
        // {
        //     try
        //     {
        //         // TODO: Add insert logic here
        //
        //         return RedirectToAction(nameof(Index));
        //     }
        //     catch
        //     {
        //         return View();
        //     }
        // }
        //
        // // GET: BlobUpload/Edit/5
        // public ActionResult Edit(int id)
        // {
        //     return View();
        // }
        //
        // // POST: BlobUpload/Edit/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Edit(int id, IFormCollection collection)
        // {
        //     try
        //     {
        //         // TODO: Add update logic here
        //
        //         return RedirectToAction(nameof(Index));
        //     }
        //     catch
        //     {
        //         return View();
        //     }
        // }
        //
        // // GET: BlobUpload/Delete/5
        // public ActionResult Delete(int id)
        // {
        //     return View();
        // }
        //
        // // POST: BlobUpload/Delete/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Delete(int id, IFormCollection collection)
        // {
        //     try
        //     {
        //         // TODO: Add delete logic here
        //
        //         return RedirectToAction(nameof(Index));
        //     }
        //     catch
        //     {
        //         return View();
        //     }
    }
}