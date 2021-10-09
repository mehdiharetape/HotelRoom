using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Rooms.Query.GetRoomDetails
{
    public interface IGetRoomDetailService
    {
        ResultDTO<ResultGetRoomsDTO> GetRoomDetails(long Id);
    }
    public class GetRoomDetailService : IGetRoomDetailService
    {
        private readonly IDataBaseContext _context;
        public GetRoomDetailService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<ResultGetRoomsDTO> GetRoomDetails(long Id)
        {
            var room = _context.Rooms.Include(r => r.RoomDetails).Where(r => r.Id == Id).FirstOrDefault();
            if(room == null)
            {
                return new ResultDTO<ResultGetRoomsDTO>
                {
                    Data = { },
                    IsSuccess = false,
                    Message = ""
                };
            }
            room.ViewCount++;
            _context.SaveChanges();
            return new ResultDTO<ResultGetRoomsDTO>()
            {
                Data = new ResultGetRoomsDTO
                {
                    Id = room.Id,
                    Name = room.Name,
                    Code = room.Code,
                    BedCount = room.BedsCount,
                    CostPerNight = room.CostPerNight,
                    Dimension = room.Dimension,
                    ImageSrc = room.ImageSrc,
                    ViewCount = room.ViewCount,
                    RoomDetails = room.RoomDetails.Where(p => p.RoomId == room.Id).Select(p => new RoomDetails
                    {
                        Id = p.Id,
                        RoomId = p.RoomId,
                        Detail = p.Detail
                    }).FirstOrDefault()
                },
                IsSuccess = true,
                Message = ""
            };
        }
    }

    public class ResultGetRoomsDTO
    {
        public long Id { get; set; }
        public string ImageSrc { get; set; }
        public long Code { get; set; }
        public string Name { get; set; }
        public string BedCount { get; set; }
        public long CostPerNight { get; set; }
        public string Dimension { get; set; }
        public long ViewCount { get; set; }
        public RoomDetails RoomDetails { get; set; }
    }
    public class RoomDetails
    {
        public long Id { get; set; }
        public long RoomId { get; set; }
        public string Detail { get; set; }
    }
}
