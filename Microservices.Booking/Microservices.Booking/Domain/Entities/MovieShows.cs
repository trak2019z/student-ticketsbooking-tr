using System.Collections.Generic;
using Microservices.Booking.Domain.ValueObjects;
using Microservices.Common.Types;

namespace Microservices.Booking.Domain.Entities
{
    public class MovieShows : AggregateId
    {
        public string City { get; set; }

        public IReadOnlyList<MovieShow> Shows { get; set; }

        public MovieShows()
        {

        }
    }
}
