using Hotel.Business.Interfaces;
using Hotel.Domain.Models;
using System;
using Hotel.Domain.ValueObjects;
using Hotel.Repository.Interfaces;
using System.Collections.Generic;

namespace Hotel.Business.Business
{
    /// <summary>
    /// Classe onde se encontra toda regra de negócio da reserva.
    /// </summary>
    public class BookingBusiness : IBookingBusiness
    {
        private readonly IRepository<RoomEntity> _roomRepository;
        private readonly IRepository<BookingEntity> _bookingRepository;

        public BookingBusiness(IRepository<RoomEntity> roomRepository, IRepository<BookingEntity> bookingRepository)
        {
            _roomRepository = roomRepository;
            _bookingRepository = bookingRepository;
        }

        /// <summary>
        /// Método responsável por inserir uma nova reserva e aplicar desconto caso a quantidade de dias seja maior que 5
        /// </summary>
        /// <param name="bookingEntity"></param>
        /// <returns></returns>
        public BookingEntity Insert(BookingEntity bookingEntity)
        {
            if (!BookingIsValid(bookingEntity)) return bookingEntity;

            ConfigDate(bookingEntity);
            ApplyTotal(bookingEntity);

            var booking = _bookingRepository.Insert(bookingEntity);
            UpdateRoom(booking);
            return booking;
        }

        /// <summary>
        /// Configurar as datas de checkin e checkout
        /// </summary>
        /// <param name="bookingEntity"></param>
        private void ConfigDate(BookingEntity bookingEntity)
        {
            var referenceDate = DateTime.Now.Date.Add(new TimeSpan(14, 00, 0));
            bookingEntity.CheckIn = referenceDate;
            bookingEntity.CheckOut = referenceDate.AddDays(bookingEntity.Days);
        }

        /// <summary>
        /// Aplica o valor total
        /// </summary>
        /// <param name="bookingEntity"></param>
        private void ApplyTotal(BookingEntity bookingEntity)
        {
            var roomValue = bookingEntity.Room.Type.Price;
            var valueTotal = roomValue * bookingEntity.Days;

            if (bookingEntity.Days <= 5)
            {
                bookingEntity.Total = valueTotal;
                return;
            }

            Off(bookingEntity, valueTotal);

        }

        /// <summary>
        /// Método que aplica o desconto caso os dias de acomodação seja maior que 5.
        /// </summary>
        /// <param name="bookingEntity"></param>
        /// <param name="valueTotal"></param>
        private void Off(BookingEntity bookingEntity, decimal valueTotal)
        {
            var percentOff = Convert.ToDecimal(0.1);
            bookingEntity.Total -= valueTotal * percentOff;
        }

        /// <summary>
        /// Obter reserva pelo número social do cliente
        /// </summary>
        /// <param name="socialNumber"></param>
        /// <returns></returns>
        public List<BookingEntity> GetBySocialNumber(string socialNumber)
        {
            var booking = _bookingRepository.Find(x => x.Client.SocialNumber.Contains(socialNumber));

            return booking;
        }

        /// <summary>
        /// Verifica se há uma mensagem de erro para cliente e quarto antes de inseri-lo.
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Atualiza status do quarto para Ocupado. Caso a reserva tenha sido efetuada com sucesso.
        /// </summary>
        /// <param name="booking"></param>
        private void UpdateRoom(BookingEntity booking)
        {
            booking.Room.Status = RoomStatus.Busy;
            _roomRepository.Update(booking.Room);
        }
    }
}
