using UnityEngine;

namespace Kalendra.Commons.Runtime.Infraestructure.CharacterTaxonomySystem
{
    [CreateAssetMenu(fileName = "Character", menuName = "Kalendra/Character", order = 0)]
    public class CharacterScriptObj : ScriptableObject
    {
        [SerializeField] string testLogText;

        public string TestLogText => testLogText;
    }
}