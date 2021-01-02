using Kalendra.Commons.Tests.TestDataBuilders.Builders;

namespace Kalendra.CharacterTaxonomySystem.Tests.TestDataBuilders.Domain
{
    internal class CharacterBuilder : Builder<Character>
    {
        string name = "";
        CharacterClass characterClass = new NullCharacterClass();
        
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