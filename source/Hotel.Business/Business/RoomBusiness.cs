using System.Collections.Generic;
using Hotel.Business.Interfaces;
using Hotel.Domain.Models;
using Hotel.Domain.ValueObjects;
using Hotel.Repository.Interfaces;

namespace Hotel.Business.Business
{
    /// <summary>
    /// Classe responsável por aplicar as regras de negócio da sala
    /// </summary>
    public class RoomBusiness : IRoomBusiness
    {
        private readonly IRepository<RoomEntity> _roomRepository;
        public RoomBusiness(IRepository<RoomEntity> roomRepository)
        {
            _roomRepository = roomRepository;
        }

        /// <summary>
        /// Obtem todos os quartos cadastrados.
        /// </summary>
        /// <returns></returns>
        public List<RoomEntity> GetAll()
        {
            return _roomRepository.GetAll();
        }

        /// <summary>
        /// Buscar pelo quarto através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Obtem quarto pelo status. Aberto, Fechado ou Bloqueado.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<RoomEntity> GetByStatus(RoomStatus status)
        {
            return _roomRepository.Find(x => x.Status == status);
        }

        /// <summary>
        /// Obtem quarto pelo tipo. Single, Standard ou Lux.
        /// </summary>
        /// <param name="roomTypeEntity"></param>
        /// <returns></returns>
        public List<RoomEntity> GetByType(RoomTypeEntity roomTypeEntity)
        {
            return _roomRepository.Find(x => x.Type.RoomType == roomTypeEntity.RoomType);
        }

        /// <summary>
        /// Responsável por inserir novos quartos.
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public RoomEntity Insert(RoomEntity room)
        {
            return _roomRepository.Insert(room);
        }

        /// <summary>
        /// Obtem todos os tipos de quartos.
        /// </summary>
        /// <returns></returns>
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
