namespace Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem
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