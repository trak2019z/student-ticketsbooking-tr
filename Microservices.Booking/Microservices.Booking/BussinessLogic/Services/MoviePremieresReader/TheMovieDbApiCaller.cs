using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microservices.Booking.BussinessLogic.Models;
using Microservices.Booking.BussinessLogic.Services.MoviePremieresReader.Settings;
using Microsoft.Extensions.Options;

namespace Microservices.Booking.BussinessLogic.Services.MoviePremieresReader
{
    internal sealed class TheMovieDbApiCaller : IMovieApiCaller<TheMovieDbResponseDto>
    {
        private readonly TheMovieDbApiSettings _apiSettings;
        private readonly IFlurlClientFactory _httpClient;


        public TheMovieDbApiCaller(IFlurlClientFactory httpClient,
            IOptions<TheMovieDbApiSettings> options)
        {
            _httpClient = httpClient;
            _apiSettings = options.Value;
        }

        public async Task<TheMovieDbResponseDto> GetMoviesAsync()
        {
            var httpClient = _httpClient.Get(_apiSettings.Url);
            var response = await httpClient
                .Request($"{_apiSettings.Url}{_apiSettings.Endpoints.NowPlaying}")
                .SetQueryParam("api_key", _apiSettings.ApiKey)
                .GetJsonAsync<TheMovieDbResponseDto>();

            return response;
        }
    }
}