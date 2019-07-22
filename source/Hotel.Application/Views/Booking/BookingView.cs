using System;
using Hotel.Domain.Models;

namespace Hotel.Application.Views.Booking
{
    public class BookingView : View
    {
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
                Message("3 - Back");
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
            CleanScreen();
            Message("Enter Social Number: ");
            var socialNumber = GetInput();

            var bookings = bookingServices.GetBySocialNumber(socialNumber);
            CleanScreen();

            foreach (var booking in bookings)
            {
                ShowBooking(booking);
            }

            PressToContinue();
        }

        private void ShowBooking(BookingEntity booking)
        {
            Message($"--    Client    --");
            Message("");
            Message($"Social Number: {booking.Client.SocialNumber}");
            Message($"Name: {booking.Client.Name}");
            Message("");
            Message($"--    Room    --");
            Message($"Id: {booking.Room.Id}");
            Message($"Type: {booking.Room.Type.RoomType}");
            Message($"Status: {booking.Room.Status}");
            Message("");
            Message($"--    Info. Booking    --");
            Message($"CheckIn: {booking.CheckIn}");
            Message($"CheckOut: {booking.CheckOut}");
            Message($"Total: {booking.Total}");
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

            var booking = bookingServices.Insert(socialNumber, roomId, days);
            PrintErrors(booking.Client.Validations);
            PrintErrors(booking.Room.Validations);
            PressToContinue();
        }
    }
}