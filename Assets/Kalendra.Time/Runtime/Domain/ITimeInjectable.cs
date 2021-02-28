using System;

namespace Kalendra.Time.Domain
{
    public interface ITimeInjectable
    {
        void InjectTime(TimeSpan timeToAdd);
    }
}