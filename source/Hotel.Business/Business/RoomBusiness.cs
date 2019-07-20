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
        private readonly IRepository<RoomEntity> _roomRepository;
        public RoomBusiness()
        {
            _roomRepository = new Repository<RoomEntity>();
        }

        public List<RoomEntity> GetAll()
        {
            return _roomRepository.GetAll();
        }

        public RoomEntity GetById(int id)
        {
            var room = _roomRepository.GetById(id);
            if (room == null)
            {
                room = new RoomEntity();
                room.Validations.Add("Room not found");
            }

            return room;
        }

        public List<RoomEntity> GetByStatus(RoomStatus status)
        {
            return _roomRepository.Find(x => x.Status == status);
        }

        public List<RoomEntity> GetByType(RoomTypeEntity roomTypeEntity)
        {
            return _roomRepository.Find(x => x.Type.RoomType == roomTypeEntity.RoomType);
        }

        public RoomEntity Insert(RoomEntity room)
        {
            return _roomRepository.Insert(room);
        }

        public List<RoomTypeEntity> GetAllTypes()
        {
            return new List<RoomTypeEntity>
            {
                new RoomTypeEntity{Id = 1, RoomType = RoomType.Lux, Price = 470},
                new RoomTypeEntity{Id = 2, RoomType = RoomType.Standard, Price = 310},
                new RoomTypeEntity{Id = 3, RoomType = RoomType.Single, Price = 210}
            };
        }
    }
}
