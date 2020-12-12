using FluentAssertions;
using Kalendra.Commons.Runtime.Domain.Gateways;
using Kalendra.Commons.Runtime.Infraestructure.CharacterTaxonomySystem.ScriptableObjects;
using Kalendra.Commons.Runtime.Infraestructure.Gateways.Adapters;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Runtime.Infraestructure
{
    public class CharacterClassesAcceptanceTests
    {
        readonly IReadOnlyRepository<CharacterClassDefinition> loader =
            new ByResourcesNameNotAsyncRepository<CharacterClassDefinition>();

        [Test, Category("Acceptance")]
        public async void NoCharacterClassDefinition_HasVoidID()
        {
            var definitions = await loader.LoadAll();

            foreach(var definition in definitions)
                string.IsNullOrWhiteSpace(definition.ToDefined().ID).Should()
                    .BeFalse($"{definition.name} musn't have void ID");
        }
    }
}