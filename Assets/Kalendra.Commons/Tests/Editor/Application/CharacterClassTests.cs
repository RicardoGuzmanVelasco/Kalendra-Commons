using FluentAssertions;
using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;
using Kalendra.Commons.Tests.TestDataBuilders.Domain.CharacterTaxonomySystem;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Editor.Application
{
    public class CharacterClassTests
    {
        [Test]
        public void CharacterClass_HasID()
        {
            const string characterID = "ID";
            CharacterClass sut = CharacterClassBuilder.New().WithID(characterID);

            var resultID = sut.ID;

            resultID.Should().BeEquivalentTo(characterID);
        }
    }
}