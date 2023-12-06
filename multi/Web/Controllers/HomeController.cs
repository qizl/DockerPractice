using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Utils;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AddressHelper _addressHelper;

        public HomeController(AddressHelper addressHelper)
        {
            _addressHelper = addressHelper;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Address = this._addressHelper.GetLocalAddress();

            var http = new HttpClient();
            ViewBag.API1Address = await http.GetStringAsync("http://api1/api/test/ServerAddress");
            ViewBag.API1Files = await http.GetStringAsync("http://api1/api/test/ServerFiles");
            ViewBag.API2Address = await http.GetStringAsync("http://api2/api/test/ServerAddress");
            ViewBag.API2Files = await http.GetStringAsync("http://api2/api/test/ServerFiles");

            return View();
        }

        public async Task<IActionResult> API()
        {
            var http = new HttpClient();
            ViewBag.API1Address = await http.GetStringAsync("http://api1/api/test/ServerAddress");
            ViewBag.API1Files = await http.GetStringAsync("http://api1/api/test/ServerFiles");
            ViewBag.API2Address = await http.GetStringAsync("http://api2/api/test/ServerAddress");
            ViewBag.API2Files = await http.GetStringAsync("http://api2/api/test/ServerFiles");

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
