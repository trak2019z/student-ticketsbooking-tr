using JetBrains.Annotations;
using Microservices.Booking.Domain.Entities;
using Microservices.Common.Types;

namespace Microservices.Booking.BussinessLogic.Queries.GetMovieShowsForCinemaAndTimePeriod
{
    [UsedImplicitly]
    internal sealed class GetMovieShowsForCinemaAndTimePeriodQuery : IQuery<PagedResult<MovieShows>>
    {
        public string Cinema { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }
    }
}
