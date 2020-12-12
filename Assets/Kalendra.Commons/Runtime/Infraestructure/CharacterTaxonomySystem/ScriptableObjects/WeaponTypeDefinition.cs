using UnityEngine;
using UnityEngine.Serialization;

namespace Kalendra.Commons.Runtime.Infraestructure.CharacterTaxonomySystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponType", menuName = "Kalendra/CharacterTaxonomy/WeaponType", order = 0)]
    public class WeaponTypeDefinition : ScriptableObject
    {
        [SerializeField] string id;
        
    }
}