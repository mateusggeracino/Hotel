using Hotel.Domain.ValueObjects;

namespace Hotel.Domain.Models
{
    public class RoomEntity : Entity
    {
        public RoomStatus Status { get; set; }
        public RoomTypeEntity Type { get; set; }
    }
}