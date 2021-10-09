using HotelProject.Domain.Entities.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Domain.Entities.Cooments
{
    public class Comment
    {
        public long Id { get; set; }
        public string CommentText { get; set; }
        public virtual Room Room { get; set; }
        public long RoomId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
