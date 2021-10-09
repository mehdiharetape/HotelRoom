using HotelProject.Application.Facade;
using HotelProject.EndPoint.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.EndPoint.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFacadePattern _facade;

        public HomeController(ILogger<HomeController> logger ,IFacadePattern facade)
        {
            _logger = logger;
            _facade = facade;
        }

        public IActionResult Index()
        {
            return View(_facade.GetRoomsForSiteService.GetRoomsForMainPage().Data);
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
