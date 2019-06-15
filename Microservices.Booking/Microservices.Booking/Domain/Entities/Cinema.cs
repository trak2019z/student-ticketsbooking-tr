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
        public string Name { get; set; }
        public uint Rows { get; set; }
        public uint Columns { get; set; }
        public IEnumerable<double> MovieShowHours { get; set; }
    }
}