using System.Collections.Generic;
using Kalendra.Commons.Tests.TestDataBuilders.Builders;

namespace Kalendra.CharacterTaxonomySystem.Tests.TestDataBuilders.Domain
{
    internal class WeaponTypeBuilder : Builder<WeaponType>
    {
        string id;
        IEnumerable<CharacterClass> allowedClasses = new List<CharacterClass>();

        public WeaponTypeBuilder WithID(string newID)
        {
            id = newID;
            return this;
        }

        public WeaponTypeBuilder WithAllowedClasses(params CharacterClass[] newAllowedClasses)
        {
            allowedClasses = newAllowedClasses;
            return this;
        }

        public static WeaponTypeBuilder New() => new WeaponTypeBuilder();
        public static WeaponTypeBuilder New_Axe() => new WeaponTypeBuilder().WithID("Axe");
        
        public override WeaponType Build() => new WeaponType(id, allowedClasses);
    }
}