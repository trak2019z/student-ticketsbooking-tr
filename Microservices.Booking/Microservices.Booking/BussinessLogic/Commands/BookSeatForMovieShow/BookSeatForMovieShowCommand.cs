using System;
using Microservices.Common.Messages;

namespace Microservices.Booking.BussinessLogic.Commands.BookSeatForMovieShow
{
    public class BookSeatForMovieShowCommand : ICommand
    {
        public Guid MovieShowsId { get; set; }
        public uint Row { get; set; }
        public uint Column { get; set; }
    }
}