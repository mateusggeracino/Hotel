using System.Linq;
using Hotel.Business.Interfaces;
using Hotel.Domain.Models;

namespace Hotel.Services
{
    public class ReservationServices
    {
        private readonly IReservationBusiness _reservationBusiness;
        private readonly IClientBusiness _clientBusiness;
        private readonly IRoomBusiness _roomBusiness;

        public ReservationServices(IReservationBusiness reservationBusiness, IClientBusiness clientBusiness, IRoomBusiness roomBusiness)
        {
            _reservationBusiness = reservationBusiness;
            _clientBusiness = clientBusiness;
            _roomBusiness = roomBusiness;
        }

        public ReservationEntity Insert(string socialNumber, int roomId, int days)
        {
            var reservationEntity = new ReservationEntity
            {
                Client = _clientBusiness.GetBySocialNumber(socialNumber),
                Room = _roomBusiness.GetById(roomId),
                Days = days
            };

            if (reservationEntity.Client.Validations.Any() || reservationEntity.Room.Validations.Any())
                return reservationEntity;

            var reservation = _reservationBusiness.Insert(reservationEntity);
            return reservation;
        }
    }
}