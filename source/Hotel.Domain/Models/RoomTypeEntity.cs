using Hotel.Domain.ValueObjects;

namespace Hotel.Domain.Models
{
    /// <summary>
    /// Entidade responsável por conter as propriedades do tipo de quarto.
    /// </summary>
    public class RoomTypeEntity : Entity
    {
        public RoomType RoomType { get; set; }
        public decimal Price { get; set; }
    }
}