namespace Hotel.Domain.Models
{
    /// <summary>
    /// Entidade responsável por conter as propriedades de um Hotel.
    /// </summary>
    public class HotelEntity : Entity
    {
        public int QuantityRoom { get; set; }
        public int QuantityRoomBlock { get; set; }
        public int QuantityRoomBusy { get; set; }
    }
}