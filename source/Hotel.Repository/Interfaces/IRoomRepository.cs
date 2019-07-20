using Hotel.Domain.Models;
using Hotel.Domain.ValueObjects;
using System.Collections.Generic;

namespace Hotel.Repository.Interfaces
{
    public interface IRoomRepository : IRepository<RoomEntity>
    {
        List<RoomEntity> GetByStatus(RoomStatus status);
        List<RoomEntity> GetByType(RoomType type);
    }
}
