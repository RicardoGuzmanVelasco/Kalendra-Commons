using System.Linq;
using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;
using UnityEngine;

namespace Kalendra.Commons.Runtime.Infraestructure.CharacterTaxonomySystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "CharacterClass", menuName = "Kalendra/CharacterTaxonomy/CharacterClass", order = 0)]
    internal class CharacterClassDefinition : DefinitionScriptObj<CharacterClassDefinitionDataModel, CharacterClass>
    {
        public override CharacterClass ToDefined()
        {
            var targetID = dataModel.id;
            var targetDerivedFrom = dataModel.derivedFrom?.Select(ancestor => ancestor.ToDefined());
            
            return new CharacterClass(targetID, targetDerivedFrom);
        } 
    }
}