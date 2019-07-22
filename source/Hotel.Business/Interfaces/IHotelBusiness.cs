using Hotel.Domain.Models;

namespace Hotel.Business.Interfaces
{
    /// <summary>
    /// Contrato responsável por manter a implementação dos métodos na classe concreta.
    /// </summary>
    public interface IHotelBusiness
    {
        HotelEntity GetInfoHotel();
    }
}