namespace Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem
{
    internal class Character
    {
        public string Name { get; set; }
        public CharacterClass CharacterClass { get; }
        public Weapon Weapon { get; } = new NullWeapon();

        public Character(string name, CharacterClass characterClass)
        {
            Name = name;
            CharacterClass = characterClass;
        }
    }
}