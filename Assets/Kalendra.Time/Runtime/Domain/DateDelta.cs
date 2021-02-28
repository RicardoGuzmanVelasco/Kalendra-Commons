using System;

namespace Kalendra.Time.Domain
{
    public class DateDelta : ITimeInjectable
    {
        public DateTime Beggining { get; }
        DateTime Last { get; set; }
        public DateTime Current { get; private set; }
        
        public TimeSpan Delta => Current - Last;
        public TimeSpan TotalDelta => Current - Beggining;
        
        #region Constructors
        public DateDelta() : this(DateTime.MinValue) { }
        public DateDelta(DateTime begginingTime) : this(begginingTime, begginingTime) { }
        
        public DateDelta(DateTime begginingTime, DateTime currentTime)
        {
            Beggining = begginingTime;
            Last = currentTime;
            Current = currentTime;
        }
        #endregion

        #region ITimeInjectable implementation
        public void InjectTime(TimeSpan timeToAdd)
        {
            Last = Current;
            Current += timeToAdd;
        }
        #endregion
    }
}