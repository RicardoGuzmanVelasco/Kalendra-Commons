using FluentAssertions;
using Kalendra.CharacterTaxonomySystem.Runtime.Domain.Entities;
using Kalendra.CharacterTaxonomySystem.Tests.TestDataBuilders.StaticShortcuts;
using NUnit.Framework;

namespace Kalendra.CharacterTaxonomySystem.Tests.Editor.Domain
{
    public class WeaponTypeTests
    {
        [Test]
        public void WeaponType_HasID()
        {
            const string expectedID = "ID";
            WeaponType sut = Build.WeaponType().WithID(expectedID);

            var result = sut.ID;

            result.Should().Be(expectedID);
        }
    }
}