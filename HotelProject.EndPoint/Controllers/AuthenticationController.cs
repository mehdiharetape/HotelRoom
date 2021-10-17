using HotelProject.Application.Facade;
using HotelProject.Application.Services.Users.Command.RegisterUser.IRegisterUserForAdmin;
using HotelProject.Common.Result;
using HotelProject.EndPoint.Models.ViewModels.AuthenticationViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HotelProject.EndPoint.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IFacadePattern _facade;
        public AuthenticationController(IFacadePattern facade)
        {
            _facade = facade;
        }
        //SignUp
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(SignUpViewModel request)
        {
            //validation
            CheckAll check = new CheckAll(request.Name, request.Mobile, request.Phone, request.Email,
                    request.Password, request.RePassword);
            if (!check.check())
            {
                return Json(new ResultDTO { IsSuccess = false, Message = check.message });
            }

            var signUpResult = _facade.RegisterUserForAdmin.RegisterUser(new RegisterUser_DTO
            {
                Name = request.Name,
                Email = request.Email,
                Mobile = request.Mobile,
                Phone = request.Phone,
                Password = request.Password,
                RePassword = request.RePassword,
                Roles = new List<UserRolesDTO>()
                {
                    new UserRolesDTO{Id = 2}
                }
            });

            //start login
            if(signUpResult.IsSuccess == true)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, signUpResult.Data.UserId.ToString()),
                    new Claim(ClaimTypes.Email, request.Email),
                    new Claim(ClaimTypes.Name, request.Name),
                    new Claim(ClaimTypes.Role, "User")
                };
                var Identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(Identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                HttpContext.SignInAsync(principal, properties);
            }
            return Json(signUpResult);
        }

        //Sign In
        [HttpGet]
        public IActionResult SignIn(string ReturnUrl="/")
        {
            ViewBag.url = ReturnUrl;
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(string email, string password, string url = "/")
        {
            var signInResult = _facade.LoginUserService.LoginUser(email, password);
            if(signInResult.IsSuccess == true)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, signInResult.Data.Id.ToString()),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, signInResult.Data.Roles),
                    new Claim(ClaimTypes.Name, signInResult.Data.Name)
                };
                var Identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(Identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5)
                };
                HttpContext.SignInAsync(principal, properties);
            }
            return Json(signInResult);
        }

        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
