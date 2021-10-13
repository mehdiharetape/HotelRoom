using HotelProject.Application.Facade;
using HotelProject.Application.Services.Users.Command.EditUser;
using HotelProject.EndPoint.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.EndPoint.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IFacadePattern _facade;
        public ProfileController(IFacadePattern facade)
        {
            _facade = facade;
        }

        public IActionResult Index()
        {
            long? UserId = ClaimUtility.GetUserId(User);
            _facade.CheckFinishedReservation.CheckFinshedForUser(UserId);
            return View(_facade.GetReservsForUser.GetReservs(UserId).Data);
        }

        [HttpPost]
        public IActionResult CancelReserve(long Id)
        {
            return Json(_facade.CancelReservationService.Cancel(Id));
        }

        //Edit User
        [HttpGet]
        public IActionResult EditUser()
        {
            long? UserId = ClaimUtility.GetUserId(User);
            return View(_facade.EditUserForUser.GetUserInfo(UserId).Data);
        }
        [HttpPost]
        public IActionResult EditUser(ResultUserDTO request)
        {
            return Json(_facade.EditUserForUser.EditUser(new ResultUserDTO
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
                Mobile = request.Mobile,
                Phone = request.Phone
            }));
        }
    }
}
