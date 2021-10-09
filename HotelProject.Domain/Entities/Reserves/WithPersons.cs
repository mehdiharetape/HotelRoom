using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Domain.Entities.Reserves
{
    public class WithPersons
    {
        public long Id { get; set; }
        public virtual Reservation Reservation { get; set; }
        public long ReservationId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
