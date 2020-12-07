﻿namespace Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem
{
    public class WeaponType
    {
        public string ID { get; }
        
        public WeaponType(string id) => ID = id;
    }

    public sealed class NullWeaponType : WeaponType
    {
        public NullWeaponType() : base("") { }
    }
}