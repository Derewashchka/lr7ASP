using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace lr7.Controllers
{
    public class FileController : Controller
    {
        [HttpGet("File/DownloadFile")]
        public IActionResult DownloadFileForm()
        {
            return View("DownloadFileForm");
        }

        [HttpPost("File/DownloadFile")]
        public IActionResult GenerateFile(string firstName, string lastName, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                fileName = "DefaultFileName";
            }

            var fileContent = $"{firstName} {lastName}";
            var byteArray = Encoding.UTF8.GetBytes(fileContent);
            var file = new FileContentResult(byteArray, "text/plain")
            {
                FileDownloadName = $"{fileName}.txt"
            };
            return file;
        }
    }
}
