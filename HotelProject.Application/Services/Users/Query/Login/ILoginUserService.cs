using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Users.Query.Login
{
    public interface ILoginUserService
    {
        ResultDTO<LoginResultDTO> LoginUser(string email, string password);
    }

    public class LoginUserService : ILoginUserService
    {
        private readonly IDataBaseContext _context;
        public LoginUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<LoginResultDTO> LoginUser(string email, string password)
        {
            if(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return new ResultDTO<LoginResultDTO>()
                {
                    Data = {},
                    IsSuccess = false,
                    Message = "لطفا تمامی موارد را وارد کنید"
                };
            }

            var user = _context.Users.Include(u => u.UserInRoles)
                .ThenInclude(u => u.Role).Where(u => u.Email.Equals(email)).FirstOrDefault();
            if(user == null)
            {
                return new ResultDTO<LoginResultDTO>()
                {
                    Data = { },
                    IsSuccess = false,
                    Message =  "کاربری با این مشخصات یافت نشد"
                };
            }

            if(password != user.Password)
            {
                return new ResultDTO<LoginResultDTO>()
                {
                    Data = { },
                    IsSuccess = false,
                    Message = "رمز عبور شما اشتباه است"
                };
            }
            var roles = "";
            foreach(var i in user.UserInRoles)
            {
                roles += $"{i.Role.Name}";
            }

            return new ResultDTO<LoginResultDTO>()
            {
                Data = new LoginResultDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Roles = roles
                },
                IsSuccess = true,
                Message = "ورود به سایت با موفقیت انجام شد"
            };
        }
    }

    public class LoginResultDTO
    {
        public long Id { get; set; }
        public string Roles { get; set; }
        public string Name { get; set; }
    }
}
