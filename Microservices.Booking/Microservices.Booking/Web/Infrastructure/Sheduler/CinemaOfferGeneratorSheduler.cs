using System;
using System.Threading;
using System.Threading.Tasks;
using Microservices.Booking.BussinessLogic.Services.CinemaOfferGeneratorService;
using Microsoft.Extensions.Hosting;

namespace Microservices.Booking.Web.Infrastructure.Sheduler
{
    public class CinemaOfferGeneratorSheduler : IHostedService
    {
        private Timer _timer;
        private readonly ICinemaOfferGenerator _cinemaOfferGenerator;

        public CinemaOfferGeneratorSheduler(ICinemaOfferGenerator cinemaOfferGenerator)
        {
            _cinemaOfferGenerator = cinemaOfferGenerator;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromDays(7));
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        private void DoWork(object state)
        {
            var result =
                _cinemaOfferGenerator.GenerateOfferForSpecifiedTimePeriod(DateTime.Today,
                    DateTime.Today.AddDays(7)).GetAwaiter().GetResult();
        }
    }
}