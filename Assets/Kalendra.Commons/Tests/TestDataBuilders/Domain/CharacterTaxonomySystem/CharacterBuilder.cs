using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;
using Kalendra.Commons.Tests.TestDataBuilders.Builders;

namespace Kalendra.Commons.Tests.TestDataBuilders.Domain.CharacterTaxonomySystem
{
    internal class CharacterBuilder : Builder<Character>
    {
        string name;
        CharacterClass characterClass;
        
        public CharacterBuilder WithName(string newName)
        {
            name = newName;
            return this;
        }
        
        public CharacterBuilder WithClass(CharacterClass newClass)
        {
            characterClass = newClass;
            return this;
        }

        public static CharacterBuilder New() => new CharacterBuilder();
        
        public override Character Build() => new Character(name, characterClass);
    }
}