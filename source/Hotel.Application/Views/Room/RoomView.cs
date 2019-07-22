using System;
using System.Linq;
using Hotel.Domain.Models;
using Hotel.Domain.ValueObjects;

namespace Hotel.Application.Views.Room
{
    /// <summary>
    /// Classe concreta que herda de View. Responsável por interagir e transmitir informações ao usuário
    /// </summary>
    public class RoomView : View
    {
        /// <summary>
        /// Imprimi o menu de opções que o usuário pode realizar para o módulo de quartos.
        /// </summary>
        public void OptionsRoom()
        {
            var result = false;
            do
            {
                CleanScreen();
                ShowMenuRoom();
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

        /// <summary>
        /// Imprimi o menu responsável por interagir com o usuário no módulo de quartos.
        /// </summary>
        private void ShowMenuRoom()
        {
            Message("Select a option");
            Message("-------------");
            Message("1 - Add a new room");
            Message("2 - Consult by type");
            Message("3 - Consult by status");
            Message("4 - Update room");
            Message("5 - Back");
        }

        /// <summary>
        /// Interagi com o usuário para inserir um novo quarto.
        /// </summary>
        private void Insert()
        {
            var room = new RoomEntity();

            CleanScreen();
            Message("Add a new room");
            Message("-------------");

            room.Type = SelectRoomType();
            room.Status = SelectRoomStatus();

            var roomEntity = RoomServices.Insert(room);
            PrintErrors(roomEntity.Validations);
        }

        /// <summary>
        /// Interagi com o usuário para que o mesmo selecione o status do quarto
        /// </summary>
        /// <returns>retorna o status do quarto selecionado</returns>
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

        /// <summary>
        /// Interagi com o usuário para que o mesmo selecione o tipo do quarto
        /// </summary>
        /// <returns>retorna o tipo do quarto selecionado</returns>
        private RoomTypeEntity SelectRoomType()
        {
            CleanScreen();
            var roomTypes = RoomServices.GetAllTypes();
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

        /// <summary>
        /// Interagi com o usuário para obter quartos por tipo
        /// </summary>
        private void ConsultByType()
        {
            CleanScreen();
            var roomType = SelectRoomType();

            var rooms = RoomServices.GetByType(roomType);

            foreach (var room in rooms)
            {
                ShowRoom(room);
            }

            PressToContinue();
        }

        /// <summary>
        /// Interagi com o usuário para obter quartos por status
        /// </summary>
        private void ConsultByStatus()
        {
            CleanScreen();
            var roomStatus = SelectRoomStatus();

            var rooms = RoomServices.GetByStatus(roomStatus);

            foreach (var room in rooms)
            {
                ShowRoom(room);
            }

            PressToContinue();
        }

        /// <summary>
        /// Formata a exibição do quarto passado por parâmetro
        /// </summary>
        /// <param name="room"></param>
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