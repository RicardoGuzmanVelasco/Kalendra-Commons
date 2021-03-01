using System;
using FluentAssertions;
using Kalendra.BoardCore.Tests;
using Kalendra.Time.Domain;
using NSubstitute;
using NUnit.Framework;

namespace Kalendra.Time.Tests.Editor
{
    public class TimeCounterTests
    {
        [Test]
        public void Period_IfNegative_ThrowsException()
        {
            ITimeCounter sut;
            
            Action act = () => sut = new Counter(-1);

            act.Should().ThrowExactly<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Period_IfZero_NeverProducesBeat()
        {
            var mockListener = Substitute.For<IEventListenerMock>();
            var sut = new Counter(0);

            sut.Beat += mockListener.Called;
            sut.InjectTime(TimeSpan.MaxValue);
            
            mockListener.DidNotReceive().Called();
        }

        [Test]
        public void Beat_IsCalled_ByFrequency_AfterInjection()
        {
            var mockListener = Substitute.For<IEventListenerMock>();
            var sut = new Counter(0);

            sut.Beat += mockListener.Called;
            sut.InjectTime(TimeSpan.MaxValue);
            
            mockListener.DidNotReceive().Called();
        }
        
        [Theory, TestCase(0.999f), TestCase(1.001f), TestCase(1.5f), TestCase(99.999f)]
        public void Beat_IsCalled_ByFrequency_AfterInjection(float secondsToInject)
        {
            var mockListener = Substitute.For<IEventListenerMock>();
            var sut = new Counter(1);

            sut.Beat += mockListener.Called;
            sut.InjectTime(TimeSpan.FromSeconds(secondsToInject));
            
            mockListener.Received((int)secondsToInject).Called();
        }
    }
}