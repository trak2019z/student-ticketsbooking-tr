namespace Microservices.Booking.BussinessLogic.Services.MoviePremieresReader.Settings
{
    internal sealed class TheMovieDbApiSettings
    {
        public TheMovieDbApiSettings(string url, string apiKey)
        {
            Url = url;
            ApiKey = apiKey;
        }

        public TheMovieDbApiSettings()
        {
        }

        public string Url { get; set; }
        public string ApiKey { get; set; }
        public EndpointSettings Endpoints { get; set; }
    }

    internal sealed class EndpointSettings
    {
        public string NowPlaying { get; set; }
    }
}