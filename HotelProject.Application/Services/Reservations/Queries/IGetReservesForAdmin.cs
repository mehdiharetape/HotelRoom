using HotelProject.Application.IDataBase_Context;
using HotelProject.Application.Services.Reservations.Command;
using HotelProject.Common.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Reservations.Queries
{
    public interface IGetReservesForAdmin
    {
        ResultDTO<List<ResultforReserve_DTO>> GetReserves(string SearchKey, int skip, int take, Filter filter);
        int GetReservsCount();
    }

    public class GetReservesForAdmin : IGetReservesForAdmin
    {
        private readonly IDataBaseContext _context;
        public GetReservesForAdmin(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<ResultforReserve_DTO>> GetReserves(string SearchKey, int skip, int take, Filter filter)
        {
            var reservs = _context.Reservations.OrderByDescending(r => r.Id)
                .Include(r => r.WithPersons).Include(r => r.Room)
                .Skip(skip).Take(take)
                .AsQueryable();
            //search based on user name
            if (!string.IsNullOrWhiteSpace(SearchKey))
            {
                reservs = _context.Reservations.OrderByDescending(r => r.Id)
                    .Where(r => r.Name.Contains(SearchKey)).
                    Include(r => r.WithPersons).Include(r => r.Room).Skip(skip).Take(take).AsQueryable();
            }
            //filters
            switch (filter)
            {
                case Filter.NotOrder:
                    reservs = reservs.OrderByDescending(r => r.Id).
                    Include(r => r.WithPersons).Include(r => r.Room).Skip(skip).Take(take).AsQueryable();
                    break;
                case Filter.Finished:
                    reservs = reservs.OrderByDescending(r => r.Id).Where(r => r.Status == Status.Finished).
                    Include(r => r.WithPersons).Include(r => r.Room).Skip(skip).Take(take).AsQueryable();
                    break;
                case Filter.NotFinished:
                    reservs = reservs.OrderByDescending(r => r.Id).Where(r => r.Status == Status.NotFinished).
                    Include(r => r.WithPersons).Include(r => r.Room).Skip(skip).Take(take).AsQueryable();
                    break;
                case Filter.Canceled:
                    reservs = reservs.OrderByDescending(r => r.Id).Where(r => r.Status == Status.Canceled).
                    Include(r => r.WithPersons).Include(r => r.Room).Skip(skip).Take(take).AsQueryable();
                    break;
            }
            return new ResultDTO<List<ResultforReserve_DTO>>()
            {
                Data = reservs.Select(r => new ResultforReserve_DTO
                {
                    Id = r.Id,
                    UserId = r.UserId,
                    RoomCode = r.Room.Code,
                    RoomId = r.RoomId,
                    UserName = r.Name,
                    StartTime = r.StartTime,
                    EndTime = r.EndTime,
                    Mobile = r.Mobile,
                    UserPhone = r.Phone,
                    Address = r.Address,
                    Status = r.Status,
                    TotalPrice = r.TotalPrice,
                    WithPersonsCount = r.WithPersonsCount,
                    WithPersons = r.WithPersons.Select(w => new WithPersonsDTO
                    {
                        Name = w.Name,
                        Phone = w.Phone,
                        ReservationId = w.ReservationId
                    }).ToList()
                }).ToList(),
            };
        }

        public int GetReservsCount()
        {
            return _context.Reservations.Count();
        }
    }

    public class ResultforReserve_DTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long RoomCode { get; set; }
        public long RoomId { get; set; }
        public string UserName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Mobile { get; set; }
        public string UserPhone { get; set; }
        public string Address { get; set; }
        public string WithPersonsCount { get; set; }
        public string Status { get; set; }
        public long TotalPrice { get; set; }
        public List<WithPersonsDTO> WithPersons { get; set; }
    }

    public class WithPersonsDTO
    {
        public long ReservationId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    public enum Filter
    {
        NotOrder = 0,

        ///<summary>
        ///تمام نشده
        ///</summary>
        NotFinished = 1,

        ///<summary>
        ///تمام شده
        ///</summary>
        Finished = 2,

        ///<summary>
        ///لغو شده
        ///</summary>
        Canceled = 3,
    }
}
