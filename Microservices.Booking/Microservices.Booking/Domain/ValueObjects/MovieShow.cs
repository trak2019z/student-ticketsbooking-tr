using System;
using System.Collections.Generic;
using Microservices.Common.Types;

namespace Microservices.Booking.Domain.ValueObjects
{
    public class MovieShow : BaseEntity
    {
        public IReadOnlyList<Seat> ReservedSeats;

        public MovieShow(string movie, DateTime playDateTime, IReadOnlyList<Seat> reservedSeats, string posterUrl)
        {
            Movie = movie;
            PlayDateTime = playDateTime;
            ReservedSeats = reservedSeats;
            PosterUrl = posterUrl;
        }
        public string PosterUrl { get; set; }

        public string Movie { get; set; }

        public DateTime PlayDateTime { get; set; }
    }
}