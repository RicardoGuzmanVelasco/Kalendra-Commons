using System.Linq;
using FluentAssertions;
using Kalendra.Commons.Runtime.Domain.Gateways;
using Kalendra.Commons.Runtime.Infraestructure.CharacterTaxonomySystem.ScriptableObjects;
using Kalendra.Commons.Runtime.Infraestructure.Gateways.Adapters;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Runtime.Acceptance
{
    [TestFixture, Category("Acceptance")]
    public class CharacterClassesAcceptanceTests
    {
        readonly IReadOnlyRepository<CharacterClassDefinition> loader =
            new ByResourcesNameNotAsyncRepository<CharacterClassDefinition>();

        [Test]
        public async void NoCharacterClassDefinition_HasVoidID()
        {
            var definitions = await loader.LoadAll();

            foreach(var definition in definitions)
                string.IsNullOrWhiteSpace(definition.ToDefined().ID).Should()
                    .BeFalse($"{definition.name} musn't have void ID");
        }
        
        [Test]
        public async void NoCharacterClassDefinition_HasDuplicatedID()
        {
            var definitions = await loader.LoadAll();

            foreach(var definition in definitions)
                definitions
                    .Count(classDefinition => classDefinition.ToDefined().ID == definition.ToDefined().ID)
                    .Should().Be(1, $"{definition.name} shouldn't be repeated in other definition");
        }
    }
}