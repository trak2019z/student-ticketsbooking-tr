using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microservices.Booking.BussinessLogic.Models;
using Microsoft.Extensions.Options;

namespace Microservices.Booking.BussinessLogic.Services.MoviePremieresReader
{
    internal sealed class MoviePremieresTheMovieDbMovieReaderService : IMoviePremieresReaderService<TheMovieDbMovie>
    {
        private readonly TheMovieDbApiSettings _apiSettings;
        private readonly IFlurlClientFactory _httpClient;


        public MoviePremieresTheMovieDbMovieReaderService(IFlurlClientFactory httpClient,
            IOptions<TheMovieDbApiSettings> options)
        {
            _httpClient = httpClient;
            _apiSettings = options.Value;
        }

        public async Task<IEnumerable<TheMovieDbMovie>> GetMoviesAsync()
        {
            var httpClient = _httpClient.Get(_apiSettings.Url);
            var response = await httpClient
                .Request(_apiSettings.Url)
                .SetQueryParam("Apikey", _apiSettings.ApiKey)
                .GetJsonAsync<IEnumerable<TheMovieDbMovie>>();

            return response;
        }
    }
}