using System;

namespace Kalendra.Time.Domain
{
    public interface IStopwatch
    {
        TimeSpan Elapsed { get; }
    }
}