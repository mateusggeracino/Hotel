using Hotel.Business.Business;
using Hotel.Domain.Models;
using Hotel.Repository.Repository;
using Hotel.Services;
using System;
using System.Collections.Generic;

namespace Hotel.Application.Views
{
    public abstract class View
    {
        protected readonly Repository<ClientEntity> clientRepository;
        protected readonly Repository<RoomEntity> roomRepository;
        protected readonly Repository<BookingEntity> bookingRepository;

        protected readonly ClientBusiness clientBusiness;
        protected readonly RoomBusiness roomBusiness;
        protected readonly BookingBusiness bookingBusiness;
        protected readonly HotelBusiness hotelBusiness;
        protected readonly BookingServices bookingServices;
        protected readonly RoomServices roomServices;
        protected readonly ClientServices clientServices;
        protected readonly HotelServices hotelServices;

        protected View()
        {
            clientRepository = new Repository<ClientEntity>();
            roomRepository = new Repository<RoomEntity>();
            bookingRepository = new Repository<BookingEntity>();
            clientBusiness = new ClientBusiness(clientRepository);
            roomBusiness = new RoomBusiness(roomRepository);
            hotelBusiness = new HotelBusiness(roomRepository);
            bookingBusiness = new BookingBusiness(roomRepository, bookingRepository);
            bookingServices = new BookingServices(bookingBusiness, clientBusiness, roomBusiness);
            roomServices = new RoomServices(roomBusiness);
            clientServices = new ClientServices(clientBusiness);
            hotelServices = new HotelServices(hotelBusiness);
        }

        public void CleanScreen()
        {
            Console.Clear();
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void PressToContinue()
        {
            Message("Press any key to continue");
            Console.ReadKey();
        }

        public void PrintErrors(List<string> errors)
        {
            foreach (var erro in errors)
            {
                Message(erro);
            }
        }
    }
}