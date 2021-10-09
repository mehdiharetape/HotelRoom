using HotelProject.Application.Facade;
using HotelProject.Application.Services.Rooms.Command.AddNewRoom;
using HotelProject.Application.Services.Rooms.Command.EditRoom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.EndPoint.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RoomController : Controller
    {
        private readonly IFacadePattern _facade;
        public RoomController(IFacadePattern facade)
        {
            _facade = facade;
        }

        public IActionResult Index(string SearchKey, int pageid=1)
        {
            int skip = (pageid - 1) * 8;
            ViewBag.PageCount = _facade.GetRoomsListService.GetRoomscount() / 8;
            ViewBag.PageId = pageid;
            return View(_facade.GetRoomsListService.RoomsList(SearchKey, skip, 8).Data);
        }

        //Create Room
        [HttpGet]
        public IActionResult CreateRoom()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRoom(AddNewRoom_DTO request, IFormFile Image)
        {
            Image = Request.Form.Files[0];
            request.Image = Image;
            return Json(_facade.AddRoomService.AddRoom(request));
        }

        //Edit
        [HttpPost]
        public IActionResult EditRooms(IFormFile Image, RequestEditRoom_DTO request)
        {
            if(Image != null)
            {
                Image = Request.Form.Files[0];
                request.ImageFile = Image;
            }
            return Json(_facade.EditRoomService.EditRoom(request));
        }

        //Delete
        [HttpPost]
        public IActionResult DeleteRooms(long Id)
        {
            return Json(_facade.DeleteRoomService.Delete(Id));
        }
    }
}
