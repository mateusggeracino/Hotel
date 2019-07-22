using System;
using System.Collections.Generic;
using System.Linq;
using Hotel.Business.Interfaces;
using Hotel.Domain.Models;

namespace Hotel.Services
{
    public class BookingServices
    {
        private readonly IBookingBusiness _bookingBusiness;
        private readonly IClientBusiness _clientBusiness;
        private readonly IRoomBusiness _roomBusiness;

        public BookingServices(IBookingBusiness bookingBusiness, IClientBusiness clientBusiness, IRoomBusiness roomBusiness)
        {
            _bookingBusiness = bookingBusiness;
            _clientBusiness = clientBusiness;
            _roomBusiness = roomBusiness;
        }

        public BookingEntity Insert(string socialNumber, int roomId, int days)
        {
            var bookingEntity = new BookingEntity
            {
                Client = _clientBusiness.GetBySocialNumber(socialNumber),
                Room = _roomBusiness.GetById(roomId),
                Days = days
            };

            if (bookingEntity.Client.Validations.Any() || bookingEntity.Room.Validations.Any())
                return bookingEntity;

            var booking = _bookingBusiness.Insert(bookingEntity);
            return booking;
        }

        public List<BookingEntity> GetBySocialNumber(string socialNumber)
        {
            return _bookingBusiness.GetBySocialNumber(socialNumber);
        }
    }
}