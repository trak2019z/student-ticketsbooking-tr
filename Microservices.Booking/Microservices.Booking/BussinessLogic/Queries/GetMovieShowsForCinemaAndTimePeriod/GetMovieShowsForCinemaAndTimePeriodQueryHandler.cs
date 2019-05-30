using System;
using System.Threading.Tasks;
using Microservices.Booking.Domain.Entities;
using Microservices.Common.Handlers;
using Microservices.Common.Mongo;
using Microservices.Common.Types;

namespace Microservices.Booking.BussinessLogic.Queries.GetMovieShowsForCinemaAndTimePeriod
{
    internal sealed class GetMovieShowsForCinemaAndTimePeriodQueryHandler : IQueryHandler<GetMovieShowsForCinemaAndTimePeriodQuery, PagedResult<MovieShows>>
    {
        private readonly IMongoRepository<MovieShows> _mongoRepository;

        public GetMovieShowsForCinemaAndTimePeriodQueryHandler(IMongoRepository<MovieShows> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public Task<PagedResult<MovieShows>> HandleAsync(GetMovieShowsForCinemaAndTimePeriodQuery query)
        {
            throw new NotImplementedException();
        }
    }
}