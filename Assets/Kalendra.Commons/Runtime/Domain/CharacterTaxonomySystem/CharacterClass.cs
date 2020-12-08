using System.Collections.Generic;

namespace Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem
{
    internal class CharacterClass
    {
        public string ID { get; }
        public IEnumerable<WeaponType> EquipableWeaponTypes { get; }

        public CharacterClass(string id, IEnumerable<WeaponType> equipableWeaponTypes)
        {
            ID = id;
            EquipableWeaponTypes = equipableWeaponTypes;
        }
    }
}