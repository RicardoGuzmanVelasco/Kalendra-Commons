using Kalendra.Time.Domain;
using UnityEngine;
using Zenject;

namespace Kalendra.Time.Runtime.Infraestructure
{
    public class TimePassageLogger : MonoBehaviour
    {
        [Inject] ITimePassage timePassage;
        
        void Awake()
        {
            timePassage.OnNewSecond += () => Debug.Log(timePassage.TotalElapsedTime);
        }
    }
}