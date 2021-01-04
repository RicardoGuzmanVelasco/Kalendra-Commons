using System.Linq;
using Kalendra.CharacterTaxonomySystem.Runtime.Domain.Entities;
using Kalendra.Commons.Runtime.Infraestructure.Definitions;
using UnityEngine;

namespace Kalendra.CharacterTaxonomySystem.Runtime.Infraestructure.ScriptableObjects
{
    [CreateAssetMenu(fileName = "CharacterClass", menuName = "Kalendra/CharacterTaxonomy/CharacterClass", order = 0)]
    public class CharacterClassDefinition : DefinitionScriptObj<CharacterClassDefinitionDataModel, CharacterClass>
    {
        public override CharacterClass ToDefined()
        {
            var targetID = dataModel.id;
            var targetDerivedFrom = dataModel.derivedFrom?.Select(ancestor => ancestor.ToDefined());
            
            return new CharacterClass(targetID, targetDerivedFrom);
        }

        #region Format
        public override string ToString() => $@"{name}: [{ToDefined()}]";
        #endregion
    }
}