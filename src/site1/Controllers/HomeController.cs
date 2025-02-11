using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using site1.Config;
using site1.Models;

namespace site1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BasePathConfig _basePathConfig;

        public HomeController(ILogger<HomeController> logger, BasePathConfig basePathConfig)
        {
            _logger = logger;
            _basePathConfig = basePathConfig;
        }

        public IActionResult Index()
        {
            var basePath = _basePathConfig.Path ?? "Path não definiodo";
            return View(model: basePath);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
