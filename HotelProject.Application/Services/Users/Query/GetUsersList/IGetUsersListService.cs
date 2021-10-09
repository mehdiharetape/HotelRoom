using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Users.Query.GetUsersList
{
    public interface IGetUsersListService
    {
        ResultDTO<List<UsersList_DTO>> GetUsersList(string SearchKey, int skip=0,int take=10);
        int GetUsersCount();
    }

    public class GetUsersListService : IGetUsersListService
    {
        private readonly IDataBaseContext _context;
        public GetUsersListService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<UsersList_DTO>> GetUsersList(string SearchKey, int skip, int take)
        {

            var users = _context.Users.OrderByDescending(u => u.Id).Skip(skip).Take(take)
                .Include(u => u.UserInRoles).ThenInclude(u => u.Role).AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchKey))
            {
                 users = _context.Users.Where(u => u.Name.Contains(SearchKey) || u.Email.Contains(SearchKey)
                                     || u.MobileNumber.Contains(SearchKey) || u.PhoneNumber.Contains(SearchKey))
                    .Skip(skip).Take(take)
                    .Include(u => u.UserInRoles).ThenInclude(u => u.Role)
                    .OrderByDescending(u => u.Id).AsQueryable();
            }

            return new ResultDTO<List<UsersList_DTO>>()
            {
                Data = users.Select(u => new UsersList_DTO
                {
                    Id = u.Id,
                    Name = u.Name,
                    Mobile = u.MobileNumber,
                    Phone = u.PhoneNumber,
                    Email = u.Email,
                    Role = u.UserInRoles.FirstOrDefault().Role.Name,
                    RoleId = u.UserInRoles.FirstOrDefault().RoleId,
                }).ToList(),
                IsSuccess = true,
                Message = ""
            };
        }
        public int GetUsersCount()
        {
            return _context.Users.Count();
        }
    }

    public class UsersList_DTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public long RoleId { get; set; }
    }

}
