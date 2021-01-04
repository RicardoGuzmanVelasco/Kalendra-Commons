using System;
using System.Collections.Generic;
using Kalendra.Commons.Runtime.Infraestructure.Definitions;
using UnityEngine;

namespace Kalendra.CharacterTaxonomySystem.Runtime.Infraestructure.ScriptableObjects
{
    [Serializable]
    public class CharacterClassDefinitionDataModel : DefinitionDataModel
    {
        [SerializeField] public string id;
        [SerializeField] public List<CharacterClassDefinition> derivedFrom;
    }
}