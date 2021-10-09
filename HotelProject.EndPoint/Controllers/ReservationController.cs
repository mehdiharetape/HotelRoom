using HotelProject.Application.Facade;
using HotelProject.Application.Services.Reservations.Command;
using HotelProject.EndPoint.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.EndPoint.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IFacadePattern _facade;
        public ReservationController(IFacadePattern facade)
        {
            _facade = facade;
        }
        public IActionResult Index()
        {
            return View();
        }

        //checking date of reservation
        [HttpGet]
        public IActionResult CheckReservationDate(long Id)
        {
            long? UserId = ClaimUtility.GetUserId(User);
            if (UserId == null)
            {
                return RedirectToAction("Index", "Error");
            }
            else
            {
                ViewBag.Id = Id;
                return View();
            }
        }
        [HttpPost]
        public IActionResult CheckReservationDate(long Id, DateTime startTime, DateTime endTime)
        {
            return Json(_facade.ReserveForUserService.CheckReservation(Id, startTime, endTime));
        }

        //do reservation
        [HttpGet]
        public IActionResult GetInfo(long Id, DateTime startTime, DateTime endTime)
        {
            ViewBag.StartTime = startTime;
            ViewBag.EndTime = endTime;
            long? UserId = ClaimUtility.GetUserId(User);
            return View(_facade.GetUserInfo.GetDetails(UserId, Id).Data);
        }
        [HttpPost]
        public IActionResult GetInfo(RequestforReserve_DTO request, List<WithPersonsDTO> withPersons)
        {
            List<WithPersonsDTO> withs = new List<WithPersonsDTO>();
            foreach(var i in withPersons)
            {
                withs.Add(new WithPersonsDTO
                {
                    Name = i.Name,
                    Phone = i.Phone,
                });
            }
            return Json(_facade.ReserveForUserService.ReserveForUser(new RequestforReserve_DTO 
            { 
                UserId = request.UserId,
                RoomId = request.RoomId,
                UserName = request.UserName,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                Mobile = request.Mobile,
                UserPhone = request.UserPhone,
                Address = request.Address,
                WithPersonsCount = request.WithPersonsCount,
                WithPersons = withs,
            }));
        }
    }
}
