namespace Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem
{
    internal class Character
    {
        public CharacterClass characterClass { get; }
        public Weapon Weapon { get; } = new NullWeapon();

        public Character(CharacterClass characterClass)
        {
            this.characterClass = characterClass;
        }
    }
}