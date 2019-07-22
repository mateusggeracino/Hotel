using Hotel.Business.Business;
using Hotel.Domain.Models;
using Hotel.Repository.Repository;
using Hotel.Services;
using System;
using System.Collections.Generic;

namespace Hotel.Application.Views
{
    /// <summary>
    /// Classe abstrata responsável por prover as instâncias da ferramenta e a utilização de métodos genéricos para a View
    /// </summary>
    public abstract class View
    {
        protected readonly Repository<ClientEntity> ClientRepository;
        protected readonly Repository<RoomEntity> RoomRepository;
        protected readonly Repository<BookingEntity> BookingRepository;

        protected readonly ClientBusiness ClientBusiness;
        protected readonly RoomBusiness RoomBusiness;
        protected readonly BookingBusiness BookingBusiness;
        protected readonly HotelBusiness HotelBusiness;
        protected readonly BookingServices BookingServices;
        protected readonly RoomServices RoomServices;
        protected readonly ClientServices ClientServices;
        protected readonly HotelServices HotelServices;

        protected View()
        {
            ClientRepository = new Repository<ClientEntity>();
            RoomRepository = new Repository<RoomEntity>();
            BookingRepository = new Repository<BookingEntity>();
            ClientBusiness = new ClientBusiness(ClientRepository);
            RoomBusiness = new RoomBusiness(RoomRepository);
            HotelBusiness = new HotelBusiness(RoomRepository);
            BookingBusiness = new BookingBusiness(RoomRepository, BookingRepository);
            BookingServices = new BookingServices(BookingBusiness, ClientBusiness, RoomBusiness);
            RoomServices = new RoomServices(RoomBusiness);
            ClientServices = new ClientServices(ClientBusiness);
            HotelServices = new HotelServices(HotelBusiness);
        }

        /// <summary>
        /// Limpa a tela do console.
        /// </summary>
        public void CleanScreen()
        {
            Console.Clear();
        }

        /// <summary>
        /// Imprimi mensagem no console passado por parâmetro.
        /// </summary>
        /// <param name="message"></param>
        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Espera o usuário digitar algum valor e transmite a quem o chamou
        /// </summary>
        /// <returns></returns>
        public string GetInput()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Espera o usuário apertar qualquer tecla para continuar.
        /// </summary>
        public void PressToContinue()
        {
            Message("Press any key to continue");
            Console.ReadKey();
        }

        /// <summary>
        /// Imprimi os erros que são adicionados na camada da business
        /// </summary>
        /// <param name="errors"></param>
        public void PrintErrors(List<string> errors)
        {
            foreach (var erro in errors)
            {
                Message(erro);
            }
        }
    }
}