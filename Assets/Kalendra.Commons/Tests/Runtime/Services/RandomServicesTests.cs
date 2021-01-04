using System.Collections;
using FluentAssertions;
using Kalendra.Commons.Runtime.Infraestructure.Services;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Kalendra.Commons.Tests.Runtime.Services
{
    public class RandomServicesTests
    {
        [UnityTest]
        public IEnumerator SystemRandomService_SameSeedReturnsSameValues()
        {
            var sut1 = new SystemRandomService(1500);
            yield return null;
            var sut2 = new SystemRandomService(1500);

            var resultsService1 = new[] {sut1.Next(), sut1.Next(), sut1.Next()};
            yield return null;
            var resultsService2 = new[] {sut2.Next(), sut2.Next(), sut2.Next()};

            resultsService1.Should().BeEquivalentTo(resultsService2);
        }
        
        [UnityTest, Category("TODO")]
        public IEnumerator UnityRandomService_SameSeedReturnsSameValues()
        {
            yield break;
            var sut1 = new UnityEngineRandomService(1500);
            yield return null;
            var sut2 = new UnityEngineRandomService(1500);

            var resultsService1 = new[] {sut1.Next(), sut1.Next(), sut1.Next()};
            yield return null;
            var resultsService2 = new[] {sut2.Next(), sut2.Next(), sut2.Next()};

            resultsService1.Should().BeEquivalentTo(resultsService2);
        }

        [Test]
        public void UnityRandomServices_SameSeedReturnsSameValues()
        {
            var sut = new UnityEngineRandomService();

            sut.Seed = 1500;
            var resultFirst = new [] {sut.Next(), sut.Next(), sut.Next()};
            sut.Seed = 1500;
            var resultSecond = new [] {sut.Next(), sut.Next(), sut.Next()};

            resultFirst.Should().BeEquivalentTo(resultSecond);
        }
    }
}