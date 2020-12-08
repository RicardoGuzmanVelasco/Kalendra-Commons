using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;
using Kalendra.Commons.Tests.TestDataBuilders.Builders;

namespace Kalendra.Commons.Tests.TestDataBuilders.Domain.CharacterTaxonomySystem
{
    internal class WeaponTypeBuilder : Builder<WeaponType>
    {
        string id;

        public WeaponTypeBuilder WithID(string newID)
        {
            id = newID;
            return this;
        }

        public static WeaponTypeBuilder New() => new WeaponTypeBuilder();
        public static WeaponTypeBuilder New_Axe() => new WeaponTypeBuilder().WithID("Axe");
        
        public override WeaponType Build() => new WeaponType(id);
    }
}