using Hotel.Business.Interfaces;
using Hotel.Domain.Models;

namespace Hotel.Services
{
    /// <summary>
    /// Classe concreta responsável por orquestrar os métodos do Hotel
    /// </summary>
    public class HotelServices
    {
        private readonly IHotelBusiness _hotelBusiness;

        public HotelServices(IHotelBusiness hotelBusiness)
        {
            _hotelBusiness = hotelBusiness;
        }

        /// <summary>
        /// Obtem informações básicas do Hotel
        /// </summary>
        /// <returns></returns>
        public HotelEntity GetInfoHotel()
        {
            return _hotelBusiness.GetInfoHotel();
        }
    }
}