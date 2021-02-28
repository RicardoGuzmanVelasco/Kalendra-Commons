using System;

namespace Kalendra.Time.Domain
{
    public class TimePassage : ITimeInjectable
    {
        readonly DateDelta datePassage;
        
        #region Constructors
        public TimePassage(DateTime initialTime) : this(new DateDelta(initialTime)) { }
        public TimePassage(DateTime initialTime, DateTime currentTime) : this(new DateDelta(initialTime, currentTime)) { }
        public TimePassage(DateDelta datePassage)
        {
            this.datePassage = datePassage;
        }
        #endregion

        #region Properties
        public DateTime CurrentDate => datePassage.Current;
        public DateTime InitialDate => datePassage.Beggining;
        #endregion
        
        #region Events
        public event Action OnNewSecond;
        #endregion

        #region ITimeInjectable implementation
        public void InjectTime(TimeSpan timeToAdd)
        {
            datePassage.InjectTime(timeToAdd);
            CheckIfSendEvents(datePassage.Delta);
        }
        #endregion
        
        void CheckIfSendEvents(TimeSpan lastDelta)
        {
            SendSeconds(lastDelta);
        }

        void SendSeconds(TimeSpan lastDelta)
        {
            var totalSecondsPassed = (lastDelta - TimeSpan.FromSeconds(1)).TotalSeconds;
            for(var i = 0; i < totalSecondsPassed; i++)
                OnNewSecond?.Invoke();
        }
    }
}