using System.Collections.Generic;
using System.Linq;

namespace Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem
{
    internal class WeaponType : IClassDependantUsable
    {
        public string ID { get; }
        IEnumerable<CharacterClass> AllowedClasses { get; }
        
        public WeaponType(string id, IEnumerable<CharacterClass> allowedClasses)
        {
            ID = id;
            AllowedClasses = allowedClasses;
        }

        public bool IsUsableByClass(CharacterClass @class)
        {
            return !AllowedClasses.Any() || AllowedClasses.Contains(@class);
        }
    }

    internal sealed class NullWeaponType : WeaponType
    {
        public NullWeaponType() : base("", new List<CharacterClass>()) { }
    }
}