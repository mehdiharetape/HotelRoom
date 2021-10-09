using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using HotelProject.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Users.Command.RegisterUser.IRegisterUserForAdmin
{
    public interface IRegisterUserForAdminService
    {
        ResultDTO<UserResultDTO> RegisterUser(RegisterUser_DTO request);
    }

    public class RegisterUserForAdminService : IRegisterUserForAdminService
    {
        private readonly IDataBaseContext _context;
        public RegisterUserForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<UserResultDTO> RegisterUser(RegisterUser_DTO request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Name))
                {
                    return new ResultDTO<UserResultDTO>()
                    {
                        Data = {},
                        IsSuccess = false,
                        Message = "نام را وارد کنید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Mobile))
                {
                    return new ResultDTO<UserResultDTO>()
                    {
                        Data = { },
                        IsSuccess = false,
                        Message = "همراه خود را وارد کنید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Phone))
                {
                    return new ResultDTO<UserResultDTO>()
                    {
                        Data = { },
                        IsSuccess = false,
                        Message = "تلفن ثابت خود را وارد کنید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDTO<UserResultDTO>()
                    {
                        Data = { },
                        IsSuccess = false,
                        Message = "رمز عبور خود را وارد کنید"
                    };
                }
                if (request.Password != request.RePassword)
                {
                    return new ResultDTO<UserResultDTO>()
                    {
                        Data = { },
                        IsSuccess = false,
                        Message = "تگرار رمز عبور نادرست است"
                    };
                }
                //
                User user = new User() 
                {
                    Name = request.Name,
                    MobileNumber = request.Mobile,
                    PhoneNumber = request.Phone,
                    Password = request.Password,
                    Email = request.Email,
                };
                List<UserInRole> inRoles = new List<UserInRole>();
                foreach(var item in request.Roles)
                {
                    var role = _context.Roles.Find(item.Id);
                    inRoles.Add(new UserInRole 
                    {
                        Role = role,
                        RoleId = role.Id,
                        User = user,
                        UserId = user.Id
                    });
                }
                user.UserInRoles = inRoles;
                _context.Users.Add(user);
                _context.SaveChanges();
                return new ResultDTO<UserResultDTO>()
                {
                    Data = new UserResultDTO
                    {
                        UserId = user.Id,
                    },
                    IsSuccess = true,
                    Message = "کاربر با موفقیت اضافه شد",
                };
            }
            catch(Exception e)
            {
                return new ResultDTO<UserResultDTO>()
                {
                    Data = {},
                    IsSuccess = false,
                    Message = "خطا",
                };
            }
        }
    }

    public class RegisterUser_DTO
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public List<UserRolesDTO> Roles { get; set; }
    }

    public class UserRolesDTO
    {
        public long Id { get; set; }
    }

    public class UserResultDTO
    {
        public long UserId { get; set; }
    }
}
