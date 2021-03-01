using System;
using Kalendra.Time.Domain;
using UnityEngine;

namespace Kalendra.Time.Runtime.Infraestructure
{
    public class TimePassageBehaviourInjector : MonoBehaviour
    {
        [SerializeField] float secondsScale = 1f;
        
        ITimePassageInjectable timePassage;

        void Awake()
        {
            InjectITimePassage(new TimePassage(DateTime.Now));

            timePassage.OnNewSecond += () => Debug.Log(timePassage.CurrentDate - timePassage.InitialDate);
        }

        public void InjectITimePassage(ITimePassageInjectable timePassage) => this.timePassage = timePassage;

        void Update()
        {
            var deltaTime = TimeSpan.FromSeconds(UnityEngine.Time.deltaTime * secondsScale);
            timePassage.InjectTime(deltaTime);
        }
    }
}