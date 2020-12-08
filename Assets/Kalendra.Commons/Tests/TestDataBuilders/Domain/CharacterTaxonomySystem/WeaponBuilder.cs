using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;
using Kalendra.Commons.Tests.TestDataBuilders.Builders;

namespace Kalendra.Commons.Tests.TestDataBuilders.Domain.CharacterTaxonomySystem
{
    internal class WeaponBuilder : Builder<Weapon>
    {
        string id;
        WeaponType type;

        public WeaponBuilder WithID(string newID)
        {
            id = newID;
            return this;
        }

        public WeaponBuilder WithType(WeaponType newType)
        {
            type = newType;
            return this;
        }
        
        public static WeaponBuilder New() => new WeaponBuilder();
        
        public override Weapon Build() => new Weapon(id, type);
    }
}