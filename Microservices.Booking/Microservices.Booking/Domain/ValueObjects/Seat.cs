using Microservices.Common.Types;

namespace Microservices.Booking.Domain.ValueObjects
{
    public sealed class Seat : ValueObject<Seat>
    {
        public MovieShow MovieShow { get; set; }

        public uint Row { get; set; }

        public uint Column { get; set; }

        protected override bool EqualsCore(Seat other)
        {
            return MovieShow == other.MovieShow &&
                   Row == other.Row &&
                   Column == other.Column;
        }

        protected override int GetHashCodeCore()
        {
            return MovieShow.GetHashCode() + Row.GetHashCode() + Column.GetHashCode();
        }
    }
}