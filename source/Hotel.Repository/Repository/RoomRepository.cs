using System.Collections.Generic;
using System.Linq;
using Hotel.Domain.Models;
using Hotel.Domain.ValueObjects;
using Hotel.Repository.Interfaces;

namespace Hotel.Repository.Repository
{
    public class RoomRepository : Repository<RoomEntity>, IRoomRepository
    {
        public List<RoomEntity> GetByStatus(RoomStatus status)
        {
            return _data.Where(x => x.Status == status).ToList();
        }

        public List<RoomEntity> GetByType(RoomType type)
        {
            return _data.Where(x => x.Type == type).ToList()
        }
    }
}
