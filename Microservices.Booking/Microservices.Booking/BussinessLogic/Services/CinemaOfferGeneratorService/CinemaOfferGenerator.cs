using Microservices.Booking.BussinessLogic.Services.MoviePremieresReader;

namespace Microservices.Booking.BussinessLogic.Services.CinemaOfferGeneratorService
{
    public interface ICinemaOfferGeneratorService
    {
        
    }

    internal sealed class CinemaOfferGenerator: ICinemaOfferGeneratorService
    {
        private readonly IMoviePremieresReaderService _moviePremieresReaderService;

        public CinemaOfferGenerator(IMoviePremieresReaderService moviePremieresReaderService)
        {
            _moviePremieresReaderService = moviePremieresReaderService;
        }
    }
}
