using HotelProject.Application.IDataBase_Context;
using HotelProject.Application.Services.Reservations.Command;
using HotelProject.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Reservations.Queries
{
    public interface ICheckFinishedReservation
    {
        void CheckFinished();
    }

    public class CheckFinishedReservation : ICheckFinishedReservation
    {
        private readonly IDataBaseContext _context;
        public CheckFinishedReservation(IDataBaseContext context)
        {
            _context = context;
        }
        public void CheckFinished()
        {
            var reserves = _context.Reservations.Where(r => r.Status == Status.NotFinished).ToList();
            
            foreach(var item in reserves)
            {
                if (item.EndTime < DateTime.Now)
                {
                    item.Status = Status.Finished;
                    _context.SaveChanges();
                }
            }
        }
    }
}
