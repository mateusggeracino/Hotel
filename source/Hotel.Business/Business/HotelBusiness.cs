using Hotel.Business.Interfaces;
using Hotel.Domain.Models;
using Hotel.Domain.ValueObjects;
using Hotel.Repository.Interfaces;

namespace Hotel.Business.Business
{
    /// <summary>
    /// Classe responsável por aplicar as regras de negócio do Hotel.
    /// </summary>
    public class HotelBusiness : IHotelBusiness
    {
        private readonly IRepository<RoomEntity> _roomRepository;

        public HotelBusiness(IRepository<RoomEntity> roomRepository)
        {
            _roomRepository = roomRepository;
        }

        /// <summary>
        /// Obtem as informações do Hotel. No caso, as informações dos quartos cadastrados no mesmo.
        /// </summary>
        /// <returns></returns>
        public HotelEntity GetInfoHotel()
        {
            var infoHotel = new HotelEntity
            {
                QuantityRoom = _roomRepository.GetAll().Count,
                QuantityRoomBlock = _roomRepository.Find(x => x.Status == RoomStatus.Lock).Count,
                QuantityRoomBusy = _roomRepository.Find(x => x.Status == RoomStatus.Busy).Count
            };

            return infoHotel;
        }
    }
}