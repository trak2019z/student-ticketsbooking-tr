using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using Microservices.Booking.BussinessLogic.Commands.BookSeatForMovieShow;
using Microservices.Booking.Domain.ValueObjects;
using Microservices.Booking.Tests.Infrastructure;
using Shouldly;
using Xunit;
using Xunit.Categories;

namespace Microservices.Booking.Tests.Web.Controllers
{
    public class MovieProjectionsControllerTests : BaseIntegrationTest
    {

        [Fact]
        [IntegrationTest]
        public async Task GetMovieProjectionsForSpecifiedCinemaAndPeriod()
        {
            // Act
            var flurlClient = new FlurlClient("http://localhost:59298");
            var response1 = await flurlClient
                .Request("/Tickets")
                .GetAsync();


            var response2 = await flurlClient
                .Request("/api/MovieProjections")
                .SetQueryParam("Cinema", "Warszawa")
                .SetQueryParam("StartDate", DateTime.Today)
                .SetQueryParam("EndDate", DateTime.Today.AddDays(7))
                .GetJsonAsync<IEnumerable<MovieShow>>();

            // ReSharper disable once PossibleMultipleEnumeration
            var movieShowIdentifier = response2.First().Id;
            await "http://localhost:59298/MovieProjections".PostJsonAsync(new BookSeatForMovieShowCommand
            {
                MovieShowsId = movieShowIdentifier,
                Row = 12,
                Column = 19
            }
            );


            var response3 = await flurlClient
                .Request("/MovieProjections")
                .SetQueryParam("Cinema", "Warszawa")
                .SetQueryParam("StartDate", DateTime.Today)
                .SetQueryParam("EndDate", DateTime.Today.AddDays(7))
                .GetJsonAsync<IEnumerable<MovieShow>>();
            var returnedElement = response2.First(movieShow => movieShow.Id == movieShowIdentifier);

            // Assert
            returnedElement.ShouldNotBeNull();
            returnedElement.ReservedSeats.ShouldContain(x => x.Column == 19);
            returnedElement.ReservedSeats.ShouldContain(x => x.Row == 12);

            ClearMongoDb();

        }
    }
}
