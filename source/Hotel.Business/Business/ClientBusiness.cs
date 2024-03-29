﻿using System.Collections.Generic;
using System.Linq;
using Hotel.Business.Interfaces;
using Hotel.Domain.Models;
using Hotel.Repository.Interfaces;

namespace Hotel.Business.Business
{
    /// <summary>
    /// Classe onde se encontra toda a regra de negócio de cliente.
    /// </summary>
    public class ClientBusiness : IClientBusiness
    {
        private readonly IRepository<ClientEntity> _clientRepository;
        public ClientBusiness(IRepository<ClientEntity> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        /// <summary>
        /// Responsável por inserir um novo cliente
        /// </summary>
        /// <param name="clientEntity"></param>
        /// <returns></returns>
        public ClientEntity Insert(ClientEntity clientEntity)
        {
            var clientList = ClientExists(clientEntity);
            if (clientList != null) return clientList;

            _clientRepository.Insert(clientEntity);
            return clientEntity;
        }

        /// <summary>
        /// Verifica se o cliente já está cadastrado na base de dados
        /// </summary>
        /// <param name="clientEntity"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Obter cliente pelo número do cpf
        /// </summary>
        /// <param name="socialNumber"></param>
        /// <returns></returns>
        public ClientEntity GetBySocialNumber(string socialNumber)
        {
            var clientList = _clientRepository.Find(x => x.SocialNumber.Contains(socialNumber));
            if (clientList.Any()) return clientList.First();

            var client = new ClientEntity();
            client.Validations.Add("Client not found");

            return client;
        }

        /// <summary>
        /// Obter todos os clientes cadastrados
        /// </summary>
        /// <returns></returns>
        public List<ClientEntity> GetAll()
        {
            return _clientRepository.GetAll();
        }
    }
}
