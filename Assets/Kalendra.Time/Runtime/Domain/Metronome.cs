using System;

namespace Kalendra.Time.Domain
{
    class Metronome : IMetronome, ITimeInjectable
    {
        readonly Counter counter;
        int counterPulsesCount;

        public float Hertz => counter.Hertz;
        public float BPM => Hertz * 60;
        public TimeSignature Signature { get; }

        #region Constructors
        public Metronome() : this(90, new TimeSignature(4, 4)) { }
        public Metronome(float bpm, TimeSignature signature)
        {
            counter = new Counter(bpm / 60f);
            Signature = signature;

            counter.OnBeat += HandleCounterBeatEvent;
        }
        #endregion
        
        #region IMetronome events
        public event Action OnDownbeat;
        /// <summary>
        /// Any beat, using bool to mark if is a downbeat.
        /// </summary>
        public event Action<bool> OnAnyBeat;
        /// <summary>
        /// Just those beats which are not downbeat.
        /// </summary>
        public event Action OnBeat;
        #endregion
        
        void HandleCounterBeatEvent()
        {
            counterPulsesCount++;
            
            if(counterPulsesCount < Signature.pulses)
            {
                OnAnyBeat?.Invoke(false);
                OnBeat?.Invoke();
            }
            else
            {
                counterPulsesCount = 0;
                OnAnyBeat?.Invoke(true);
                OnDownbeat?.Invoke();
            }
        }

        #region IPausable implementation
        public bool Paused
        {
            get => counter.Paused;
            set => counter.Paused = value;
        }
        public void Stop() => counter.Stop();
        #endregion

        #region ITimeInjectable implementation
        public void InjectTime(TimeSpan timeToAdd) => counter.InjectTime(timeToAdd); //TODO: use signature denominator!
        #endregion
    }
}