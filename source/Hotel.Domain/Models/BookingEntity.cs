using System;

namespace Hotel.Domain.Models
{
    public class BookingEntity : Entity
    {
        public ClientEntity Client { get; set; }
        public RoomEntity Room { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal Total { get; set; }
        public int Days { get; set; }
    }
}