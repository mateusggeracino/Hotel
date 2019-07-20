using Hotel.Application.Views;

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
