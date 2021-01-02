using System;
using System.Collections.Generic;
using Kalendra.Commons.Runtime.Infraestructure.CharacterTaxonomySystem.ScriptableObjects;
using UnityEngine;

namespace Kalendra.CharacterTaxonomySystem.Runtime.Infraestructure.ScriptableObjects
{
    [Serializable]
    internal class CharacterClassDefinitionDataModel : DefinitionDataModel
    {
        [SerializeField] public string id;
        [SerializeField] public List<CharacterClassDefinition> derivedFrom;
    }
}