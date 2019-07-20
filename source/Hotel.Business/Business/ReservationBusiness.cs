using Hotel.Business.Interfaces;
using Hotel.Domain.Models;
using Hotel.Repository.Repository;
using System;
using Hotel.Domain.ValueObjects;
using Hotel.Repository.Interfaces;

namespace Hotel.Business.Business
{
    public class ReservationBusiness : IReservationBusiness
    {
        private readonly IRepository<ClientEntity> _clientRepository;
        private readonly IRepository<RoomEntity> _roomRepository;
        private readonly IRepository<ReservationEntity> _reservationRepository;

         public ReservationBusiness()
        {
            _clientRepository = new Repository<ClientEntity>();
            _roomRepository = new Repository<RoomEntity>();
            _reservationRepository = new Repository<ReservationEntity>();
        }

        public ReservationEntity Insert(ReservationEntity reservation)
        {
            if (!string.IsNullOrEmpty(reservation.Client.SocialNumber))
            {
                reservation.Client.Validations.Add("Client not found");
                return reservation;
            }else if (reservation.Room.Key == Guid.Empty)
            {
                reservation.Room.Validations.Add("Room not found");
                return reservation;
            }

            reservation.TimeStart = DateTime.Now;
            reservation.TimeEnd = DateTime.Now.AddDays(reservation.Days);
            var reserve = _reservationRepository.Insert(reservation);

            reserve.Room.Status = RoomStatus.Block;
            _roomRepository.Update(reserve.Room);
            return reserve;
        }
    }
}
