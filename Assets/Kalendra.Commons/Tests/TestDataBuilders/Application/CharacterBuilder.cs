using System.Collections.Generic;
using Commons.Utils.Patterns;
using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;

namespace Kalendra.Commons.Tests.TestDataBuilders.Application
{
    public class CharacterBuilder : Builder<Character>
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