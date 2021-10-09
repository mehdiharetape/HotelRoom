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
    public class CommentController : Controller
    {
        private readonly IFacadePattern _facade;
        public CommentController(IFacadePattern facade)
        {
            _facade = facade;
        }
        public IActionResult Index(string SearchKey, int pageid=1)
        {
            int skip = (pageid - 1) * 5;
            ViewBag.PageCount = _facade.GetCommentsForAdminService.GetCommentscount() / 5;
            ViewBag.PageId = pageid;
            return View(_facade.GetCommentsForAdminService.GetComments(SearchKey, skip, 5).Data);
        }

        [HttpPost]
        public IActionResult DeleteComment(long Id)
        {
            return Json(_facade.DeleteCommentService.DeleteComment(Id));
        }
    }
}
