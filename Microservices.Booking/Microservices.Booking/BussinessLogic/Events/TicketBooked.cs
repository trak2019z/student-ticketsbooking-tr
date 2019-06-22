using System;
using Microservices.Common.Messages;

namespace Microservices.Booking.BussinessLogic.Events
{
    public class TicketBooked : IEvent
    {
        public TicketBooked(Guid movieShowsId, uint row, uint column)
        {
            MovieShowId = movieShowsId;
            Row = row;
            Column = column;
        }

        public Guid MovieShowId { get; }
        public uint Row { get; }
        public uint Column { get; }
    }
}