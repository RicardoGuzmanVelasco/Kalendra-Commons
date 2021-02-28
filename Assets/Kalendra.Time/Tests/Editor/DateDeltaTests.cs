using System;
using FluentAssertions;
using FluentAssertions.Extensions;
using Kalendra.Time.Domain;
using NUnit.Framework;

namespace Kalendra.Time.Tests.Editor
{
    public class DateDeltaTests
    {
        [Test]
        public void Delta_IsZero_ByDefault()
        {
            var sut = new DateDelta();

            var resultDelta = sut.Delta;

            resultDelta.Should().Be(TimeSpan.Zero);
        }
        
        [Test]
        public void TotalDelta_IsZero_ByDefault()
        {
            var sut = new DateDelta();

            var resultDelta = sut.TotalDelta;

            resultDelta.Should().Be(TimeSpan.Zero);
        }

        [Test]
        public void DeltaIsZero_AfterZeroInjection()
        {
            var sut = new DateDelta();

            sut.InjectTime(TimeSpan.Zero);
            var resultDelta = sut.Delta;

            resultDelta.Should().Be(TimeSpan.Zero);
        }

        [Test]
        public void DeltaIsPositive_AfterPositiveInjection()
        {
            var sut = new DateDelta();
            
            sut.InjectTime(TimeSpan.FromTicks(1));
            var resultDelta = sut.Delta;

            resultDelta.Should().BeGreaterThan(TimeSpan.Zero);
        }
        
        [Test]
        public void TotalDeltaIsPositive_AfterPositiveInjection()
        {
            var sut = new DateDelta();
            
            sut.InjectTime(TimeSpan.FromTicks(1));
            var resultDelta = sut.TotalDelta;

            resultDelta.Should().BeGreaterThan(TimeSpan.Zero);
        }
        
        [Test]
        public void Delta_IsEqualsTo_LastInjection()
        {
            var expectedDelta = 10.Hours().And(3.Minutes());
            var sut = new DateDelta(DateTime.MinValue, DateTime.MinValue + 2.Days());
            
            sut.InjectTime(expectedDelta);
            var resultDelta = sut.Delta;

            resultDelta.Should().Be(expectedDelta);
        }
    }
}