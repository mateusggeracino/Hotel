using System.Collections.Generic;
using System.Linq;
using Hotel.Business.Interfaces;
using Hotel.Domain.Models;
using Hotel.Domain.ValueObjects;

namespace Hotel.Services
{
    /// <summary>
    /// Classe concreta responsável por orquestrar os métodos do quarto
    /// </summary>
    public class RoomServices
    {
        private readonly IRoomBusiness _roomBusiness;
        public RoomServices(IRoomBusiness roomBusiness)
        {
            _roomBusiness = roomBusiness;
        }

        /// <summary>
        /// Responsável por orquestrar a inserção de um novo quarto.
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public RoomEntity Insert(RoomEntity room)
        {
            var roomEntity = _roomBusiness.Insert(room);
            return roomEntity;
        }

        /// <summary>
        /// Obtem quarto por tipo.
        /// </summary>
        /// <param name="roomType"></param>
        /// <returns></returns>
        public List<RoomEntity> GetByType(RoomTypeEntity roomType)
        {
            var rooms = _roomBusiness.GetByType(roomType);
            return rooms;
        }

        /// <summary>
        /// Obtem quarto por status
        /// </summary>
        /// <param name="roomStatus"></param>
        /// <returns></returns>
        public IEnumerable<RoomEntity> GetByStatus(RoomStatus roomStatus)
        {
            var rooms = _roomBusiness.GetByStatus(roomStatus);
            return rooms;
        }

        /// <summary>
        /// Obtem todos os tipos de quartos cadastrados.
        /// </summary>
        /// <returns></returns>
        public List<RoomTypeEntity> GetAllTypes()
        {
            var roomTypes = _roomBusiness.GetAllTypes();

            return roomTypes.OrderBy(x => x.Id).ToList();
        }
    }
}
