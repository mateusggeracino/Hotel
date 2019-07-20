using System;

namespace Hotel.Domain.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public Guid Key { get; set; }
    }
}
