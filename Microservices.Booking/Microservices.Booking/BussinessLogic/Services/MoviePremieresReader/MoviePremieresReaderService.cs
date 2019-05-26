using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microservices.Booking.BussinessLogic.Services.MoviePremieresReader.Settings;
using Microservices.Booking.Domain.Entities;
using Microsoft.Extensions.Options;

namespace Microservices.Booking.BussinessLogic.Services.MoviePremieresReader
{
    public interface IMoviePremieresReaderService
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
    }
    internal sealed class MoviePremieresReaderService: IMoviePremieresReaderService
    {
        private readonly IFlurlClientFactory _httpClient;
        private readonly MoviePremieresApiSettings _apiSettings;


        public MoviePremieresReaderService(IFlurlClientFactory httpClient, IOptions<MoviePremieresApiSettings> options)
        {
            _httpClient = httpClient;
            _apiSettings = options.Value;
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            var httpClient = _httpClient.Get(_apiSettings.Url);
            var response = await httpClient
                .Request(_apiSettings.Url)
                .SetQueryParam("Apikey", _apiSettings.ApiKey)
                .GetJsonAsync<IEnumerable<Movie>>();

            return response;
        }
    }
}
