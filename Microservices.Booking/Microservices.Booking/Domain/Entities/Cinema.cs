using System;
using Microservices.Common.Types;

namespace Microservices.Booking.Domain.Entities
{
    public class Cinema : BaseEntity
    {
        public Cinema(Guid id) : base(id)
        {
        }
    }
}
