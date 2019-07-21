using Hotel.Application.Views.Hotel;

namespace Hotel.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var hotel = new HotelView();
            hotel.InitHotel();
        }
    }
}
