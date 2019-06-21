using System;
using Microservices.Booking.Domain.ValueObjects;
using Microservices.Common.Types;

namespace Microservices.Booking.BussinessLogic.Queries.GetMovieShowsForCinemaAndTimePeriod
{
    public class GetMovieShowsForCinemaAndTimePeriodQuery : PagedQueryBase, IQuery<PagedResult<MovieShow>>
    {
        /// <summary>
        /// Cinema location.
        /// </summary>
        /// <example>Warszawa</example>
        public string Cinema { get; set; }
        /// <summary>
        /// Cinema offer date from.
        /// </summary>
        /// <example>11/11/2019</example>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Cinema offer date to.
        /// </summary>
        /// <example>17/11/2019</example>
        public DateTime EndDate { get; set; }
    }
}