using Hotel.Domain.Models;
using Hotel.Domain.ValueObjects;
using System.Collections.Generic;

namespace Hotel.Business.Interfaces
{
    public interface IRoomBusiness
    {
        RoomEntity Insert(RoomEntity room);
        RoomEntity GetById(int id);
        List<RoomEntity> GetAll();
        List<RoomEntity> GetByType(RoomType type);
        List<RoomEntity> GetByStatus(RoomStatus status);
    }
}
