using System.Linq;
using System.Threading.Tasks;
using Microservices.Booking.Domain.Entities;
using Microservices.Booking.Domain.ValueObjects;
using Microservices.Common.Handlers;
using Microservices.Common.Mongo;
using Microservices.Common.Types;

namespace Microservices.Booking.BussinessLogic.Queries.GetMovieShowsForCinemaAndTimePeriod
{
    internal sealed class
        GetMovieShowsForCinemaAndTimePeriodQueryHandler : IQueryHandler<GetMovieShowsForCinemaAndTimePeriodQuery,
            PagedResult<MovieShow>>
    {
        private readonly IMongoRepository<MovieShows> _movieShowsRepository;

        public GetMovieShowsForCinemaAndTimePeriodQueryHandler(IMongoRepository<MovieShows> movieShowsRepository)
        {
            _movieShowsRepository = movieShowsRepository;
        }

        public async Task<PagedResult<MovieShow>> HandleAsync(GetMovieShowsForCinemaAndTimePeriodQuery query)
        {
            var shows = await _movieShowsRepository.BrowseAsync(exp =>
                exp.City == query.Cinema && exp.Shows.Any(it =>
                    it.PlayDateTime >= query.StartDate && it.PlayDateTime <= query.EndDate), query);
            var prefilteredShowsForSpecifiedCityAndPeriod = shows.Items.Select(it => it.Shows).SelectMany(x => x).ToList();
            var filteredShowsForSpecifiedTimeAndPeriod = prefilteredShowsForSpecifiedCityAndPeriod.Where(mov =>
                mov.PlayDateTime >= query.StartDate && mov.PlayDateTime <= query.EndDate);
            var result = PagedResult<MovieShow>.Create(filteredShowsForSpecifiedTimeAndPeriod, 1, int.MaxValue, 1, 100);

            return result;
        }
    }
}