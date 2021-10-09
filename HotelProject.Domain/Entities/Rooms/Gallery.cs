using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Domain.Entities.Rooms
{
    public class Gallery
    {
        public long Id { get; set; }
        public string ImageSrc { get; set; }
        public bool IsShow { get; set; }
    }
}
