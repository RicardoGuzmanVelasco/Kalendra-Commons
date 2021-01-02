using FluentAssertions;
using Kalendra.CharacterTaxonomySystem.Runtime.Domain.Entities;
using Kalendra.CharacterTaxonomySystem.Tests.TestDataBuilders.StaticShortcuts;
using NUnit.Framework;

namespace Kalendra.CharacterTaxonomySystem.Tests.Editor.Domain
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
        
        [Test]
        public void AllFamilyID_ContainsIDAndIDFromParents()
        {
            var parentBaseClass = Build.CharacterClass_Bard().Build();
            const string selfID = "ID";
            CharacterClass sut = Build.CharacterClass().WithID(selfID).WithDerivedFrom(parentBaseClass);

            var resultFamilyID = sut.AllFamilyID;

            resultFamilyID.Should().HaveCount(2);
            resultFamilyID.Should().ContainInOrder(selfID, parentBaseClass.ID);
        }
        
        [Test]
        public void AllFamilyID_ContainsIDAndAllIDFromAncestors()
        {
            var ancestorClass1 = Build.CharacterClass().WithID("ancestor1").Build();
            var ancestorClass2 = Build.CharacterClass().WithID("ancestor2").Build();
            var parentWithAncestors = Build.CharacterClass().WithDerivedFrom(ancestorClass1, ancestorClass2);
            CharacterClass sut = Build.CharacterClass().WithDerivedFrom(parentWithAncestors);

            var resultFamilyID = sut.AllFamilyID;

            resultFamilyID.Should().HaveCount(4);
            resultFamilyID.Should().Contain(ancestorClass1.ID);
            resultFamilyID.Should().Contain(ancestorClass2.ID);
        }
    }
}