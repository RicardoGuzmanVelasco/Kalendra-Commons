using Commons.Utils.Patterns;
using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;

namespace Kalendra.Commons.Tests.TestDataBuilders.Application
{
    public class WeaponBuilder : Builder<Weapon>
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