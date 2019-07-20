using System;

namespace Hotel.Domain.Models
{
    public class ReservationEntity : Entity
    {
        public ClientEntity Client { get; set; }
        public RoomEntity Room { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int Days { get; set; }
    }
}