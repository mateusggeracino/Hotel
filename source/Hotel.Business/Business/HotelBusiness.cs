using System.Runtime.InteropServices.ComTypes;
using Hotel.Business.Interfaces;
using Hotel.Domain.Models;
using Hotel.Domain.ValueObjects;
using Hotel.Repository.Interfaces;
using Hotel.Repository.Repository;

namespace Hotel.Business.Business
{
    public class HotelBusiness : IHotelBusiness
    {
        private readonly IRepository<RoomEntity> _roomRepository;

        public HotelBusiness()
        {
            _roomRepository = new Repository<RoomEntity>();
        }

        public HotelEntity GetInfoHotel()
        {
            var infoHotel = new HotelEntity
            {
                QuantityRoom = _roomRepository.GetAll().Count,
                QuantityRoomBlock = _roomRepository.Find(x => x.Status == RoomStatus.Block).Count,
                QuantityRoomBusy = _roomRepository.Find(x => x.Status == RoomStatus.Busy).Count
            };

            return infoHotel;
        }
    }
}