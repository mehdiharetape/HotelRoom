using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Users.Command.DeleteUser
{
    public interface IDeleteUserService
    {
        ResultDTO Delete(long Id);
    }

    public class DeleteUserService : IDeleteUserService
    {
        private readonly IDataBaseContext _context;
        public DeleteUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO Delete(long Id)
        {
            var user = _context.Users.Find(Id);
            if(user == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            _context.Users.Remove(user);
            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true, 
                Message = "کاربر حذف شد"
            };
        }
    }
}
