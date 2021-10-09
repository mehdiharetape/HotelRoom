using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Users.Query.GetUserDetails
{
    public interface IGetUserInfo
    {
        ResultDTO<ResultGetDetails_DTO> GetDetails(long? Id, long RoomId);
    }

    public class GetUserInfo : IGetUserInfo
    {
        private readonly IDataBaseContext _context;
        public GetUserInfo(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<ResultGetDetails_DTO> GetDetails(long? Id, long RoomId)
        {
            var room = _context.Rooms.Find(RoomId);
            var user = _context.Users.Find(Id);
            if(user == null || room == null)
            {
                return new ResultDTO<ResultGetDetails_DTO>
                {
                    Data = {},
                    IsSuccess = false,
                    Message = "کاربر یا اتاق یافت نشد"
                };
            }
            return new ResultDTO<ResultGetDetails_DTO>()
            {
                Data = new ResultGetDetails_DTO
                {
                    RoomId = room.Id,
                    Code = room.Code,
                    RoomName = room.Name,
                    UserId = user.Id,
                    UserName = user.Name,
                    Email = user.Email,
                    Mobile = user.MobileNumber,
                    Phone = user.PhoneNumber,
                },
                IsSuccess = true,
                Message = ""
            };
        }
    }

    public class ResultGetDetails_DTO
    {
        public long RoomId { get; set; }
        public long Code { get; set; }
        public string RoomName { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
    }
}
