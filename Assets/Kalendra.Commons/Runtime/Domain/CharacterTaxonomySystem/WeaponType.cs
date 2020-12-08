namespace Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem
{
    internal class WeaponType
    {
        public string ID { get; }
        
        public WeaponType(string id) => ID = id;
    }

    internal sealed class NullWeaponType : WeaponType
    {
        public NullWeaponType() : base("") { }
    }
}