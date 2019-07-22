using System.Collections.Generic;
using Hotel.Business.Interfaces;
using Hotel.Domain.Models;

namespace Hotel.Services
{
    /// <summary>
    /// Classe concreta responsável por orquestrar os métodos de cliente
    /// </summary>
    public class ClientServices
    {
        private readonly IClientBusiness _clientBusiness;

        public ClientServices(IClientBusiness clientBusiness)
        {
            _clientBusiness = clientBusiness;
        }

        /// <summary>
        /// Orquestra a inserção de um novo cliente
        /// </summary>
        /// <param name="clientEntity"></param>
        /// <returns></returns>
        public ClientEntity Insert(ClientEntity clientEntity)
        {
            var client = _clientBusiness.Insert(clientEntity);
            return client;
        }

        /// <summary>
        /// Obtem cliente através do númeor de cpf
        /// </summary>
        /// <param name="socialNumber"></param>
        /// <returns></returns>
        public ClientEntity GetBySocialNumber(string socialNumber)
        {
            var client = _clientBusiness.GetBySocialNumber(socialNumber);

            return client;
        }

        /// <summary>
        /// Obtem todos os clientes cadastrados
        /// </summary>
        /// <returns></returns>
        public List<ClientEntity> GetAll()
        {
            var clients = _clientBusiness.GetAll();
            return clients;
        }
    }
}