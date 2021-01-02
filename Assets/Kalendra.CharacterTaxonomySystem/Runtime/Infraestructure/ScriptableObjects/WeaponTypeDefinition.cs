using UnityEngine;

namespace Kalendra.CharacterTaxonomySystem.Runtime.Infraestructure.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponType", menuName = "Kalendra/CharacterTaxonomy/WeaponType", order = 0)]
    public class WeaponTypeDefinition : ScriptableObject
    {
        [SerializeField] string id;
        
    }
}