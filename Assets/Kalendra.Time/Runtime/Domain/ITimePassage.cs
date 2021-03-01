using System;

namespace Kalendra.Time.Domain
{
    public interface ITimePassage
    {
        DateTime CurrentDate { get; }
        DateTime InitialDate { get; }
        
        TimeSpan TotalElapsedTime { get; }
        
        event Action OnNewSecond;
    }
    
    public interface ITimePassageInjectable : ITimePassage, ITimeInjectable { }
}