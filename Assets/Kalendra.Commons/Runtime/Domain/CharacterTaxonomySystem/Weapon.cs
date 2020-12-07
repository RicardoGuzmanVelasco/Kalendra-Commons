namespace Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem
{
    public class Weapon
    {
        public string ID { get; }
        public WeaponType Type { get; }

        public Weapon(string id, WeaponType type)
        {
            ID = id;
            Type = type;
        }
    }
    
    public sealed class NullWeapon : Weapon
    {
        public NullWeapon() : base("", new NullWeaponType()) { }
    }
}