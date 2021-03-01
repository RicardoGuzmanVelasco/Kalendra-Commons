using System;

namespace Kalendra.Time.Domain
{
    public interface ITimeCounter
    {
        float Hertz { get; }
        event Action Beat;
    }
    
    /// <summary>
    /// ISP. <seealso cref="ITimeCounter"/>, <seealso cref="ITimeInjectable"/>.
    /// </summary>
    public interface ITimeCounterInjectable : ITimeCounter, ITimeInjectable { }
}