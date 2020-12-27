using FluentAssertions;
using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;
using Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Editor.Domain.CharacterTaxonomySystem
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