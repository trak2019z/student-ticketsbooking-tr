using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microservices.Booking.BussinessLogic.Services.MoviePremieresReader.Settings;
using Microservices.Booking.Domain.Entities;
using Microsoft.Extensions.Options;

namespace Microservices.Booking.BussinessLogic.Services.MoviePremieresReader
{
    internal sealed class MoviePremieresOMDBReaderService: IMoviePremieresReaderService<OMDBMovie>
    {
        private readonly IFlurlClientFactory _httpClient;
        private readonly OMDbMovieAPISettings _apiSettings;


        public MoviePremieresOMDBReaderService(IFlurlClientFactory httpClient, IOptions<OMDbMovieAPISettings> options)
        {
            _httpClient = httpClient;
            _apiSettings = options.Value;
        }

        public async Task<IEnumerable<OMDBMovie>> GetMoviesAsync()
        {
            var httpClient = _httpClient.Get(_apiSettings.Url);
            var response = await httpClient
                .Request(_apiSettings.Url)
                .SetQueryParam("Apikey", _apiSettings.ApiKey)
                .GetJsonAsync<IEnumerable<OMDBMovie>>();

            return response;
        }
    }
}
