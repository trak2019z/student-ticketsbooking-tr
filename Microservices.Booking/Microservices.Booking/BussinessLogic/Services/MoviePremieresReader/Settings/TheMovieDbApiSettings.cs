namespace Microservices.Booking.BussinessLogic.Services.MoviePremieresReader
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

        public string Url { get; }
        public string ApiKey { get; }
    }
}