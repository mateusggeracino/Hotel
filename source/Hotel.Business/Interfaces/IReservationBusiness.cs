using System.Collections.Generic;
using Hotel.Domain.Models;

namespace Hotel.Business.Interfaces
{
    public interface IBookingBusiness
    {
        BookingEntity Insert(BookingEntity booking);
        List<BookingEntity> GetBySocialNumber(string socialNumber);
    }
}
