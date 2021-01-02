using System.Threading.Tasks;

namespace Kalendra.Commons.Runtime.Architecture.Boundaries
{
    public interface IBoundaryOutputPort
    {
        Task Response();
    }

    public interface IBoundaryOutputPort<in T> where T : IBoundaryResponseDTO
    {
        void Response(T responseDTO);
    }

    public interface IBoundaryResponseDTO { }
}