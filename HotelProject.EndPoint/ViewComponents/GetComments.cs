using HotelProject.Application.Facade;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.EndPoint.ViewComponents
{
    public class GetComments : ViewComponent
    {
        private readonly IFacadePattern _facade;
        public GetComments(IFacadePattern facade)
        {
            _facade = facade;
        }
        public IViewComponentResult Invoke(long Id)
        {
            var comment = _facade.GetCommentService.GetComment(Id);
            return View(viewName: "GetComments", comment.Data);
        }
    }
}
