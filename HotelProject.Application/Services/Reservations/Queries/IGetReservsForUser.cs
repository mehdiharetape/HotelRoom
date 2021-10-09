using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Reservations.Queries
{
    public interface IGetReservsForUser
    {
        ResultDTO<List<ResultUserReserve_DTO>> GetReservs(long? Id);
    }

    public class GetReservsForUser : IGetReservsForUser
    {
        private readonly IDataBaseContext _context;
        public GetReservsForUser(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO<List<ResultUserReserve_DTO>> GetReservs(long? Id)
        {
            var reservs = _context.Reservations.Where(r => r.UserId == Id)
                .Include(r => r.WithPersons).AsQueryable();

            return new ResultDTO<List<ResultUserReserve_DTO>>()
            {
                Data = reservs.Select(r => new ResultUserReserve_DTO
                {
                    Id = r.Id,
                    TotalPrice = r.TotalPrice,
                    StartDate = r.StartTime,
                    EndtDate = r.EndTime,
                    RoomCode = r.Room.Code,
                    Status = r.Status,
                    WithPersons = r.WithPersons.Select(w => new WithPersons
                    {
                        Name = w.Name,
                        Phone = w.Phone
                    }).ToList()
                }).ToList(),
                IsSuccess = true,
                Message = ""
            };
        }
    }

    public class ResultUserReserve_DTO
    {
        public long Id { get; set; }
        public long RoomCode { get; set; }
        public long TotalPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }
        public string Status { get; set; }
        public List<WithPersons> WithPersons { get; set; }
    }
    public class WithPersons
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
