using HotelProject.Application.Facade;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.EndPoint.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IFacadePattern _facade;
        public GalleryController(IFacadePattern facade)
        {
            _facade = facade;
        }
        public IActionResult Index()
        {
            // 0 => get 4 images ----- 1 => get all images
            return View(_facade.GetGalleryForMainPage.GetGallery(1).Data);
        }
    }
}
