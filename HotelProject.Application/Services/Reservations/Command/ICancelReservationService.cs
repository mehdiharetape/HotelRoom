using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Reservations.Command
{
    public interface ICancelReservationService
    {
        ResultDTO Cancel(long Id);
    }

    public class CancelReservationService : ICancelReservationService
    {
        private readonly IDataBaseContext _context;
        public CancelReservationService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDTO Cancel(long Id)
        {
            var reserve = _context.Reservations.Find(Id);
            if(reserve == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "مورد خاصی یافت نشد"
                };
            }

            reserve.Status = Status.Canceled;
            _context.SaveChanges();

            return new ResultDTO
            {
                IsSuccess = true,
                Message = "رزرو با موفقیت لغو شد"
            };
        }
    }
}
