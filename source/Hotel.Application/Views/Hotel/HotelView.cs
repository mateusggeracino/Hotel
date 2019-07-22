using System;
using Hotel.Application.Views.Client;
using Hotel.Application.Views.Booking;
using Hotel.Application.Views.Room;

namespace Hotel.Application.Views.Hotel
{
    /// <summary>
    /// Classe concreta que herda de View. Responsável por interagir com o usuário e prover resultados informações as camadas inferiores.
    /// </summary>
    public class HotelView : View
    {
        /// <summary>
        /// Reponsável por inicializar o Hotel
        /// </summary>
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

        /// <summary>
        /// Imprimi o menu de interação com o usuário
        /// </summary>
        private void ShowMenu()
        {
            Message("Select");
            Message("-------------");
            Message("1 - Room");
            Message("2 - Client");
            Message("3 - Booking");
            Message("4 - Exit");
        }

        /// <summary>
        /// Formata a impressão das informações do Hotel
        /// </summary>
        private void ShowInfoHotel()
        {
            var infoHotel = HotelServices.GetInfoHotel();

            Message($"Quantity room: {infoHotel.QuantityRoom}");
            Message($"Quantity room busy: {infoHotel.QuantityRoomBusy}");
            Message($"Quantity room block: {infoHotel.QuantityRoomBlock}");
            Message("");
        }
    }
}