using System;

namespace Kalendra.Time.Domain
{
    public interface IStopwatch : IPausable
    {
        TimeSpan Elapsed { get; }
    }
}