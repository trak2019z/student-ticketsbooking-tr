using System.Collections.Generic;
using System.Threading.Tasks;
using Microservices.Booking.BussinessLogic.Queries.GetMovieShowsForCinemaAndTimePeriod;
using Microservices.Booking.Domain.Entities;
using Microservices.Booking.Domain.ValueObjects;
using Microservices.Common.Dispatchers;
using Microservices.Common.Mvc.Middleware;
using Microservices.Common.Types;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
namespace Microservices.Booking.Web.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    [SwaggerTag("Controller to handle actions associated with movie projections")]
    [ApiController]
    public class MovieProjectionsController : BaseController
    {

        public MovieProjectionsController(IDispatcher dispatcher) : base(dispatcher)
        {

        }

        /// <summary>
        /// Returns list of movie shows for specified cinema and time period
        /// </summary>
        /// <param name="query.Cinema">City of requested cinema offer generation</param>
        /// <param name="StartDate">StartDate of requested cinema offer generation</param>
        /// <param name="EndDate">EndDate of requested cinema offer generation</param>
        /// <param name="query"></param>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">List of shows returned</response>
        /// <response code="400">Request has missing/invalid values</response>
        /// <response code="500">Oops! Can't return list of shows right now. Server error</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MovieShows>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<ActionResult<PagedResult<MovieShow>>> GetMovieShowsForSpecifiedCinemaAndTimePeriod(
            [FromQuery] GetMovieShowsForCinemaAndTimePeriodQuery query)
            => Collection(await QueryAsync<GetMovieShowsForCinemaAndTimePeriodQuery, PagedResult<MovieShow>>(query));
    }
}