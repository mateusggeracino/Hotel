using Hotel.Business.Interfaces;
using Hotel.Domain.Models;

namespace Hotel.Services
{
    public class HotelServices
    {
        private readonly IHotelBusiness _hotelBusiness;

        public HotelServices(IHotelBusiness hotelBusiness)
        {
            _hotelBusiness = hotelBusiness;
        }

        public HotelEntity GetInfoHotel()
        {
            return _hotelBusiness.GetInfoHotel();
        }
    }
}