using Hotel.Business.Interfaces;
using Hotel.Domain.Models;
using Hotel.Repository.Interfaces;
using Hotel.Repository.Repository;

namespace Hotel.Business.Business
{
    public class ClientBusiness : IClientBusiness
    {
        private readonly IClientRepository _clientRepository;
        public ClientBusiness()
        {
            _clientRepository = new ClientRepository();
        }

        public ClientEntity Insert(ClientEntity clientEntity)
        {
            var client = _clientRepository.GetBySocialNumber(clientEntity.SocialNumber);
            if (client == null) client = _clientRepository.Insert(clientEntity);

            return client;
        }
    }
}
