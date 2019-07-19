using Hotel.Domain.Models;
using Hotel.Domain.ValueObjects;

namespace Hotel.Services.Interfaces
{
    public interface IRoomBusiness : IBusiness<Room>
    {
        bool RemoveForType(TypeRoom type);
    }
}