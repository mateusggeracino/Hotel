using Hotel.Domain.Models;

namespace Hotel.Business.Interfaces
{
    public interface IReservationBusiness
    {
        ReservationEntity Insert(ReservationEntity reservation);
    }
}
