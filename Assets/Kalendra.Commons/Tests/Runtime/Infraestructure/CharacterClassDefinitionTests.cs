using System.Linq;
using FluentAssertions;
using Kalendra.Commons.Runtime.Infraestructure.CharacterTaxonomySystem.ScriptableObjects;
using Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Runtime.Infraestructure
{
    public class CharacterClassDefinitionTests
    {
        [Test]
        public static void ToCharacterClass_ConvertsID()
        {
            const string expectedID = "ID";
            CharacterClassDefinition sut = Build.CharacterClassDefinition().WithID(expectedID);

            var resultCharacterClass = sut.ToCharacterClass();

            resultCharacterClass.ID.Should().Be(expectedID);
        }
        
        [Test]
        public static void ToCharacterClass_ConvertsDerivedFrom()
        {
            const string expectedParentID = "parentID";
            var parent = Build.CharacterClassDefinition().WithID(expectedParentID);
            CharacterClassDefinition sut = Build.CharacterClassDefinition().WithDerivedFrom(parent);

            var resultCharacterClass = sut.ToCharacterClass();

            resultCharacterClass.AllFamilyID.Should().Contain(expectedParentID);
        }
    }
}