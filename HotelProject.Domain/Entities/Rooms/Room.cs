using HotelProject.Domain.Entities.Cooments;
using HotelProject.Domain.Entities.Reserves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Domain.Entities.Rooms
{
    public class Room
    {
        public long Id { get; set; }
        public long Code { get; set; }
        public string Name { get; set; }
        public string BedsCount { get; set; }
        public long CostPerNight { get; set; }
        public string ImageSrc { get; set; }
        public string Dimension { get; set; }
        public long ViewCount { get; set; }
        public ICollection<RoomDetails> RoomDetails { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
