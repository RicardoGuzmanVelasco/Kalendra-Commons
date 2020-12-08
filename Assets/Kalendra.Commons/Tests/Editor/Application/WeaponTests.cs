using FluentAssertions;
using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;
using Kalendra.Commons.Tests.TestDataBuilders.Application;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Editor.Application
{
    public class WeaponTests
    {
        [Test]
        public void Weapon_HasWeaponType()
        {
            var expectedType = WeaponTypeBuilder.New_Axe().Build();
            Weapon sut = WeaponBuilder.New().WithType(expectedType);

            var resultType = sut.Type;

            resultType.Should().Be(expectedType);
        }

        [Test]
        public void Weapon_HasID()
        {
            const string expectedID = "GoldAxe";
            Weapon sut = WeaponBuilder.New().WithID(expectedID);

            var resultID = sut.ID;

            resultID.Should().BeEquivalentTo(expectedID);
        }
    }
}