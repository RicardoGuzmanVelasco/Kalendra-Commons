namespace Kalendra.CharacterTaxonomySystem.Runtime.Domain.Entities
{
    internal class Weapon
    {
        public string ID { get; }
        public WeaponType Type { get; }

        public Weapon(string id, WeaponType type)
        {
            ID = id;
            Type = type;
        }
    }
    
    internal sealed class NullWeapon : Weapon
    {
        public NullWeapon() : base("", new NullWeaponType()) { }
    }
}