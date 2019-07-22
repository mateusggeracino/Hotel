using Hotel.Domain.ValueObjects;

namespace Hotel.Domain.Models
{
    /// <summary>
    /// Entidade responsável por conter as propriedades de um quarto.
    /// </summary>
    public class RoomEntity : Entity
    {
        public RoomStatus Status { get; set; }
        public RoomTypeEntity Type { get; set; }
    }
}