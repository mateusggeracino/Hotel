using Hotel.Business.Interfaces;
using Hotel.Domain.Models;
using Hotel.Repository.Repository;
using System;

namespace Hotel.Business.Business
{
    public class ReservationBusiness : IReservationBusiness
    {
        private readonly ClientRepository _clientRepository;
        private readonly RoomRepository _roomRepository;
        private readonly ReservationRepository _reservationRepository;

         public ReservationBusiness()
        {
            _clientRepository = new ClientRepository();
            _roomRepository = new RoomRepository();
            _reservationRepository = new ReservationRepository();
        }

        public ReservationEntity Insert(ReservationEntity reservation)
        {
            var client = _clientRepository.GetBySocialNumber(reservation.Client.SocialNumber);
            var room = _roomRepository.GetById(reservation.Room.Id);

            reservation.Client = client;
            reservation.Room = room;
            reservation.TimeStart = DateTime.Now;
            reservation.TimeEnd = DateTime.Now.AddDays(reservation.Days);

            return _reservationRepository.Insert(reservation);
        }
    }
}
