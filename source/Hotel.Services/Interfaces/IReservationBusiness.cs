using Hotel.Domain.Models;

namespace Hotel.Services.Interfaces
{
    public interface IReservationBusiness : IBusiness<Reservation>
    {
        void Cancel(Reservation reservation);
    }
}