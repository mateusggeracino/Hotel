using System;
using Hotel.Application.Views.Client;
using Hotel.Application.Views.Reservation;
using Hotel.Application.Views.Room;
using Hotel.Business.Business;
using Hotel.Services;

namespace Hotel.Application.Views
{
    public class HotelView : View
    {
        private readonly HotelServices _hotelServices;

        public HotelView()
        {
            _hotelServices = new HotelServices(new HotelBusiness());
        }

        public void InitHotel()
        {
            var result = true;
            do
            {
                CleanScreen();
                ShowInfoHotel();

                var client = new ClientView();
                var room = new RoomView();
                var reservation = new ReservationView();

                Message("Select");
                Message("-------------");
                Message("1 - Room");
                Message("2 - Client");
                Message("3 - Reserve");
                Message("4 - Sair");

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
                        reservation.OptionsReservation();
                        break;
                    case 4:
                        result = false;
                        break;
                }
            } while (result);
        }

        private void ShowInfoHotel()
        {
            var infoHotel = _hotelServices.GetInfoHotel();

            Message($"Quantity room: {infoHotel.QuantityRoom}");
            Message($"Quantity room busy: {infoHotel.QuantityRoomBusy}");
            Message($"Quantity room block: {infoHotel.QuantityRoomBlock}");
        }
    }
}