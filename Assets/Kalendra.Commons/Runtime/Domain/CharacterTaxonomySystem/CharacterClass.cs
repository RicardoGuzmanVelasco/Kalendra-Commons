﻿using System.Collections.Generic;

namespace Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem
{
    internal class CharacterClass
    {
        public string ID { get; }

        public CharacterClass(string id, IEnumerable<WeaponType> equipableWeaponTypes)
        {
            ID = id;
        }
    }

    internal sealed class NullCharacterClass : CharacterClass
    {
        public NullCharacterClass() : base("", new List<WeaponType>()) { }
    }
}