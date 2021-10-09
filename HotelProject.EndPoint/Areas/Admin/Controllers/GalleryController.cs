using HotelProject.Application.Facade;
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
    public class GalleryController : Controller
    {
        private readonly IFacadePattern _facade;
        public GalleryController(IFacadePattern facade)
        {
            _facade = facade;
        }
        public IActionResult Index(int pageid=1)
        {
            int skip = (pageid - 1) * 7;
            ViewBag.PageCount = _facade.GetGalleryImageService.GetGalleryCount() / 7;
            ViewBag.PageId = pageid;
            return View(_facade.GetGalleryImageService.GetGallery(skip, 7).Data);
        }

        //Add New Image
        [HttpGet]
        public IActionResult AddNewImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewImage(IFormFile image, bool Show)
        {
            image = Request.Form.Files[0];
            return Json(_facade.AddGalleryImageService.AddImage(image, Show));
        }

        //Remove Image
        [HttpPost]
        public IActionResult RemoveImage(long Id)
        {
            return Json(_facade.RemoveGalleryImageService.RemoveImage(Id));
        }

        //Edit Display
        [HttpPost]
        public IActionResult EditImage(long Id, bool show)
        {
            return Json(_facade.EditDisplayImageService.EditDisplay(Id, show));
        }
    }
}
