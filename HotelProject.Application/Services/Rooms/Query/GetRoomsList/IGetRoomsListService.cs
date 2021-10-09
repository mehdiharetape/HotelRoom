using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Rooms.Query.GetRoomsList
{
    public interface IGetRoomsListService
    {
        ResultDTO<List<ResultRoomsList_DTO>> RoomsList(string SearchKey, int skip, int take);
        int GetRoomscount();
    }

    public class GetRoomsListService : IGetRoomsListService
    {
        private readonly IDataBaseContext _context;
        public GetRoomsListService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<ResultRoomsList_DTO>> RoomsList(string SearchKey, int skip, int take)
        {
            var rooms = _context.Rooms.OrderByDescending(r => r.Id).Skip(skip).Take(take)
                .Include(r => r.RoomDetails)
                .ThenInclude(r => r.Room).AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchKey))
            {
                rooms = _context.Rooms.Where(r => r.Name.Contains(SearchKey) || r.BedsCount == SearchKey ||
                                     r.Dimension.Contains(SearchKey)).Skip(skip).Take(take)
                    .Include(r => r.RoomDetails).ThenInclude(r => r.Room).AsQueryable();
            }

            return new ResultDTO<List<ResultRoomsList_DTO>>()
            {
                Data = rooms.Select(r => new ResultRoomsList_DTO
                {
                    Id = r.Id,
                    Code = r.Code,
                    Name = r.Name,
                    BedCount = r.BedsCount,
                    CostePerNight = r.CostPerNight,
                    Dimension = r.Dimension,
                    RoomDetails = _context.RoomDetails.Where(p => p.RoomId == r.Id).Select(r => new RoomDetails 
                    {
                        Id = r.Id,
                        RoomId = r.RoomId,
                        Detail = r.Detail,
                    }).FirstOrDefault(),
                }).ToList(),
                IsSuccess = true,
                Message = ""
            };
        }
        
        public int GetRoomscount()
        {
            return _context.Rooms.Count();
        }
    }

    public class ResultRoomsList_DTO
    {
        public long Id { get; set; }
        public long Code { get; set; }
        public string Name { get; set; }
        public string BedCount { get; set; }
        public long CostePerNight { get; set; }
        public string Dimension { get; set; }
        public RoomDetails RoomDetails { get; set; }
    }

    public class RoomDetails
    {
        public long Id { get; set; }
        public long RoomId { get; set; }
        public string Detail { get; set; }
    }
}
