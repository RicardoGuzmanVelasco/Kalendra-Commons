using UnityEngine;

namespace Kalendra.Commons.Runtime.Infraestructure.CharacterTaxonomySystem.ScriptableObjects
{
    internal abstract class DefinitionScriptObj<TDataModel, TDefined> : ScriptableObject
        where TDataModel : DefinitionDataModel
    {
        [SerializeField] protected TDataModel dataModel;

        public abstract TDefined ToDefined();
    }
}