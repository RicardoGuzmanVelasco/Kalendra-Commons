namespace Kalendra.Commons.Runtime.Domain.Boundaries
{
    public interface IBoundaryInputPort
    {
        void Request();
    }

    public interface IBoundaryInputPort<in T> where T : BoundaryRequestDTO
    {
        void Request(T requestDTO);
    }

    public abstract class BoundaryRequestDTO { }
}