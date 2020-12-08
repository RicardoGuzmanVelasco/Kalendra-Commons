using FluentAssertions;
using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;
using Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Editor.Application
{
    public class CharacterClassTests
    {
        [Test]
        public void CharacterClass_HasID()
        {
            const string characterID = "ID";
            CharacterClass sut = Build.CharacterClass().WithID(characterID);

            var resultID = sut.ID;

            resultID.Should().BeEquivalentTo(characterID);
        }

        [Test]
        public void AllFamilyID_JustContainsID_IfIsNotDerivedClass()
        {
            var expectedID = "ID";
            CharacterClass sut = Build.CharacterClass().WithID(expectedID);

            var resultFamilyID = sut.AllFamilyID;

            resultFamilyID.Should().HaveCount(1);
            resultFamilyID.Should().Contain(expectedID);
        }
    }
}