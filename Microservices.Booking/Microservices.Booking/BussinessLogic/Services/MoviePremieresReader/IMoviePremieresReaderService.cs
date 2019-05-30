using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.Booking.BussinessLogic.Services.MoviePremieresReader
{
    public interface IMoviePremieresReaderService<TheMovieDbMovie>
    {
        Task<IEnumerable<TheMovieDbMovie>> GetMoviesAsync();
    }
}
