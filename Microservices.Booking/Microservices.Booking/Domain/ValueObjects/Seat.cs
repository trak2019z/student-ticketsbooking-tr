using Microservices.Common.Types;

namespace Microservices.Booking.Domain.ValueObjects
{
    public sealed class Seat : ValueObject<Seat>
    {
        public Seat(uint row, uint column)
        {
            this.Row = row;
            this.Column = column;
        }

        public uint Row { get; set; }

        public uint Column { get; set; }

        protected override bool EqualsCore(Seat other)
        {
            return Row == other.Row &&
                   Column == other.Column;
        }

        protected override int GetHashCodeCore()
        {
            return Row.GetHashCode() + Column.GetHashCode();
        }
    }
}