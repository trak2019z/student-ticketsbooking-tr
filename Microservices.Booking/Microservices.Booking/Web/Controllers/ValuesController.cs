using System.Collections.Generic;
using System.Threading.Tasks;
using Microservices.Booking.BussinessLogic.Models;
using Microservices.Booking.BussinessLogic.Services.MoviePremieresReader;
using Microservices.Common.Dispatchers;
using Microservices.Common.Mvc.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Booking.Web.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ValuesController : BaseController
    {
        private readonly IMoviePremieresReaderService<TheMovieDbMovie> _moviePremieresReaderService;
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var a = await _moviePremieresReaderService.GetMoviesAsync();
            return new[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public ValuesController(IDispatcher dispatcher, IMoviePremieresReaderService<TheMovieDbMovie> moviePremieresReaderService) : base(dispatcher)
        {
            _moviePremieresReaderService = moviePremieresReaderService;
        }
    }
}
