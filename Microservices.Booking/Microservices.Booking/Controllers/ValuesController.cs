<<<<<<< Updated upstream:Microservices.Booking/Microservices.Booking/Controllers/ValuesController.cs
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
=======
﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microservices.Booking.BussinessLogic.Models;
using Microservices.Booking.BussinessLogic.Services.MoviePremieresReader;
using Microservices.Common.Dispatchers;
using Microservices.Common.Mvc.Middleware;
>>>>>>> Stashed changes:Microservices.Booking/Microservices.Booking/Web/Controllers/ValuesController.cs
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Booking.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMoviePremieresReaderService<TheMovieDbMovie> _moviePremieresReaderService;
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
<<<<<<< Updated upstream:Microservices.Booking/Microservices.Booking/Controllers/ValuesController.cs
            return new string[] { "value1", "value2" };
=======
            var a = await _moviePremieresReaderService.GetMoviesAsync();
            return new[] { "value1", "value2" };
>>>>>>> Stashed changes:Microservices.Booking/Microservices.Booking/Web/Controllers/ValuesController.cs
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
<<<<<<< Updated upstream:Microservices.Booking/Microservices.Booking/Controllers/ValuesController.cs
=======

        public ValuesController(IDispatcher dispatcher, IMoviePremieresReaderService<TheMovieDbMovie> moviePremieresReaderService) : base(dispatcher)
        {
            _moviePremieresReaderService = moviePremieresReaderService;
        }
>>>>>>> Stashed changes:Microservices.Booking/Microservices.Booking/Web/Controllers/ValuesController.cs
    }
}
