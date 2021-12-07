using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebExplorer.Services;

namespace WebExplorer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceProvider _provider;
        private readonly FileSystemService _fileSystemService;

        public HomeController(IServiceProvider provider, FileSystemService fileSystemService)
        {
            _provider = provider;
            _fileSystemService = fileSystemService;
        }

        [HttpGet("{*path}")]
        public ActionResult Index(string path = "")
        {
            path = HttpContext.Request.Path;

            if (System.IO.File.Exists(path))
                return File(System.IO.File.ReadAllBytes(path), "application/octet-stream");
            
            ViewBag.Title = $"Index of {path}";
            ViewBag.Files = _fileSystemService.ListDirectory(WebUtility.UrlDecode(path));
            return View();
        }
    }
}