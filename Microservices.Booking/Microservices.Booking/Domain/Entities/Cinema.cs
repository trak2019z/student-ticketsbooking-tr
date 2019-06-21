using System;
using System.Collections.Generic;
using Microservices.Common.Types;

namespace Microservices.Booking.Domain.Entities
{
    public class Cinema : BaseEntity
    {
        public Cinema(Guid id) : base(id)
        {
        }
        public string City { get; set; }
        public uint Rows { get; set; }
        public uint Columns { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public IEnumerable<double> MovieShowHours { get; set; }
    }
}