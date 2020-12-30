using System.Threading.Tasks;

namespace Kalendra.Commons.Runtime.Domain.Boundaries
{
    public interface IBoundaryOutputPort
    {
        Task Response();
    }

    public interface IBoundaryOutputPort<in T> where T : BoundaryResponseDTO
    {
        void Response(T responseDTO);
    }

    public abstract class BoundaryResponseDTO { }
}