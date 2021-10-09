using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using HotelProject.Domain.Entities.Rooms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Rooms.Query.GetRoomsForSite
{
    public interface IGetRoomsForSiteService
    {
        ResultDTO<List<ResultGetRoomsDTO>> GetRoomsForMainPage();
        ResultDTO<List<ResultGetRoomsDTO>> GetRoomsForRoomPage(Ordering ordering);
        ResultDTO<List<ResultGetRoomsDTO>> PriceLimit(long? minPrice, long? maxPrice);
    }

    public class GetRoomsForSiteService : IGetRoomsForSiteService
    {
        private readonly IDataBaseContext _context;
        public GetRoomsForSiteService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<ResultGetRoomsDTO>> GetRoomsForMainPage()
        {
            var rooms = _context.Rooms.Take(4).OrderByDescending(r => r.Id).AsQueryable();

            return new ResultDTO<List<ResultGetRoomsDTO>>()
            {
                Data = rooms.Select(r => new ResultGetRoomsDTO
                {
                    Id = r.Id,
                    ImageSrc = r.ImageSrc,
                    Name = r.Name,
                    CostPerNight = r.CostPerNight,
                    Dimension = r.Dimension,
                    BedCount = r.BedsCount,
                }).ToList(),
                IsSuccess = true,
                Message = ""
            };
        }// end of GetRoomsForMainPage

        public ResultDTO<List<ResultGetRoomsDTO>> GetRoomsForRoomPage(Ordering ordering)
        {
            var rooms = _context.Rooms.OrderByDescending(r => r.Id).AsQueryable();

            switch (ordering)
            {
                case Ordering.NotOrder:
                    rooms = rooms.OrderByDescending(r => r.Id).AsQueryable();
                    break;
                case Ordering.MostPopular:
                    rooms = rooms.OrderByDescending(r => r.ViewCount).AsQueryable();
                    break;
                case Ordering.Cheapest:
                    rooms = rooms.OrderBy(r => r.CostPerNight).AsQueryable();
                    break;
                case Ordering.MostExpensive:
                    rooms = rooms.OrderByDescending(r => r.CostPerNight).AsQueryable();
                    break;
            }

            return new ResultDTO<List<ResultGetRoomsDTO>>()
            {
                Data = rooms.Select(r => new ResultGetRoomsDTO
                {
                    Id = r.Id,
                    ImageSrc = r.ImageSrc,
                    Name = r.Name,
                    CostPerNight = r.CostPerNight,
                    Dimension = r.Dimension,
                    BedCount = r.BedsCount,
                }).ToList(),
                IsSuccess = true,
                Message = ""
            };
        }// end of GetRoomsForMainPage

        public ResultDTO<List<ResultGetRoomsDTO>> PriceLimit(long? minPrice, long? maxPrice)
        {
            var rooms = _context.Rooms.OrderByDescending(r => r.Id).AsQueryable();
            if (minPrice != null)
                rooms = rooms.OrderByDescending(r => r.Id).Where(r => r.CostPerNight >= minPrice).AsQueryable();
            if (maxPrice != null)
                rooms = rooms.OrderByDescending(r => r.Id).Where(r => r.CostPerNight <= maxPrice).AsQueryable();
            if (minPrice != null && maxPrice != null)
            {
                rooms = rooms.OrderByDescending(r => r.Id).
                    Where(r => r.CostPerNight <= maxPrice & r.CostPerNight >= minPrice).AsQueryable();
            }
            return new ResultDTO<List<ResultGetRoomsDTO>>()
            {
                Data = rooms.Select(r => new ResultGetRoomsDTO
                {
                    Id = r.Id,
                    ImageSrc = r.ImageSrc,
                    Name = r.Name,
                    CostPerNight = r.CostPerNight,
                    Dimension = r.Dimension,
                    BedCount = r.BedsCount,
                }).ToList(),
                IsSuccess = true,
                Message = ""
            };
        }//end of price limit
    }


    public class ResultGetRoomsDTO
    {
        public long Id { get; set; }
        public string ImageSrc { get; set; }
        public string Name { get; set; }
        public string BedCount { get; set; }
        public long CostPerNight { get; set; }
        public string Dimension { get; set; }
    }

    public enum Ordering
    {
        NotOrder = 0,

        ///<summary>
        ///پربازدید ترین
        ///</summary>
        MostPopular = 1,

        ///<summary>
        ///ارزانترین
        ///</summary>
        Cheapest = 2,

        ///<summary>
        ///گرانترین
        ///</summary>
        MostExpensive = 3,

        ///<summary>
        /// بیشترین رزرو
        ///</summary>
        MostReserve = 4,
    }
}
