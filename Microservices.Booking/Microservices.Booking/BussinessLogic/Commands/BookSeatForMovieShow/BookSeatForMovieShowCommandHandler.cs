using System;
using System.Linq;
using System.Threading.Tasks;
using Microservices.Booking.Domain.Entities;
using Microservices.Booking.Domain.ValueObjects;
using Microservices.Common.Bus;
using Microservices.Common.Handlers;
using Microservices.Common.Mongo;
using MongoDB.Driver;

namespace Microservices.Booking.BussinessLogic.Commands.BookSeatForMovieShow
{
    public sealed class BookSeatForMovieShowCommandHandler : ICommandHandler<BookSeatForMovieShowCommand>
    {
        private readonly IMongoRepository<MovieShows> _movieShowsRepository;

        public BookSeatForMovieShowCommandHandler(IMongoRepository<MovieShows> movieShowsRepository)
        {
            _movieShowsRepository = movieShowsRepository;
        }

        private const int NonExistingElementIndex = -1;
        public async Task HandleAsync(BookSeatForMovieShowCommand command, ICorrelationContext context)
        {
            await InsertCinemaSeatBooking(command);
        }

        private async Task<UpdateResult> InsertCinemaSeatBooking(BookSeatForMovieShowCommand request)
        {
            var filter =
                Builders<MovieShows>.Filter.ElemMatch(processMappings => processMappings.Shows,
                    Builders<MovieShow>.Filter.Eq(attributeMapping => attributeMapping.Id, request.MovieShowsId));

            var update = Builders<MovieShows>.Update.AddToSet(
                processMappings => processMappings.Shows.ElementAt(NonExistingElementIndex).ReservedSeats,
                new Seat(request.Row, request.Column));

            return await _movieShowsRepository.UpdateEntityPartAsync(filter, update);
        }
    }
}