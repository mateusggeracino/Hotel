using System;
using System.Linq;
using Hotel.Domain.Models;
using Hotel.Domain.ValueObjects;

namespace Hotel.Application.Views.Room
{
    public class RoomView : View
    {
        public void OptionsRoom()
        {
            var result = false;
            do
            {
                CleanScreen();
                Message("Select a option");
                Message("-------------");
                Message("1 - Add a new room");
                Message("2 - Consult by type");
                Message("3 - Consult by status");
                Message("4 - Update room");
                Message("5 - Back");
                var option = Convert.ToInt32(GetInput());

                switch (option)
                {
                    case 1:
                        Insert();
                        break;
                    case 2:
                        ConsultByType();
                        break;
                    case 3:
                        ConsultByStatus();
                        break;
                    case 4:
                        result = true;
                        break;
                    case 5:
                        result = true;
                        break;
                }
            } while (!result);
        }

        private void Insert()
        {
            var room = new RoomEntity();

            CleanScreen();
            Message("Add a new room");
            Message("-------------");

            room.Type = SelectRoomType();
            room.Status = SelectRoomStatus();

            var roomEntity = roomServices.Insert(room);
            PrintErrors(roomEntity.Validations);
        }

        private RoomStatus SelectRoomStatus()
        {
            CleanScreen();
            Message("Select a room type");
            Message("-------------");
            Message("1 - Open");
            Message("2 - Block");
            var option = Convert.ToInt32(GetInput());
            switch (option)
            {
                case 1:
                    return RoomStatus.Open;
                case 2:
                    return RoomStatus.Lock;
                default:
                    return RoomStatus.Open;
            }
        }

        private RoomTypeEntity SelectRoomType()
        {
            CleanScreen();
            var roomTypes = roomServices.GetAllTypes();
            CleanScreen();
            Message("Select a room type");
            Message("-------------");
            foreach (var room in roomTypes)
            {
                Message($"{room.Id} - {room.RoomType}");
            }

            var option = Convert.ToInt32(GetInput());

            return roomTypes.FirstOrDefault(x => x.Id ==  option);
        }

        private void ConsultByType()
        {
            CleanScreen();
            var roomType = SelectRoomType();

            var rooms = roomServices.GetByType(roomType);

            foreach (var room in rooms)
            {
                ShowRoom(room);
            }

            PressToContinue();
        }

        private void ConsultByStatus()
        {
            CleanScreen();
            var roomStatus = SelectRoomStatus();

            var rooms = roomServices.GetByStatus(roomStatus);

            foreach (var room in rooms)
            {
                ShowRoom(room);
            }

            PressToContinue();
        }

        private void ShowRoom(RoomEntity room)
        {
            Message($"Room Id: {room.Id}");
            Message($"Room Type: {room.Type.RoomType}");
            Message($"Room Status: {room.Status}");
            Message($"Room Price: {room.Type.Price}");
            
            Message("-------------");
        }
    }
}