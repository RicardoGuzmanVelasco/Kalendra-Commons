using FluentAssertions;
using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;
using Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Editor.Domain.CharacterTaxonomySystem
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