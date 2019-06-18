using System.Collections.Generic;
using Microservices.Booking.BussinessLogic.Models;
using Microservices.Common.Utils;

namespace Microservices.Booking.BussinessLogic.Mappers
{
    internal sealed class TheMovieDbResponseDtoTheMovieDbMovieObjectMapper : IMapper<TheMovieDbResponseDto, IEnumerable<TheMovieDbMovieObject>>
    {
        public IEnumerable<TheMovieDbMovieObject> Map(TheMovieDbResponseDto obj)
        {
            return obj.results;
        }
    }
}
