using Hotel.Domain.Models;
using Hotel.Domain.ValueObjects;
using System.Collections.Generic;

namespace Hotel.Business.Interfaces
{
    /// <summary>
    /// Contrato responsável por manter a implementação dos métodos na classe concreta.
    /// </summary>
    public interface IRoomBusiness
    {
        RoomEntity Insert(RoomEntity room);
        RoomEntity GetById(int id);
        List<RoomEntity> GetAll();
        List<RoomEntity> GetByType(RoomTypeEntity roomType);
        List<RoomEntity> GetByStatus(RoomStatus status);

        List<RoomTypeEntity> GetAllTypes();
    }
}
