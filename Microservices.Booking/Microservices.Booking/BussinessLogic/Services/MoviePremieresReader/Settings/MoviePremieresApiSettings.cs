namespace Microservices.Booking.BussinessLogic.Services.MoviePremieresReader.Settings
{
    public class MoviePremieresApiSettings
    {
        public MoviePremieresApiSettings()
        {
        }

        public MoviePremieresApiSettings(string url, string apiKey)
        {
            Url = url;
            ApiKey = apiKey;
        }

        public string Url { get; }
        public string ApiKey { get; }
    }
}