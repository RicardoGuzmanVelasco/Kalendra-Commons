using System;
using System.Collections;
using System.Collections.Generic;

namespace Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem
{
    internal class CharacterClass
    {
        public string ID { get; }

        IEnumerable<CharacterClass> derivedFrom;

        public CharacterClass(string id, IEnumerable<CharacterClass> derivedFromClasses = null)
        {
            ID = id;
            derivedFrom = derivedFromClasses ?? new List<CharacterClass>();
        }

        public IEnumerable<string> AllFamilyID => CreateGenealogicalIDFamily();

        #region Support methods
        IEnumerable<string> CreateGenealogicalIDFamily()
        {
            return new List<string>{ID};
        }
        #endregion
    }

    internal sealed class NullCharacterClass : CharacterClass
    {
        public NullCharacterClass() : base("") { }
    }
}