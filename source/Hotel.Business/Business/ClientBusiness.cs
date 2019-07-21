using System.Collections.Generic;
using System.Linq;
using Hotel.Business.Interfaces;
using Hotel.Domain.Models;
using Hotel.Repository.Interfaces;

namespace Hotel.Business.Business
{
    public class ClientBusiness : IClientBusiness
    {
        private readonly IRepository<ClientEntity> _clientRepository;
        public ClientBusiness(IRepository<ClientEntity> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public ClientEntity Insert(ClientEntity clientEntity)
        {
            var clientList = ClientExists(clientEntity);
            if (clientList != null) return clientList;

            _clientRepository.Insert(clientEntity);
            return clientEntity;
        }

        private ClientEntity ClientExists(ClientEntity clientEntity)
        {
            var clientList = _clientRepository.Find(x => x.SocialNumber == clientEntity.SocialNumber);

            if (clientList.Any())
            {
                clientEntity.Validations.Add("Error, client existing");
                return clientEntity;
            }

            return null;
        }

        public ClientEntity GetBySocialNumber(string socialNumber)
        {
            var clientList = _clientRepository.Find(x => x.SocialNumber.Contains(socialNumber));
            if (clientList.Any()) return clientList.First();

            var client = new ClientEntity();
            client.Validations.Add("Client not found");

            return client;
        }

        public List<ClientEntity> GetAll()
        {
            return _clientRepository.GetAll();
        }
    }
}
