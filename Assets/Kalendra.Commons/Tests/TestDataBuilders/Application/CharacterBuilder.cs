using System.Collections.Generic;
using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;
using Kalendra.Commons.Tests.TestDataBuilders.Builders;

namespace Kalendra.Commons.Tests.TestDataBuilders.Application
{
    internal class CharacterBuilder : Builder<Character>
    {
        CharacterClass characterClass;
        
        public CharacterBuilder WithClass(CharacterClass newClass)
        {
            characterClass = newClass;
            return this;
        }

        public static CharacterBuilder New() => new CharacterBuilder();
        
        public override Character Build() => new Character(characterClass);
    }
}