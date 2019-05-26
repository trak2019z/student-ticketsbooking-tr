using System.Threading.Tasks;
using Microservices.Booking.BussinessLogic.Queries.GetMovieShowsForCinemaAndTimePeriod;
using Microservices.Booking.Domain.Entities;
using Microservices.Common.Dispatchers;
using Microservices.Common.Mvc.Middleware;
using Microservices.Common.Types;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Booking.Web.Controllers
{
    [Route("[controller]")]
    public class TicketsController : BaseController
    {
        public TicketsController(IDispatcher dispatcher) : base(dispatcher)
        {

        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<MovieShows>>> GetMovieShowsForSpecifiedCinemaAndTimePeriod(
            [FromQuery] GetMovieShowsForCinemaAndTimePeriodQuery query)
            => Collection(await QueryAsync<GetMovieShowsForCinemaAndTimePeriodQuery, PagedResult<MovieShows>>(query));
    }
}
