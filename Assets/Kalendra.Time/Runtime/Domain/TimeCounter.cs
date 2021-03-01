using System;

namespace Kalendra.Time.Domain
{
    public class Counter : ITimeCounterInjectable
    {
        double accumulated;
        
        public float Hertz { get; }
        float Period => 1 / Math.Max(Hertz, float.Epsilon);
        
        public event Action Beat;

        #region Constructors
        public Counter() : this(1) { }
        public Counter(float hertz)
        {
            if(hertz < 0)
                throw new ArgumentOutOfRangeException(nameof(hertz), "Negative frequency is non-sense.");
            
            Hertz = hertz;
        }
        #endregion

        #region ITimeInjectable implementation
        public void InjectTime(TimeSpan timeToAdd)
        {
            accumulated += timeToAdd.TotalSeconds;
            CheckIfBeat();
        }
        #endregion

        void CheckIfBeat()
        {
            while(accumulated >= Period)
            {
                accumulated -= Period;
                Beat?.Invoke();
            }
        }
    }
}