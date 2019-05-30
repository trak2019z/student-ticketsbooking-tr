namespace Microservices.Booking.BussinessLogic.Services.MoviePremieresReader.Settings
{
    public class OMDbMovieAPISettings
    {
        public OMDbMovieAPISettings()
        {
        }

        public OMDbMovieAPISettings(string url, string apiKey)
        {
            Url = url;
            ApiKey = apiKey;
        }

        public string Url { get; }
        public string ApiKey { get; }
    }
}