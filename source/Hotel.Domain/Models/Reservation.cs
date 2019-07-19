using System;

namespace Hotel.Domain.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public Room Room { get; set; }
        public DateTime TimeRegister { get; set; }
    }
}