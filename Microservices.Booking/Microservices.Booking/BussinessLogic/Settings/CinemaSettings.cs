using System.Collections.Generic;

namespace Microservices.Booking.BussinessLogic.Settings
{
    public class CinemasSettings
    {
        public List<CinemaSettings> Cinemas { get; set; }
    }
    public class CinemaSettings
    {
        public string City { get; set; }
        public uint Rows { get; set; }
        public uint Columns { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<string> MovieShowHours { get; set; }
    }
}