﻿using System;
using System.Collections.Generic;
using Microservices.Common.Types;

namespace Microservices.Booking.Domain.ValueObjects
{
    public class MovieShow : BaseEntity
    {
        public IReadOnlyList<Seat> ReservedSeats;

        public MovieShow(string cinema, string movie, DateTime playDateTime, IReadOnlyList<Seat> reservedSeats)
        {
            Cinema = cinema;
            Movie = movie;
            PlayDateTime = playDateTime;
            ReservedSeats = reservedSeats;
        }

        public string Cinema { get; }

        public string Movie { get; set; }

        public DateTime PlayDateTime { get; set; }
    }
}