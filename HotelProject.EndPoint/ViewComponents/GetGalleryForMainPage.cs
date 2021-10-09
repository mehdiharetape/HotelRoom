using HotelProject.Application.Facade;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.EndPoint.ViewComponents
{
    public class GetGalleryForMainPage : ViewComponent
    {
        private readonly IFacadePattern _facade;
        public GetGalleryForMainPage(IFacadePattern facade)
        {
            _facade = facade;
        }
        public IViewComponentResult Invoke()
        {
            // 0 => get 4 images ----- 1 => get all images
            return View(viewName: "GetGalleryForMainPage", _facade.GetGalleryForMainPage.GetGallery(0).Data);
        }
    }
}
