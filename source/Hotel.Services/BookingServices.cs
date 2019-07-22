using System.Collections.Generic;
using System.Linq;
using Hotel.Business.Interfaces;
using Hotel.Domain.Models;

namespace Hotel.Services
{
    /// <summary>
    /// Classe concreta responsável por orquestrar os métodos da reserva
    /// </summary>
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

        /// <summary>
        /// Método responsável por orquestrar as funções de inserção de uma nova reserva
        /// </summary>
        /// <param name="socialNumber">Número do cpf</param>
        /// <param name="roomId">Número do quarto</param>
        /// <param name="days">Dias de hospedagem</param>
        /// <returns></returns>
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

        /// <summary>
        /// Obtem reserva através do número do cpf do cliente
        /// </summary>
        /// <param name="socialNumber"></param>
        /// <returns></returns>
        public List<BookingEntity> GetBySocialNumber(string socialNumber)
        {
            return _bookingBusiness.GetBySocialNumber(socialNumber);
        }
    }
}