using System.Collections.Generic;

namespace Kalendra.CharacterTaxonomySystem.Runtime.Domain.Entities
{
    internal class WeaponType : IClassDependantUsable
    {
        public string ID { get; }
        public IEnumerable<CharacterClass> AllowedClasses { get; }
        
        public WeaponType(string id, IEnumerable<CharacterClass> allowedClasses)
        {
            ID = id;
            AllowedClasses = allowedClasses;
        }
    }

    internal sealed class NullWeaponType : WeaponType
    {
        public NullWeaponType() : base("", new List<CharacterClass>()) { }
    }
}