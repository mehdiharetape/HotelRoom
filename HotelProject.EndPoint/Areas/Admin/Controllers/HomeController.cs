using HotelProject.Application.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Operator")]
    public class HomeController : Controller
    {
        private readonly IFacadePattern _facade;
        public HomeController(IFacadePattern facade)
        {
            _facade = facade;
        }
        public IActionResult Index()
        {
            _facade.CheckFinishedReservation.CheckFinished();
            return View();
        }
    }
}
