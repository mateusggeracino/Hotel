using Hotel.Business.Interfaces;
using Hotel.Domain.Models;
using System;
using Hotel.Domain.ValueObjects;
using Hotel.Repository.Interfaces;

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
            if(BookingIsValid(bookingEntity) == null) return bookingEntity;

            bookingEntity.CheckIn = DateTime.Now;
            bookingEntity.CheckOut = DateTime.Now.AddDays(bookingEntity.Days);
            var booking = _bookingRepository.Insert(bookingEntity);

            UpdateRoom(booking);
            return booking;
        }

        private BookingEntity BookingIsValid(BookingEntity booking)
        {
            if (string.IsNullOrEmpty(booking.Client.SocialNumber))
            {
                booking.Client.Validations.Add("Client not found");
                return booking;
            }
            else if (booking.Room.Key == Guid.Empty)
            {
                booking.Room.Validations.Add("Room not found");
                return booking;
            }

            return null;
        }

        private void UpdateRoom(BookingEntity booking)
        {
            booking.Room.Status = RoomStatus.Busy;
            _roomRepository.Update(booking.Room);
        }
    }
}
