using FluentValidation;

namespace Microservices.Booking.BussinessLogic.Queries.GetMovieShowsForCinemaAndTimePeriod
{
    public class GetMovieShowsForCinemaAndTimePeriodQueryValidator : AbstractValidator<GetMovieShowsForCinemaAndTimePeriodQuery>
    {
        public GetMovieShowsForCinemaAndTimePeriodQueryValidator()
        {
            RuleFor(x => x.Cinema).NotNull().NotEmpty();
            RuleFor(x => x.StartDate).NotNull().NotEmpty();
            RuleFor(x => x.EndDate).NotNull().NotEmpty();
        }
    }
}