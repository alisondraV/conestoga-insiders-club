using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace ConestogaInsidersClub.Pages.Shared
{
    public class DownloadModel : PageModel
    {
        public IActionResult OnGet(string name)
        {
            var content = "Hello";
            var bytes = Encoding.ASCII.GetBytes(content);
            return File(bytes, "application/octet-stream", name);
        }
    }
}
