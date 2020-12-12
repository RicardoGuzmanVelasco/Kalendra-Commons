using System.Collections.Generic;
using System.Linq;

namespace Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem
{
    public class CharacterClass
    {
        public string ID { get; }

        readonly IEnumerable<CharacterClass> derivedFrom;

        public CharacterClass(string id, IEnumerable<CharacterClass> derivedFromClasses = null)
        {
            ID = id;
            derivedFrom = derivedFromClasses ?? new List<CharacterClass>();
        }

        public IEnumerable<string> AllFamilyID => CreateGenealogicalIDFamily();

        public bool IsAbleToUse(IClassDependantUsable usable)
        {
            return !usable.AllowedClasses.Any() ||
                    usable.AllowedClasses.Any(characterClass => AllFamilyID.Contains(characterClass.ID));
        }

        #region Support methods
        IEnumerable<string> CreateGenealogicalIDFamily()
        {
            var familyID = new List<string>{ID};
            
            foreach(var ancestor in derivedFrom)
                familyID.AddRange(ancestor.CreateGenealogicalIDFamily());
            
            return familyID;
        }
        #endregion
    }

    internal sealed class NullCharacterClass : CharacterClass
    {
        public NullCharacterClass() : base("") { }
    }
}