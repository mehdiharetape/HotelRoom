using HotelProject.Application.Facade;
using HotelProject.Application.IDataBase_Context;
using HotelProject.Application.Services.Users.Command.EditUser;
using HotelProject.Application.Services.Users.Command.RegisterUser.IRegisterUserForAdmin;
using HotelProject.Domain.Entities.Users;
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
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IFacadePattern _facade;
        public UserController(IFacadePattern facade)
        {
            _facade = facade;
        }

        public IActionResult Index(string SearchKey, int pageid=1)
        {
            int skip = (pageid - 1) * 8;
            ViewBag.PageCount = _facade.GetUsersListService.GetUsersCount() / 8;
            ViewBag.PageId = pageid;
            return View(_facade.GetUsersListService.GetUsersList(SearchKey, skip, 8).Data);
        }

        //create user
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_facade.GetRolesServices.GetRoles().Data, "Id", "Name"); 
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Name, string Mobile, string Phone, string Email, string Password,
            string RePassword, long RoleId)
        {
            var user = _facade.RegisterUserForAdmin.RegisterUser(new RegisterUser_DTO
            {
                Name = Name,
                Mobile = Mobile,
                Phone = Phone,
                Email = Email,
                Password = Password,
                RePassword = RePassword,
                Roles = new List<UserRolesDTO>
                {
                    new UserRolesDTO
                    {
                        Id = RoleId
                    }
                }
            });
            return Json(user);
        }

        //Edit User
        [HttpGet]
        public IActionResult EditUser(long Id, string Name, string Mobile, string Phone, string Email)
        {
            ViewBag.Id = Id;
            ViewBag.Name = Name;
            ViewBag.Mobile = Mobile;
            ViewBag.Phone = Phone;
            ViewBag.Email = Email;
            ViewBag.Roles = new SelectList(_facade.GetRolesServices.GetRoles().Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult EditUser(long Id,string Name, string Mobile, string Phone, string Email, long RoleId)
        {
            return Json(_facade.EditUserService.EditUser(new EditUsersDTO 
            {
                Id = Id,
                Name = Name,
                Mobile = Mobile,
                Phone = Phone, 
                Email = Email,
                RoleId = RoleId
            }));
        }

        //Remove User
        [HttpPost]
        public IActionResult DeleteUser(long Id)
        {
            return Json(_facade.DeleteUserService.Delete(Id));
        }

    }
}
