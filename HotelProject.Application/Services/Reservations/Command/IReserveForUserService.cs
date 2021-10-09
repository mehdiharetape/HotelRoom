using HotelProject.Application.IDataBase_Context;
using HotelProject.Common.Result;
using HotelProject.Domain.Entities.Reserves;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Application.Services.Reservations.Command
{
    public interface IReserveForUserService
    {
        ResultDTO ReserveForUser(RequestforReserve_DTO request);
        ResultDTO CheckReservation(long Id, DateTime startTime, DateTime endTime);
    }

    public class ReserveForUserService : IReserveForUserService
    {
        private readonly IDataBaseContext _context;
        public ReserveForUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDTO CheckReservation(long Id,DateTime startTime, DateTime endTime)
        {
            if(Id == 0 || startTime == DateTime.MinValue || endTime == DateTime.MinValue)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "لطفا تاریخ را انتخاب کنید"
                };
            }
            var reservs = _context.Reservations
                .Where(r => r.RoomId == Id & r.Status == Status.NotFinished).ToList();
            bool[] Check = new bool[reservs.Count];
            int j = 0;
            if (reservs.Count() == 0 && startTime > DateTime.Now && endTime > DateTime.Now && endTime >= startTime)
            {
                return new ResultDTO()
                {
                    IsSuccess = true,
                    Message = "رزرو در این تاریخ امکان پذیر است . در ادامه اطلاعات لازم را وارد کنید"
                };
            }
            foreach (var i in reservs)
            {
                if (DateCollision(i.StartTime, i.EndTime, startTime, endTime) ||
                    startTime <= DateTime.Now || endTime <= DateTime.Now && endTime < startTime)
                {
                    Check[j] = false;
                }
                else
                    Check[j] = true;
                j++;
            }
            if (CheckArray(Check) == false)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "امکان رزرو این اتاق در این تاریخ وجود ندارد"
                };
            }
            else
            {
                return new ResultDTO()
                {
                    IsSuccess = true,
                    Message = "رزرو در این تاریخ امکان پذیر است . در ادامه اطلاعات لازم را وارد کنید"
                };
            }
        }//End CheckReservation

        public ResultDTO ReserveForUser(RequestforReserve_DTO request)
        {
            if (string.IsNullOrWhiteSpace(request.Address) || request.WithPersons == null)
            {
                return new ResultDTO
                {
                    IsSuccess = false,
                    Message = "تمام موارد را وارد کنید"
                };
            }
            var room = _context.Rooms.Find(request.RoomId);
            double totalPrice = (request.EndTime - request.StartTime).TotalDays * room.CostPerNight;
            Reservation reservation = new Reservation()
            {
                UserId = request.UserId,
                RoomId = request.RoomId,
                Name = request.UserName,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                Mobile = request.Mobile,
                Phone = request.UserPhone,
                Address = request.Address,
                Status = Status.NotFinished,
                TotalPrice = long.Parse(totalPrice.ToString()),
                WithPersonsCount = request.WithPersonsCount,
            };
            _context.Reservations.Add(reservation);
            List<WithPersons> withPersons = new List<WithPersons>();
            foreach (var i in request.WithPersons)
            {
                WithPersons with = new WithPersons()
                {
                    Name = i.Name,
                    Phone = i.Phone,
                    Reservation = reservation,
                    ReservationId = reservation.Id
                };
                withPersons.Add(with);
                _context.WithPersons.Add(with);
            }
            reservation.WithPersons = withPersons;
            _context.SaveChanges();
            return new ResultDTO()
            {
                IsSuccess = true,
                Message = "اطلاعات با موفقیت ثبت شد."
            };
        }// end of ReserveForUser

        //Check Array
        private bool CheckArray(bool[] Check)
        {
            bool result = false;
            for(int i = 0; i < Check.Length; i++)
            {
                if (Check[i] == false)
                {
                    result = false;
                    break;
                }
                else
                    result = true;
            }
            return result;
        }

        //Check Date Collision
        private bool DateCollision(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            if((start1 <= end2) && (start2 <= end1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class RequestforReserve_DTO
    {
        public long UserId { get; set; }
        public long RoomId { get; set; }
        public string UserName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Mobile { get; set; }
        public string UserPhone { get; set; }
        public string Address { get; set; }
        public string WithPersonsCount { get; set; }
        public List<WithPersonsDTO> WithPersons { get; set; }
    }

    public class WithPersonsDTO
    {
        public long ReservationId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    public class Status
    {
        [Display(Name = "تمام شده")]
        public const string Finished = "Finished";

        [Display(Name = "تمام نشده")]
        public const string NotFinished = "NotFinished";

        [Display(Name = "لغو شده")]
        public const string Canceled = "Canceled";
    }
}
