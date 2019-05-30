using System.Collections.Generic;
using Microservices.Common.Types;

namespace Microservices.Booking.Domain.ValueObjects
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public uint Rows { get; set; }
        public uint Columns { get; set; }
        public IEnumerable<double> MovieShowHours { get; set; }
    }
}