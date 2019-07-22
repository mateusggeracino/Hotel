using Hotel.Domain.Models;
using System.Collections.Generic;

namespace Hotel.Business.Interfaces
{
    /// <summary>
    /// Contrato responsável por manter a implementação dos métodos na classe concreta.
    /// </summary>
    public interface IClientBusiness
    {
        ClientEntity Insert(ClientEntity client);
        ClientEntity GetBySocialNumber(string socialNumber);
        List<ClientEntity> GetAll();
    }
}
