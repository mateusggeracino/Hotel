using Hotel.Domain.Models;

namespace Hotel.Repository.Interfaces
{
    public interface IClientRepository : IRepository<ClientEntity>
    {
        ClientEntity GetBySocialNumber(string socialNumber);
    }
}
