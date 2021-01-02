using System.Collections.Generic;
using System.Linq;
using Kalendra.CharacterTaxonomySystem.Runtime.Domain.Entities;

namespace Kalendra.CharacterTaxonomySystem.Tests.TestDataBuilders.Infraestructure
{
    internal class CharacterClassDefinitionBuilder
        : DefinitionBuilder<CharacterClassDefinition, CharacterClassDefinitionDataModel, CharacterClass>
    {
        string id = "";
        List<CharacterClassDefinition> derivedFrom = new List<CharacterClassDefinition>();

        public CharacterClassDefinitionBuilder WithID(string newID)
        {
            id = newID;
            return this;
        }

        public CharacterClassDefinitionBuilder WithDerivedFrom(params CharacterClassDefinition[] newDerivedFrom)
        {
            derivedFrom = newDerivedFrom.ToList();
            return this;
        }
        
        public static CharacterClassDefinitionBuilder New() => new CharacterClassDefinitionBuilder();

        protected override CharacterClassDefinitionDataModel BuildDataModel()
        {
            return new CharacterClassDefinitionDataModel
            {
                id = id,
                derivedFrom = derivedFrom
            };
        }
    }
}