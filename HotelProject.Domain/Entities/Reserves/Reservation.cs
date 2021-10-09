using HotelProject.Domain.Entities.Rooms;
using HotelProject.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Domain.Entities.Reserves
{
    public class Reservation
    {
        public long Id { get; set; }
        public virtual User User { get; set; }
        public long UserId { get; set; }
        public virtual Room Room { get; set; }
        public long RoomId { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string WithPersonsCount { get; set; }
        public string Status { get; set; }
        public long TotalPrice { get; set; }
        public ICollection<WithPersons> WithPersons { get; set; }
    }
}
