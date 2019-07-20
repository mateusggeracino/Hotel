using System.Collections.Generic;
using Hotel.Domain.ValueObjects;

namespace Hotel.Domain.Models
{
    public class RoomTypeEntity : Entity
    {
        public RoomType RoomType { get; set; }
        public decimal Price { get; set; }
    }
}