using Hotel.Business.Interfaces;
using Hotel.Domain.Models;
using System;
using Hotel.Domain.ValueObjects;
using Hotel.Repository.Interfaces;
using System.Collections.Generic;

namespace Hotel.Business.Business
{
    public class BookingBusiness : IBookingBusiness
    {
        private readonly IRepository<RoomEntity> _roomRepository;
        private readonly IRepository<BookingEntity> _bookingRepository;

         public BookingBusiness(IRepository<RoomEntity> roomRepository, IRepository<BookingEntity> bookingRepository)
         {
             _roomRepository = roomRepository;
            _bookingRepository = bookingRepository;
        }

        public BookingEntity Insert(BookingEntity bookingEntity)
        {
            if(!BookingIsValid(bookingEntity)) return bookingEntity;

            var referenceDate = DateTime.Now.Date.Add(new TimeSpan(14, 00, 0));

            bookingEntity.CheckIn = referenceDate;
            bookingEntity.CheckOut = referenceDate.AddDays(bookingEntity.Days);

            bookingEntity.Total = GetTotal(bookingEntity);
            var booking = _bookingRepository.Insert(bookingEntity);

            UpdateRoom(booking);
            return booking;
        }

        private decimal GetTotal(BookingEntity bookingEntity)
        {
            var roomValue = bookingEntity.Room.Type.Price;
            var valueTotal = roomValue * bookingEntity.Days;

            if (bookingEntity.Days > 5) return valueTotal -= valueTotal*Convert.ToDecimal(0.1);

            return valueTotal;
        }

        public List<BookingEntity> GetBySocialNumber(string socialNumber)
        {
            var booking = _bookingRepository.Find(x => x.Client.SocialNumber.Contains(socialNumber));

            return booking;
        }

        private bool BookingIsValid(BookingEntity booking)
        {
            if (string.IsNullOrEmpty(booking.Client.SocialNumber))
            {
                booking.Client.Validations.Add("Client not found");
                return false;
            }
            else if (booking.Room.Key == Guid.Empty)
            {
                booking.Room.Validations.Add("Room not found");
                return false;
            }

            return true;
        }

        private void UpdateRoom(BookingEntity booking)
        {
            booking.Room.Status = RoomStatus.Busy;
            _roomRepository.Update(booking.Room);
        }
    }
}
