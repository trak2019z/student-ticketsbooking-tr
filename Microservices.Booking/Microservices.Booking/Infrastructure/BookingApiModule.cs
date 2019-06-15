using Autofac;
using Flurl.Http.Configuration;

namespace Microservices.Booking.Infrastructure
{
    public class BookingApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            RegisterExternalComponents(builder);
        }

        private static void RegisterExternalComponents(ContainerBuilder builder)
        {
            builder.RegisterType<PerBaseUrlFlurlClientFactory>().As<IFlurlClientFactory>();
        }

    }

}
