using Kalendra.CharacterTaxonomySystem.Tests.TestDataBuilders.Infraestructure;

namespace Kalendra.CharacterTaxonomySystem.Tests.TestDataBuilders.StaticShortcuts.Infraestructure
{
    internal static partial class Build
    {
        public static CharacterClassDefinitionBuilder CharacterClassDefinition() => CharacterClassDefinitionBuilder.New();
    }
}