using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservices.Booking.BussinessLogic.Models;
using Microservices.Booking.BussinessLogic.Services.MoviePremieresReader;
using Microservices.Booking.BussinessLogic.Settings;
using Microservices.Booking.Domain.Entities;
using Microservices.Booking.Domain.ValueObjects;
using Microservices.Common.Mongo;
using Microservices.Common.Utils;
using Microsoft.Extensions.Options;

namespace Microservices.Booking.BussinessLogic.Services.CinemaOfferGeneratorService
{
    public interface ICinemaOfferGenerator
    {
        Task<bool> GenerateOfferForSpecifiedTimePeriod(DateTime start, DateTime end, string city = null);
    }

    internal sealed class CinemaOfferGenerator : ICinemaOfferGenerator
    {
        private readonly IMovieApiCaller<TheMovieDbResponseDto> _apiCaller;
        private readonly IMapper<TheMovieDbResponseDto, IEnumerable<TheMovieDbMovieObject>> _mapper;
        private readonly IMongoRepository<MovieShows> _movieShowsRepository;
        private readonly CinemasSettings _cinemasSettings;


        public CinemaOfferGenerator(
            IMovieApiCaller<TheMovieDbResponseDto> apiCaller,
            IMongoRepository<MovieShows> mongoRepository,
            IMapper<TheMovieDbResponseDto,
            IEnumerable<TheMovieDbMovieObject>> mapper,
            IOptions<CinemasSettings> cinemasSettings)
        {
            _apiCaller = apiCaller;
            _movieShowsRepository = mongoRepository;
            _mapper = mapper;
            _cinemasSettings = cinemasSettings.Value;
        }
        public async Task<bool> GenerateOfferForSpecifiedTimePeriod(DateTime start, DateTime end, string city = null)
        {
            var response = await _apiCaller.GetMoviesAsync();
            var movies = _mapper.Map(response);
            movies = movies.OrderByDescending(item => item.popularity).Take(4);
            var ran = new Random();
            var theMovieDbMovieObjects = movies.ToList();
            var cinemas = city == null
                ? _cinemasSettings.Cinemas
                : _cinemasSettings.Cinemas.Where(
                    it => it.City.Equals(city, StringComparison.InvariantCultureIgnoreCase));

            foreach (var cinema in cinemas)
            {
                var movieShows = new List<MovieShow>();
                for (var date = start; end.CompareTo(date) > 0; date = date.AddDays(1.0))
                {
                    foreach (var showHours in cinema.MovieShowHours)
                    {
                        var hour = double.Parse(showHours.Split(":")[0]);
                        var movie = theMovieDbMovieObjects.OrderBy(x => ran.Next()).First();
                        movieShows.Add(new MovieShow(movie.title, date.Date.AddHours(hour), new List<Seat>(),
                            movie.poster_path));
                    }
                }

                await _movieShowsRepository.AddAsync(new MovieShows() { City = cinema.City, Shows = movieShows });
            }

            return true;
        }
    }
}