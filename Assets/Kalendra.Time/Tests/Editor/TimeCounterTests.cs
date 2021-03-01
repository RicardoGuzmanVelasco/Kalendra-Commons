using System;
using FluentAssertions;
using FluentAssertions.Extensions;
using Kalendra.BoardCore.Tests;
using Kalendra.Time.Domain;
using NSubstitute;
using NUnit.Framework;

namespace Kalendra.Time.Tests.Editor
{
    public class BeatCounterTests
    {
        #region Period
        [Test]
        public void Period_IfNegative_ThrowsException()
        {
            IBeatCounter sut;
            
            Action act = () => sut = new Counter(-1);

            act.Should().ThrowExactly<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Period_IfZero_NeverProducesBeat()
        {
            var mockListener = Substitute.For<IEventListenerMock>();
            var sut = new Counter(0);

            sut.OnBeat += mockListener.Call;
            sut.InjectTime(TimeSpan.MaxValue);
            
            mockListener.DidNotReceive().Call();
        }
        #endregion

        #region Beat
        [Test]
        public void Beat_IsCalled_ByFrequency_AfterInjection()
        {
            var mockListener = Substitute.For<IEventListenerMock>();
            var sut = new Counter(0);

            sut.OnBeat += mockListener.Call;
            sut.InjectTime(TimeSpan.MaxValue);
            
            mockListener.DidNotReceive().Call();
        }
        
        [Theory, TestCase(0.999f), TestCase(1.001f), TestCase(1.5f), TestCase(99.999f)]
        public void Beat_IsCalled_ByFrequency_AfterInjection(float secondsToInject)
        {
            var mockListener = Substitute.For<IEventListenerMock>();
            var sut = new Counter(1);

            sut.OnBeat += mockListener.Call;
            sut.InjectTime(TimeSpan.FromSeconds(secondsToInject));
            
            mockListener.Received((int)secondsToInject).Call();
        }
        #endregion
        
        #region Paused/Stop
        [Test]
        public void Paused_ThenInjectionDoesNotProduceBeat()
        {
            var mockListener = Substitute.For<IEventListenerMock>();
            var sut = new Counter();
            sut.OnBeat += mockListener.Call;

            sut.Paused = true;
            sut.InjectTime(1.Seconds());
            
            mockListener.DidNotReceive().Call();
        }
        
        [Test]
        public void Paused_ThenUnpaused_InjectionDidNotCount()
        {
            var mockListener = Substitute.For<IEventListenerMock>();
            var sut = new Counter();
            sut.OnBeat += mockListener.Call;

            sut.Paused = true;
            sut.InjectTime(0.9.Seconds());
            sut.Paused = false;
            sut.InjectTime(0.9.Seconds());
            
            mockListener.DidNotReceive().Call();
        }
        
        [Test]
        public void Stop_ThenAccumulated_IsReset()
        {
            var mockListener = Substitute.For<IEventListenerMock>();
            var sut = new Counter();
            sut.OnBeat += mockListener.Call;

            sut.InjectTime(0.9.Seconds());
            sut.Stop();
            sut.Paused = false;
            sut.InjectTime(0.9.Seconds());
            
            mockListener.DidNotReceive().Call();
        }
        
        [Test]
        public void Stop_ThenIsPaused()
        {
            var sut = new Counter();

            var pausedBefore = sut.Paused;
            sut.Stop();
            var pausedAfter = sut.Paused;

            pausedBefore.Should().BeFalse();
            pausedAfter.Should().BeTrue();
        }
        #endregion
    }
}