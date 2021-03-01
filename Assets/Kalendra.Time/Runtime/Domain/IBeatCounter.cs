using System;

namespace Kalendra.Time.Domain
{
    public interface IBeatCounter : IPausable
    {
        float Hertz { get; }
        event Action OnBeat;
    }
}