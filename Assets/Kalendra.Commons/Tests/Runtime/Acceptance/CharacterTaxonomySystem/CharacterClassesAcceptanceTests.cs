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
        public async void NoCharacterClassDefinition_HasEmptyID()
        {
            var definitions = await loader.LoadAll();

            definitions.Should().NotContain(
                definition => string.IsNullOrWhiteSpace(definition.ToDefined().ID),
                "musn't have void ID");
        }
        
        [Test]
        public async void AllCharacterClassDefinition_HasUniqueID()
        {
            var definitions = await loader.LoadAll();

            var definitionsGroupedByID = definitions.GroupBy(definition => definition.ToDefined().ID);

            foreach(var definitionGroup in definitionsGroupedByID)
                definitionGroup.Should().ContainSingle("ID must be unique");
        }
        
        [Test]
        public async void NoCharacterClassDefinition_DerivesFromDuplicated()
        {
            var definitions = await loader.LoadAll();
            
            foreach(var definition in definitions)
            {
                var ancestorsGroupedByID = definition.ToDefined().AllFamilyID.GroupBy(s => s);
                foreach(var ancestorsGroup in ancestorsGroupedByID)
                    ancestorsGroup.Should().ContainSingle($"ancestor in {definition.name} should be unique");
            }
        }
    }
}