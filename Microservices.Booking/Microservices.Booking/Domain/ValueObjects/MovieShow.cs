using System;
using System.Collections.Generic;
using Microservices.Common.Types;

namespace Microservices.Booking.Domain.ValueObjects
{
    public class MovieShow : BaseEntity
    {
        public string Cinema { get; private set; }

        public string Movie { get; set; }

        public DateTime PlayDateTime { get; set; }

        public IReadOnlyList<Seat> ReservedSeats;

        public MovieShow(string cinema, string movie, DateTime playDateTime, IReadOnlyList<Seat> reservedSeats)
        {
            Cinema = cinema;
            Movie = movie;
            PlayDateTime = playDateTime;
            ReservedSeats = reservedSeats;
        }
    }
}
