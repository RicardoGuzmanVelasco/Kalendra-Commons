namespace Kalendra.Time.Domain
{
    public interface IPausable
    {
        bool Paused { get; set; }
        void Stop();
    }
}