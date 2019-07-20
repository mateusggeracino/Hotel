using Hotel.Domain.Models;
using Hotel.Repository.Interfaces;

namespace Hotel.Repository.Repository
{
    public class ReservationRepository : Repository<ReservationEntity>, IReservationRepository
    {
    }
}
