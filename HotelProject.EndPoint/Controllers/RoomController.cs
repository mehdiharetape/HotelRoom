using HotelProject.Application.Facade;
using HotelProject.Application.Services.Comments.Command;
using HotelProject.Application.Services.Rooms.Query.GetRoomsForSite;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.EndPoint.Controllers
{
    public class RoomController : Controller
    {
        private readonly IFacadePattern _facade;
        public RoomController(IFacadePattern facade)
        {
            _facade = facade;
        }
        public IActionResult Index(long Id)
        {
            return View(_facade.GetRoomDetailService.GetRoomDetails(Id).Data);
        }

        public IActionResult Rooms(Ordering ordering)
        {
            return View(_facade.GetRoomsForSiteService.GetRoomsForRoomPage(ordering).Data);
        }

        public IActionResult PriceLimit(long? minPrice = 0, long? maxPrice = 0)
        {
            return View(_facade.GetRoomsForSiteService.PriceLimit(minPrice, maxPrice).Data);
        }

        public IActionResult AddNewComment(ReqestAddCommentDTO reqest)
        {
            var result = _facade.AddNewCommentService.AddComment(new ReqestAddCommentDTO
            {
                Id = reqest.Id,
                CommentTxt = reqest.CommentTxt,
                Email = reqest.Email,
                Name = reqest.Name
            });
            return Json(result);
        }
    }
}
