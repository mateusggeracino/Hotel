using System;
using System.Collections.Generic;
using System.Linq;
using Hotel.Business.Business;
using Hotel.Domain.Models;
using Hotel.Repository.Repository;
using Hotel.Services;

namespace Hotel.Application.Views.Client
{


    public class ClientView : View
    {
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

            var clientEntity = clientServices.Insert(client);
            PrintErrors(clientEntity.Validations);
        }

        private void Consult()
        {
            CleanScreen();
            Message("Enter social number");
            var socialNumber = GetInput();
            CleanScreen();

            var client = clientServices.GetBySocialNumber(socialNumber);
            if (client.Validations.Any())
            {
                PrintErrors(client.Validations);
                return;
            }
            ShowClient(client);
            PressToContinue();
        }

        private void ShowClient(ClientEntity client)
        {
            Message($"Name: {client.Name}");
            Message($"Social Number: {client.SocialNumber}");
            Message($"Email: {client.Email}");
            Message($"Phone: {client.Phone}");
            Message("-------------");
        }

        private void GetAll()
        {
            CleanScreen();
            var clients = clientServices.GetAll();

            foreach(var client in clients) ShowClient(client);
            PressToContinue();
        }

        public void OptionsClient()
        {
            var result = false;
            do
            {
                CleanScreen();
                Message("Select a option");
                Message("-------------");
                Message("1 - Add a new client");
                Message("2 - Consult client");
                Message("3 - Get all");
                Message("4 - Back");
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
    }
}