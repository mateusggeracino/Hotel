using Hotel.Domain.ValueObjects;

namespace Hotel.Domain.Models
{
    public class RoomEntity : Entity
    {

        public RoomStatus Status { get; set; }
        public RoomType Type { get; set; }
    }
}