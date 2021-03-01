using System;

namespace Kalendra.Time.Domain
{
    public readonly struct TimeSignature
    {
        public readonly int pulses;
        public readonly int note;

        public TimeSignature(int pulses, int note)
        {
            this.pulses = pulses;
            this.note = note;
        }
    }
    
    public interface IMetronome : IBeatCounter
    {
        /// <summary>
        /// Would be forcedly related to <see cref="IBeatCounter.Hertz"/>. Just semantic-friendly.
        /// </summary>
        float BPM { get; }
        TimeSignature Signature { get; }

        event Action<bool> OnAnyBeat;
        event Action OnDownbeat;
    }
}