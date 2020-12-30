using System.Threading.Tasks;

namespace Kalendra.Commons.Runtime.Domain.Boundaries
{
    public interface IBoundaryInputPort
    {
        Task Request();
    }

    public interface IBoundaryInputPort<in T> where T : BoundaryRequestDTO
    {
        void Request(T requestDTO);
    }

    public abstract class BoundaryRequestDTO { }
}