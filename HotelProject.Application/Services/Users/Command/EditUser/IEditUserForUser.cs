using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Users.Command.EditUser
{
    public interface IEditUserForUser
    {
        ResultDTO<ResultUserDTO> GetUserInfo(long? Id);
        ResultDTO EditUser(ResultUserDTO request);
    }

    public class EditUserForUser : IEditUserForUser
    {
        private readonly IDataBaseContext _context;
        public EditUserForUser(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO EditUser(ResultUserDTO request)
        {
            var user = _context.Users.Find(request.Id);
            if (user == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            user.Name = request.Name;
            user.Email = request.Email;
            user.MobileNumber = request.Mobile;
            user.PhoneNumber = request.Phone;
            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true,
                Message = "مشخصات با موفقیت ویرایش شد"
            };
        }

        public ResultDTO<ResultUserDTO> GetUserInfo(long? Id)
        {
            var user = _context.Users.Find(Id);
            if(user == null)
            {
                return new ResultDTO<ResultUserDTO>
                {
                    Data = {},
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            return new ResultDTO<ResultUserDTO>
            {
                Data = new ResultUserDTO
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    Mobile = user.MobileNumber,
                    Phone = user.PhoneNumber
                },
                IsSuccess = true,
                Message = ""
            };
        }
    }

    public class ResultUserDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
    }
}
