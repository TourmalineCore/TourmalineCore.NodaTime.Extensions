using System;
using NodaTime;

namespace NodaTimeExtensions.Models
{
    public struct Period : IEquatable<Period>
    {
        private LocalDate StartDate { get; }

        private LocalDate EndDate { get; }

        public Period(LocalDate startDate, LocalDate endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public bool Include(LocalDate date)
        {
            return date >= StartDate && date <= EndDate;
        }

        public bool Behind(LocalDate date)
        {
            return EndDate < date;
        }

        public bool Before(LocalDate date)
        {
            return StartDate > date;
        }

        public bool Equals(Period other)
        {
            return StartDate.Equals(other.StartDate)
                   && EndDate.Equals(other.EndDate);
        }

        public override bool Equals(object obj)
        {
            return obj is Period other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (StartDate.GetHashCode() * 397) ^ EndDate.GetHashCode();
            }
        }

        public static bool operator ==(Period left, Period right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Period left, Period right)
        {
            return !left.Equals(right);
        }
    }
}