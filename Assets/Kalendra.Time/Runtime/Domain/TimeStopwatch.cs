using System;

namespace Kalendra.Time.Domain
{
    public class TimeStopwatch : IStopwatch, ITimeInjectable
    {
        public TimeSpan Elapsed { get; private set; }
        
        public bool Paused { get; set; }
        public void Stop()
        {
            Elapsed = TimeSpan.Zero;
            Paused = true;
        }

        public void InjectTime(TimeSpan timeToAdd)
        {
            if(Paused)
                return;
            
            Elapsed += timeToAdd;
        }
    }
}