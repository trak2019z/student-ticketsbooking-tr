using FluentValidation;

namespace Microservices.Booking.BussinessLogic.Commands.BookSeatForMovieShow
{
    public class BookSeatForMovieShowCommandValidator : AbstractValidator<BookSeatForMovieShowCommand>
    {
        public BookSeatForMovieShowCommandValidator()
        {
            RuleFor(x => x.MovieShowsId).NotNull().NotEmpty();
            RuleFor(x => x.Column).NotNull().NotEmpty();
            RuleFor(x => x.Row).NotNull().NotEmpty();
           
        }
    }
}