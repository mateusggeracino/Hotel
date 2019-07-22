using System;
using System.Linq;
using Hotel.Domain.Models;

namespace Hotel.Application.Views.Client
{
    /// <summary>
    /// Classe concreta que herda de View. Responsável por interagir com o usuário no módulo de cliente.
    /// </summary>
    public class ClientView : View
    {
        /// <summary>
        /// Interagi com o usuário, para que o mesmo possa inserir um novo cliente.
        /// </summary>
        private void Insert()
        {
            var client = new ClientEntity();
            CleanScreen();
            Message("Add Client");
            Message("-------------");

            Message("Name: ");
            client.Name = GetInput();

            Message("Social Number: ");
            client.SocialNumber = GetInput();

            Message("Email: ");
            client.Email = GetInput();

            Message("Phone: ");
            client.Phone = GetInput();

            var clientEntity = ClientServices.Insert(client);
            PrintErrors(clientEntity.Validations);
        }

        /// <summary>
        /// Interagi com o usuário durante a consulta de um cliente.
        /// </summary>
        private void Consult()
        {
            CleanScreen();
            Message("Enter social number");
            var socialNumber = GetInput();
            CleanScreen();

            var client = ClientServices.GetBySocialNumber(socialNumber);
            if (client.Validations.Any())
            {
                PrintErrors(client.Validations);
                return;
            }
            ShowClient(client);
            PressToContinue();
        }

        /// <summary>
        /// Imprimi as informações de um cliente
        /// </summary>
        /// <param name="client"></param>
        private void ShowClient(ClientEntity client)
        {
            Message($"Name: {client.Name}");
            Message($"Social Number: {client.SocialNumber}");
            Message($"Email: {client.Email}");
            Message($"Phone: {client.Phone}");
            Message("-------------");
        }

        /// <summary>
        /// Obtém todos os clientes cadastrados
        /// </summary>
        private void GetAll()
        {
            CleanScreen();
            var clients = ClientServices.GetAll();

            foreach(var client in clients) ShowClient(client);
            PressToContinue();
        }

        /// <summary>
        /// Responsável por interagir com o usuário na decisão de acesso ao módulo de cliente.
        /// </summary>
        public void OptionsClient()
        {
            var result = false;
            do
            {
                CleanScreen();
                ShowMenuClient();
                var option = Convert.ToInt32(GetInput());

                switch (option)
                {
                    case 1:
                        Insert();
                        break;
                    case 2:
                        Consult();
                        break;
                    case 3:
                        GetAll();
                        break;
                    case 4:
                        result = true;
                        break;
                }
            } while (!result);
        }

        /// <summary>
        /// Imprimi método de interação com o usuário.
        /// </summary>
        private void ShowMenuClient()
        {
            Message("Select a option");
            Message("-------------");
            Message("1 - Add a new client");
            Message("2 - Consult client");
            Message("3 - Get all");
            Message("4 - Back");
        }
    }
}