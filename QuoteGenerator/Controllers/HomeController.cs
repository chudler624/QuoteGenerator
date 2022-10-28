using Microsoft.AspNetCore.Mvc;
using QuoteGenerator.Models;
using QuoteGenerator.Services;
using System.Diagnostics;

namespace QuoteGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var quoteApi = new QuoteApi();
            var quoteModel = quoteApi.GetQuote();
            
            return View(quoteModel);
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