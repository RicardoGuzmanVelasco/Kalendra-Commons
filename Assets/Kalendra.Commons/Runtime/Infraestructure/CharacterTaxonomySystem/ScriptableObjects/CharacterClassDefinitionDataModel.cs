using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kalendra.Commons.Runtime.Infraestructure.CharacterTaxonomySystem.ScriptableObjects
{
    [Serializable]
    internal class CharacterClassDefinitionDataModel : DefinitionDataModel
    {
        [SerializeField] public string id;
        [SerializeField] public List<CharacterClassDefinition> derivedFrom;
    }
}