namespace Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem
{
    public class Character
    {
        public CharacterClass characterClass { get; }
        public Weapon Weapon { get; } = new NullWeapon();

        public Character(CharacterClass characterClass)
        {
            this.characterClass = characterClass;
        }
    }
}