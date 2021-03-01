using System;
using System.Diagnostics;
using FluentAssertions;
using FluentAssertions.Extensions;
using Kalendra.Time.Domain;
using NUnit.Framework;

namespace Kalendra.Time.Tests.Editor
{
    public class TimeStopwatchTests
    {
        [Test]
        public void Elapsed_IsZero_ByDefault()
        {
            var sut = new TimeStopwatch();

            var result = sut.Elapsed;

            result.Should().Be(TimeSpan.Zero);
        }
        
        [Test]
        public void Elapsed_Stores_AllInjections()
        {
            var sut = new TimeStopwatch();
            
            sut.InjectTime(1.Hours());
            sut.InjectTime(1.Seconds());
            var result = sut.Elapsed;

            result.Should().Be(1.Hours().And(1.Seconds()));
        }
    }
}