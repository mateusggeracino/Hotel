using System.Collections.Generic;
using Hotel.Business.Interfaces;
using Hotel.Domain.Models;
using Hotel.Domain.ValueObjects;
using Hotel.Repository.Interfaces;
using Hotel.Repository.Repository;

namespace Hotel.Business.Business
{
    public class RoomBusiness : IRoomBusiness
    {
        private readonly IRoomRepository _roomRepository;
        public RoomBusiness()
        {
            _roomRepository = new RoomRepository();
        }

        public List<RoomEntity> GetAll()
        {
            return _roomRepository.GetAll();
        }

        public RoomEntity GetById(int id)
        {
            return _roomRepository.GetById(id);
        }

        public List<RoomEntity> GetByStatus(RoomStatus status)
        {
            return _roomRepository.GetByStatus(status);
        }

        public List<RoomEntity> GetByType(RoomType type)
        {
            return _roomRepository.GetByType(type);
        }

        public RoomEntity Insert(RoomEntity room)
        {
            return _roomRepository.Insert(room);
        }
    }
}
