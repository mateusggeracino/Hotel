using System.Collections.Generic;
using System.Linq;
using Hotel.Business.Interfaces;
using Hotel.Domain.Models;
using Hotel.Domain.ValueObjects;

namespace Hotel.Services
{
    public class RoomServices
    {
        private readonly IRoomBusiness _roomBusiness;
        public RoomServices(IRoomBusiness roomBusiness)
        {
            _roomBusiness = roomBusiness;
        }

        public RoomEntity Insert(RoomEntity room)
        {
            var roomEntity = _roomBusiness.Insert(room);
            return roomEntity;
        }

        public List<RoomEntity> GetByType(RoomTypeEntity roomType)
        {
            var rooms = _roomBusiness.GetByType(roomType);
            return rooms;
        }

        public IEnumerable<RoomEntity> GetByStatus(RoomStatus roomStatus)
        {
            var rooms = _roomBusiness.GetByStatus(roomStatus);
            return rooms;
        }

        public List<RoomTypeEntity> GetAllTypes()
        {
            var roomTypes = _roomBusiness.GetAllTypes();

            return roomTypes.OrderBy(x => x.Id).ToList();
        }
    }
}
