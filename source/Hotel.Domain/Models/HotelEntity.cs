namespace Hotel.Domain.Models
{
    public class HotelEntity : Entity
    {
        public int QuantityRoom { get; set; }
        public int QuantityRoomBlock { get; set; }
        public int QuantityRoomBusy { get; set; }
    }
}