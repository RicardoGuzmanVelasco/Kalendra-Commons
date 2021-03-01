using System;
using Kalendra.Time.Domain;
using UnityEngine;
using Zenject;

namespace Kalendra.Time.Runtime.Infraestructure
{
    public class TimePassageBehaviour : MonoBehaviour
    {
        [SerializeField] float secondsScale = 1f;
        
        [Inject] ITimePassageInjectable timePassage;

        public void InjectITimePassage(ITimePassageInjectable timePassage) => this.timePassage = timePassage;

        void Update()
        {
            var deltaTime = TimeSpan.FromSeconds(UnityEngine.Time.deltaTime * secondsScale);
            timePassage.InjectTime(deltaTime);
        }
    }
}