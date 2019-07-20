using Hotel.Domain.Models;
using Hotel.Repository.Interfaces;
using System.Linq;

namespace Hotel.Repository.Repository
{
    public class ClientRepository : Repository<ClientEntity>, IClientRepository
    {
        public ClientEntity GetBySocialNumber(string socialNumber)
        {
            return _data.FirstOrDefault(x => x.SocialNumber.Contains(socialNumber));
        }
    }
}
