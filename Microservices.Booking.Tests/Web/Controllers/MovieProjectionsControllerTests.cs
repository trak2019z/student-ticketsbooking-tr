using System;
using System.Threading.Tasks;
using Flurl.Http;
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
            var token = "XXX";
            // Act
            var flurlClient=new FlurlClient("localhost");
            var response = await flurlClient
                .Request($"v1/Booking")
                .SetQueryParam("Cinema", "Rzeszów")
                .SetQueryParam("StartDate", DateTime.MinValue)
                .SetQueryParam("EndDate", DateTime.MaxValue)
                .WithOAuthBearerToken(token)
                .GetJsonAsync<object>();

            // Assert
            response.ShouldNotBeNull();
        }
    }
}
