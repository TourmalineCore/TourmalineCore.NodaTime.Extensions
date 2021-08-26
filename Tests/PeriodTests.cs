using NodaTime;
using Xunit;
using Period = NodaTimeExtensions.Models.Period;

namespace Tests
{
    public class PeriodTests
    {
        private static readonly LocalDate PeriodStartDate = new(2021, 05, 01);
        private static readonly LocalDate PeriodEndDate = new(2021, 05, 31);

        private Period _period = new(PeriodStartDate, PeriodEndDate);

        [Fact]
        public void DateIsBeforeThePeriod_NotContains()
        {
            var date = new LocalDate(2021, 04, 01);

            Assert.False(_period.Include(date));
            Assert.False(_period.Behind(date));
            Assert.True(_period.Before(date));
        }

        [Fact]
        public void DateIsStartDateOfPeriod_Contains()
        {
            Assert.True(_period.Include(PeriodStartDate));
            Assert.False(_period.Behind(PeriodStartDate));
        }

        [Fact]
        public void DateIsEndDateOfPeriod_Contains()
        {
            Assert.True(_period.Include(PeriodEndDate));
            Assert.False(_period.Behind(PeriodEndDate));
        }

        [Fact]
        public void DateIsAfterThePeriod_NotContains()
        {
            var date = new LocalDate(2021, 07, 25);

            Assert.False(_period.Include(date));
            Assert.True(_period.Behind(date));
        }

        [Fact]
        public void PeriodsAreEquals_ReturnTrue()
        {
            var firstPeriod = new Period(new LocalDate(2021, 12, 10), new LocalDate(2021, 12, 12));
            var secondPeriod = new Period(new LocalDate(2021, 12, 10), new LocalDate(2021, 12, 12));

            Assert.True(firstPeriod.Equals(secondPeriod));
            Assert.True(firstPeriod == secondPeriod);
        }

        [Fact]
        public void PeriodAreNotEqualsToObject_ReturnFalse()
        {
            var firstPeriod = new Period(new LocalDate(2021, 12, 10), new LocalDate(2021, 12, 12));
            var randomObj = new object();

            Assert.False(firstPeriod.Equals(randomObj));
        }

        [Fact]
        public void PeriodsAreNotEquals_ReturnFalse()
        {
            var firstPeriod = new Period(new LocalDate(2021, 12, 10), new LocalDate(2021, 12, 12));
            var secondPeriod = new Period(new LocalDate(2021, 12, 10), new LocalDate(2021, 11, 12));

            Assert.False(firstPeriod.Equals(secondPeriod));
            Assert.False(firstPeriod == secondPeriod);
        }

        [Fact]
        public void PeriodsAreNotEquals_ReturnTrue()
        {
            var firstPeriod = new Period(new LocalDate(2021, 12, 10), new LocalDate(2021, 12, 12));
            var secondPeriod = new Period(new LocalDate(2021, 12, 10), new LocalDate(2021, 11, 12));

            Assert.True(firstPeriod != secondPeriod);
        }

        [Fact]
        public void PeriodsHasSimilarHashCode_AreEquals()
        {
            var firstPeriod = new Period(new LocalDate(2021, 12, 10), new LocalDate(2021, 12, 12));
            var secondPeriod = new Period(new LocalDate(2021, 12, 10), new LocalDate(2021, 12, 12));

            Assert.Equal(firstPeriod.GetHashCode(), secondPeriod.GetHashCode());
        }

        [Fact]
        public void PeriodsHasDifferentHashCode_AreNotEquals()
        {
            var firstPeriod = new Period(new LocalDate(2021, 12, 10), new LocalDate(2021, 12, 12));
            var secondPeriod = new Period(new LocalDate(2021, 12, 10), new LocalDate(2021, 11, 12));

            Assert.NotEqual(firstPeriod.GetHashCode(), secondPeriod.GetHashCode());
        }
    }
}