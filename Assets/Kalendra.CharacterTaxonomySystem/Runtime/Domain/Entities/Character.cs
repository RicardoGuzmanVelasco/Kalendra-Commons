namespace Kalendra.CharacterTaxonomySystem.Runtime.Domain.Entities
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

        //TODO: move to Interactor concern?
        public bool CanUse(IClassDependantUsable usable) => Class.IsAbleToUse(usable);
    }
}