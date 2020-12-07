using FluentAssertions;
using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;
using Kalendra.Commons.Tests.TestDataBuilders.Application;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Runtime.Application
{
    public class WeaponTypeTests
    {
        [Test]
        public void WeaponType_HasID()
        {
            const string expectedID = "Axe";
            WeaponType sut = WeaponTypeBuilder.New().WithID(expectedID);

            var result = sut.ID;

            result.Should().Be(expectedID);
        }
    }
}