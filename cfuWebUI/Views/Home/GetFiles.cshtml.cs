using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using cfuWebUI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace cfuWebUI.Views.Home
{
    public class GetFiles_Cshtml_Cs : PageModel
    {
        
        public Stream GetFiles { get; set; }

        
        public async Task OnGet([FromServices]BlobActionsController client)
        {
            GetFiles = await client.GetFilesAsync();
        }
    }
}