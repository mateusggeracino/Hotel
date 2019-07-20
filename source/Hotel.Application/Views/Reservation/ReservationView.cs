using System;
using Hotel.Business.Business;
using Hotel.Services;

namespace Hotel.Application.Views.Reservation
{
    public class ReservationView : View
    {
        private readonly ReservationServices _reservationServices;
        public ReservationView()
        {
            _reservationServices = new ReservationServices(new ReservationBusiness(), new ClientBusiness(), new RoomBusiness());
        }

        public void OptionsReservation()
        {
            var result = false;
            do
            {
                CleanScreen();
                Message("Select a option");
                Message("-------------");
                Message("1 - Add a new reservation");
                Message("2 - Consult reservation");
                Message("3 - Sair");
                var option = Convert.ToInt32(GetInput());

                switch (option)
                {
                    case 1:
                        Insert();
                        break;
                    //case 2:
                    //    Consult();
                    //    break;
                    case 3:
                        result = true;
                        break;
                }
            } while (!result);
        }

        private void Insert()
        {
            CleanScreen();
            Message("Add Reservation");
            Message("-------------");
            Message("Enter social number");
            var socialNumber = GetInput();
            Message("Enter room id");
            var roomId = Convert.ToInt32(GetInput());
            Message("Enter days");
            var days = Convert.ToInt32(GetInput());

            var reservation = _reservationServices.Insert(socialNumber, roomId, days);
            PrintErrors(reservation.Client.Validations);
            PrintErrors(reservation.Room.Validations);
            PressToContinue();
        }
    }
}