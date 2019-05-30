using System.Threading.Tasks;

namespace Microservices.Booking.BussinessLogic.Services.MoviePremieresReader
{
    public interface IMovieApiCaller<TRootObject>
    {
        Task<TRootObject> GetMoviesAsync();
    }
}