using System;
using Hotel.Business.Business;
using Hotel.Domain.Models;
using Hotel.Repository.Repository;
using Hotel.Services;

namespace Hotel.Application.Views.Booking
{
    public class BookingView : View
    {
        private readonly BookingServices _bookingServices;
        public BookingView()
        {
            _bookingServices = new BookingServices(new BookingBusiness(new Repository<RoomEntity>(), new Repository<BookingEntity>())
                                                                                   , new ClientBusiness(new Repository<ClientEntity>())
                                                                                   , new RoomBusiness(new Repository<RoomEntity>()));
        }

        public void OptionsBooking()
        {
            var result = false;
            do
            {
                CleanScreen();
                Message("Select a option");
                Message("-------------");
                Message("1 - Add a new Booking");
                Message("2 - Consult Booking");
                Message("3 - Sair");
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
                        result = true;
                        break;
                }
            } while (!result);
        }

        private void Consult()
        {
            var result = true;
            do
            {
                CleanScreen();
                Message("Select a option");
                Message("-------------");
                Message("1 - Get by Social Number");
                Message("2 - Get by Room Id");
                Message("3 - Sair");
                var option = Convert.ToInt32(GetInput());

                switch (option)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        result = false;
                        break;
                }
            } while (result);
        }

        private void Insert()
        {
            CleanScreen();
            Message("Add Booking");
            Message("-------------");
            Message("Enter social number");
            var socialNumber = GetInput();
            Message("Enter room id");
            var roomId = Convert.ToInt32(GetInput());
            Message("Enter days");
            var days = Convert.ToInt32(GetInput());

            var booking = _bookingServices.Insert(socialNumber, roomId, days);
            PrintErrors(booking.Client.Validations);
            PrintErrors(booking.Room.Validations);
            PressToContinue();
        }
    }
}