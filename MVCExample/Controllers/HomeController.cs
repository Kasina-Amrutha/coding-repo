using CoreRazorApps.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MVCExample.Models;
using System.Diagnostics;

namespace MVCExample.Controllers
{

  
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMongoDatabase _database;

        public HomeController(ILogger<HomeController> logger, IMongoDatabase database)
        {
            _logger = logger;
            _database= database;
        }

       

        public IActionResult Index()
        {
            var orgList = _database.GetCollection<Organization>("cart");
            return View();
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
