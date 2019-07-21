using System;
using Hotel.Application.Views.Client;
using Hotel.Application.Views.Booking;
using Hotel.Application.Views.Room;
using Hotel.Business.Business;
using Hotel.Domain.Models;
using Hotel.Repository.Repository;
using Hotel.Services;

namespace Hotel.Application.Views.Hotel
{
    public class HotelView : View
    {
        public void InitHotel()
        {
            var result = true;
            do
            {
                CleanScreen();
                ShowInfoHotel();

                var client = new ClientView();
                var room = new RoomView();
                var booking = new BookingView();

                ShowMenu();

                var option = Convert.ToInt32(GetInput());
                switch (option)
                {
                    case 1:
                        room.OptionsRoom();
                        break;
                    case 2:
                        client.OptionsClient();
                        break;
                    case 3:
                        booking.OptionsBooking();
                        break;
                    case 4:
                        result = false;
                        break;
                }
            } while (result);
        }
        private void ShowMenu()
        {
            Message("Select");
            Message("-------------");
            Message("1 - Room");
            Message("2 - Client");
            Message("3 - Booking");
            Message("4 - Sair");
        }
        private void ShowInfoHotel()
        {
            var infoHotel = hotelServices.GetInfoHotel();

            Message($"Quantity room: {infoHotel.QuantityRoom}");
            Message($"Quantity room busy: {infoHotel.QuantityRoomBusy}");
            Message($"Quantity room block: {infoHotel.QuantityRoomBlock}");
        }
    }
}