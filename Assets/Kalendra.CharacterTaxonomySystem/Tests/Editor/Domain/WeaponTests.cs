using FluentAssertions;
using Kalendra.CharacterTaxonomySystem.Runtime.Domain.Entities;
using Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts;
using NUnit.Framework;

namespace Kalendra.CharacterTaxonomySystem.Tests.Editor.Domain
{
    public class WeaponTests
    {
        [Test]
        public void Weapon_HasWeaponType()
        {
            var expectedType = Build.WeaponType_Axe().Build();
            Weapon sut = Build.Weapon().WithType(expectedType);

            var resultType = sut.Type;

            resultType.Should().Be(expectedType);
        }

        [Test]
        public void Weapon_HasID()
        {
            const string expectedID = "GoldAxe";
            Weapon sut = Build.Weapon().WithID(expectedID);

            var resultID = sut.ID;

            resultID.Should().BeEquivalentTo(expectedID);
        }
    }
}