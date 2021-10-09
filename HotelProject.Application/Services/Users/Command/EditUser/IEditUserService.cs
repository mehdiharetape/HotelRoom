using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using HotelProject.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Users.Command.EditUser
{
    public interface IEditUserService
    {
        ResultDTO EditUser(EditUsersDTO request);
    }

    public class EditUserService : IEditUserService
    {
        private readonly IDataBaseContext _context;
        public EditUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO EditUser(EditUsersDTO request)
        {
            var user = _context.Users.Include(u => u.UserInRoles)
                .ThenInclude(u => u.Role).Where(u => u.Id == request.Id).FirstOrDefault();
            if(user == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد ..."
                };
            }

            user.Name = request.Name;
            user.MobileNumber = request.Mobile;
            user.PhoneNumber = request.Phone;
            user.Email = request.Email;
            user.UserInRoles.FirstOrDefault().RoleId = request.RoleId;

            _context.SaveChanges();
            return new ResultDTO
            {
                IsSuccess = true,
                Message = "کاربر ویرایش شد ..."
            };
        }
    }

    public class EditUsersDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public long RoleId { get; set; }
    }
}
