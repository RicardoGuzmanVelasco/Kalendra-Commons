using System.Collections.Generic;
using System.Linq;
using Commons.Utils.Patterns;
using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;

namespace Kalendra.Commons.Tests.TestDataBuilders.Application
{
    public class CharacterClassBuilder : Builder<CharacterClass>
    {
        string id;
        IEnumerable<WeaponType> equipableWeaponTypes;

        public CharacterClassBuilder WithID(string newID)
        {
            id = newID;
            return this;
        }

        public CharacterClassBuilder WithEquipableWeaponTypes(params WeaponType[] newWeaponTypes)
        {
            equipableWeaponTypes = newWeaponTypes;
            return this;
        }
        
        public static CharacterClassBuilder New() => new CharacterClassBuilder();
        public static CharacterClassBuilder New_Bard() => new CharacterClassBuilder().WithID("Bard");
        
        public override CharacterClass Build() => new CharacterClass(id, equipableWeaponTypes);
    }
}