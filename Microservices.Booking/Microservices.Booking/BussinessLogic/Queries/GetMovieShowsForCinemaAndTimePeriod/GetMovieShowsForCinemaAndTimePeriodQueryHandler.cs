using System;
using System.Threading.Tasks;
using Microservices.Booking.Domain.Entities;
using Microservices.Common.Handlers;
using Microservices.Common.Types;

namespace Microservices.Booking.BussinessLogic.Queries.GetMovieShowsForCinemaAndTimePeriod
{
    internal sealed class
        GetMovieShowsForCinemaAndTimePeriodQueryHandler : IQueryHandler<GetMovieShowsForCinemaAndTimePeriodQuery,
            PagedResult<MovieShows>>
    {
        public Task<PagedResult<MovieShows>> HandleAsync(GetMovieShowsForCinemaAndTimePeriodQuery query)
        {
            throw new NotImplementedException();
        }
    }
}