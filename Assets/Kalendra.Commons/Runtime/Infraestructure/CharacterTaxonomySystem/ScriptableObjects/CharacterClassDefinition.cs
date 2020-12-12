using System;
using System.Collections.Generic;
using System.Linq;
using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;
using UnityEngine;

namespace Kalendra.Commons.Runtime.Infraestructure.CharacterTaxonomySystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "CharacterClass", menuName = "Kalendra/CharacterTaxonomy/CharacterClass", order = 0)]
    public class CharacterClassDefinition : ScriptableObject
    {
        [SerializeField] string id;
        [SerializeField] List<CharacterClassDefinition> derivedFrom;

        public CharacterClass ToCharacterClass()
        {
            var targetDerivedFrom = derivedFrom?.Select(ancestor => ancestor.ToCharacterClass());
            return new CharacterClass(id, targetDerivedFrom);
        } 
    }
}