using System.Collections.Generic;
using Hotel.Business.Interfaces;
using Hotel.Domain.Models;

namespace Hotel.Services
{
    public class ClientServices
    {
        private readonly IClientBusiness _clientBusiness;

        public ClientServices(IClientBusiness clientBusiness)
        {
            _clientBusiness = clientBusiness;
        }

        public ClientEntity Insert(ClientEntity clientEntity)
        {
            var client = _clientBusiness.Insert(clientEntity);
            return client;
        }

        public ClientEntity GetBySocialNumber(string socialNumber)
        {
            var client = _clientBusiness.GetBySocialNumber(socialNumber);

            return client;
        }

        public List<ClientEntity> GetAll()
        {
            var clients = _clientBusiness.GetAll();
            return clients;
        }
    }
}