using System;
using System.Threading.Tasks;
using Microservices.Booking.BussinessLogic.Commands.BookSeatForMovieShow;
using Microservices.Booking.BussinessLogic.Events;
using Microservices.Booking.BussinessLogic.Services.CinemaOfferGeneratorService;
using Microservices.Common.Bus;
using Microservices.Common.Dispatchers;
using Microservices.Common.Mvc.Middleware;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Microservices.Booking.Web.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    [SwaggerTag("Controller to handle actions associated with tickets")]
    [ApiController]
    public class TicketsController : BaseController
    {
        private readonly ICinemaOfferGenerator _cinemaOfferGenerator;
        private readonly ICorrelationContext _context;

        public TicketsController(IDispatcher dispatcher, IBusPublisher busPublisher, ICinemaOfferGenerator cinemaOfferGenerator) : base(dispatcher, busPublisher)
        {
            _cinemaOfferGenerator = cinemaOfferGenerator;
            _context = new CorrelationContext();
        }

        [HttpGet]
        public async Task<IActionResult> GenerateCinemaOffer()
        {
            await _cinemaOfferGenerator.GenerateOfferForSpecifiedTimePeriod(DateTime.Now.AddDays(-7), DateTime.Now);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> BookTicket([FromBody] BookSeatForMovieShowCommand command)
        {
            var result = await SendAsync(command);
            // TODO : Extend bus publisher to 'fire and wait for response' method instead of fire and forget
            var @event = new TicketBooked(command.MovieShowsId, command.Row, command.Column);
            await BusPublisher.PublishAsync(@event, _context);

            return Ok();
        }

    }
}
