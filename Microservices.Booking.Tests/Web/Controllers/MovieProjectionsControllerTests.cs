using System;
using System.Threading.Tasks;
using Flurl.Http;
using Microservices.Booking.Domain.Entities;
using Shouldly;
using Xunit;
using Xunit.Categories;

namespace Microservices.Booking.Tests.Web.Controllers
{
    public class MovieProjectionsControllerTests
    {
        [Fact]
        [IntegrationTest]
        public async Task GetMovieProjectionsForSpecifiedCinemaAndPeriod()
        {
            // Arrange
            const string token = "XXX";
            // Act
            var flurlClient=new FlurlClient("http://localhost:59298");
            var response = await flurlClient
                .Request("/Tickets")
                .SetQueryParam("Cinema", "Warszawa")
                .SetQueryParam("StartDate", DateTime.MinValue.Date)
                .SetQueryParam("EndDate", DateTime.MaxValue.Date)
                .WithOAuthBearerToken(token)
                .GetJsonAsync<MovieShows>();

            // Assert
            response.ShouldNotBeNull();
        }
    }
}
