using HotelProject.Application.Facade;
using HotelProject.Application.Services.Reservations.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Operator")]
    public class ReservationController : Controller
    {
        private readonly IFacadePattern _facade;
        public ReservationController(IFacadePattern facade)
        {
            _facade = facade;
        }
        public IActionResult Index(Filter filter,string SearchKey, int pageid = 1)
        {
            int skip = (pageid - 1) * 8;
            ViewBag.PageCount = _facade.GetReservesForAdmin.GetReservsCount() / 8;
            ViewBag.PageId = pageid;
            return View(_facade.GetReservesForAdmin.GetReserves(SearchKey, skip, 8, filter).Data);
        }

        [HttpPost]
        public IActionResult CancelReserve(long Id)
        {
            return Json(_facade.CancelReservationService.Cancel(Id));
        }
    }
}
