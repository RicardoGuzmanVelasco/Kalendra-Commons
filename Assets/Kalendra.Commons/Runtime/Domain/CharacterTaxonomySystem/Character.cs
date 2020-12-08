namespace Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem
{
    internal class Character
    {
        public string Name { get; set; }
        public CharacterClass Class { get; }
        public Weapon Weapon { get; } = new NullWeapon();

        public Character(string name, CharacterClass @class)
        {
            Name = name;
            Class = @class;
        }
    }
}