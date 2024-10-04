using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PLUpload.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PLUpload.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _context;
        public HomeController(IHttpContextAccessor context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public void FileUpload([FromForm] string fileMetadata)
        {
            var fileMeta = string.IsNullOrEmpty(fileMetadata) ? new FileMetadata() : JsonConvert.DeserializeObject<FileMetadata>(fileMetadata);

            if (_context.HttpContext.Request.Form.Files.Count < 1)
            {
                throw new ArgumentException("No file input");
            }

            var files = _context.HttpContext.Request.Form.Files;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
