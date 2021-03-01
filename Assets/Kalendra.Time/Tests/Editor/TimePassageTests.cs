using System;
using FluentAssertions;
using FluentAssertions.Extensions;
using Kalendra.BoardCore.Tests;
using Kalendra.Time.Domain;
using NSubstitute;
using NUnit.Framework;

namespace Kalendra.Time.Tests.Editor
{
    public class TimePassageTests
    {
        #region Dates state
        [Test]
        public void Current_IsInitial_ByDefault()
        {
            var sut = new TimePassage(DateTime.MinValue);

            var resultCurrent = sut.CurrentDate;

            resultCurrent.Should().Be(DateTime.MinValue);
        }

        [Test]
        public void Current_IsInitial_AfterInjectZero()
        {
            var sut = new TimePassage(DateTime.MinValue);

            sut.InjectTime(TimeSpan.Zero);
            var resultCurrent = sut.CurrentDate;

            resultCurrent.Should().Be(DateTime.MinValue);
        }
        
        [Test]
        public void Current_IsGreaterThanInitial_AfterInjectTime()
        {
            var sut = new TimePassage(DateTime.MinValue);

            sut.InjectTime(1.Ticks());
            var resultCurrent = sut.CurrentDate;

            resultCurrent.Should().BeAfter(DateTime.MinValue);
        }

        [Test]
        public void Initial_DidNotMutate_AfterInjectTime()
        {
            var sut = new TimePassage(DateTime.MinValue);

            sut.InjectTime(1.Ticks());
            var resultInitial = sut.InitialDate;

            resultInitial.Should().Be(DateTime.MinValue);
        }

        [Test]
        public void TotalElapsedTime_IsZero_ByDefault()
        {
            var sut = new TimePassage(DateTime.MinValue);

            var result = sut.TotalElapsedTime;

            result.Should().Be(TimeSpan.Zero);
        }

        [Test]
        public void TotalElapsedTime_IsDelta_AfterOneInjection()
        {
            var sut = new TimePassage(DateTime.MinValue);

            sut.InjectTime(1.Days());
            var result = sut.TotalElapsedTime;

            result.Should().Be(1.Days());
        }
        
        [Test]
        public void TotalElapsedTime_IsAccDelta_AfterSomeInjections()
        {
            var sut = new TimePassage(DateTime.MinValue);

            sut.InjectTime(1.Days());
            sut.InjectTime(10.Hours());
            sut.InjectTime(30.Minutes());
            var result = sut.TotalElapsedTime;

            result.Should().Be(1.Days().And(10.Hours()).And(30.Minutes()));
        }
        #endregion
        
        #region Events
        [Test]
        public void OnNewSecond_DidNotRaise_AfterInjectLessTime()
        {
            var mockListener = Substitute.For<IEventListenerMock>();
            var sut = new TimePassage(DateTime.MinValue);

            sut.OnNewSecond += mockListener.Call;
            sut.InjectTime(1.Ticks());
            
            mockListener.DidNotReceive().Call();
        }

        [Theory, TestCase(1.5f), TestCase(0.99f), TestCase(1.001f), TestCase(99.999f)]
        public void OnNewSecond_RaisesSameTimesAs_IntSecondsInjected(float secondsToInject)
        {
            var mockListener = Substitute.For<IEventListenerMock>();
            var sut = new TimePassage(DateTime.MinValue);

            sut.OnNewSecond += mockListener.Call;
            sut.InjectTime(TimeSpan.FromSeconds(secondsToInject));
            
            mockListener.Received((int)secondsToInject).Call();
        }

        [Test, Category("TODO")]
        public void OnNewSecond_Called_AfterSeveralInjections()
        {
            return;
            var mockListener = Substitute.For<IEventListenerMock>();
            var sut = new TimePassage(DateTime.MinValue);

            sut.OnNewSecond += mockListener.Call;
            sut.InjectTime(0.6.Seconds());
            sut.InjectTime(0.6.Seconds());
            
            mockListener.Received(1).Call();
        }
        #endregion
    }
}