using System;
using System.Threading.Tasks;
using Microservices.Common.Bus;
using Microservices.Common.Handlers;

namespace Microservices.Booking.BussinessLogic.Commands.BookSeatForMovieShow
{
    internal sealed class BookSeatForMovieShowCommandHandler:ICommandHandler<BookSeatForMovieShowCommand>
    {
        public Task HandleAsync(BookSeatForMovieShowCommand command, ICorrelationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
