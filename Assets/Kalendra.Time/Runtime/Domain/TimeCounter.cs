using System;

namespace Kalendra.Time.Domain
{
    public class Counter : IBeatCounter, ITimeInjectable
    {
        double accumulated;

        #region Constructors
        public Counter() : this(1) { }
        public Counter(float hertz, bool paused = false)
        {
            if(hertz < 0)
                throw new ArgumentOutOfRangeException(nameof(hertz), "Negative frequency is non-sense.");
            
            Hertz = hertz;
            Paused = paused;
        }
        #endregion
        
        #region IBeatCounter implementation
        public float Hertz { get; }
        float Period => 1 / Math.Max(Hertz, float.Epsilon);
        public bool Paused { get; set; }

        public event Action OnBeat;

        public void Stop()
        {
            Paused = true;
            accumulated = 0;
        }
        #endregion

        #region ITimeInjectable implementation
        public void InjectTime(TimeSpan timeToAdd)
        {
            if(Paused)
                return;
            
            accumulated += timeToAdd.TotalSeconds;
            ResolveAccumulatedBeats();
        }
        #endregion

        void ResolveAccumulatedBeats()
        {
            while(accumulated >= Period)
            {
                accumulated -= Period;
                OnBeat?.Invoke();
            }
        }
    }
}