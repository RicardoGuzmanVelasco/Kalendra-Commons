using System.Collections.Generic;
using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;
using Kalendra.Commons.Tests.TestDataBuilders.Builders;

namespace Kalendra.Commons.Tests.TestDataBuilders.Domain.CharacterTaxonomySystem
{
    internal class CharacterClassBuilder : Builder<CharacterClass>
    {
        string id = "";
        IEnumerable<CharacterClass> derivedFrom;

        public CharacterClassBuilder WithID(string newID)
        {
            id = newID;
            return this;
        }

        public CharacterClassBuilder WithDerivedFrom(params CharacterClass[] newDerivedFrom)
        {
            derivedFrom = newDerivedFrom;
            return this;
        }
        
        public static CharacterClassBuilder New() => new CharacterClassBuilder();
        public static CharacterClassBuilder New_Bard() => new CharacterClassBuilder().WithID("Bard");
        
        public override CharacterClass Build() => new CharacterClass(id, derivedFrom);
    }
}