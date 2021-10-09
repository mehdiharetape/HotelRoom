namespace HotelProject.Domain.Entities.Rooms
{
    public class RoomDetails
    {
        public long Id { get; set; }
        public virtual Room Room { get; set; }
        public long RoomId { get; set; }
        public string Detail { get; set; }
    }
}
