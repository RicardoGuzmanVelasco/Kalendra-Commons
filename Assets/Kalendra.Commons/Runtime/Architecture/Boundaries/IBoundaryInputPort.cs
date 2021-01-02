using System.Threading.Tasks;

namespace Kalendra.Commons.Runtime.Architecture.Boundaries
{
    public interface IBoundaryInputPort
    {
        Task Request();
    }

    public interface IBoundaryInputPort<in TArg> where TArg : IBoundaryRequestDTO
    {
        void Request(TArg requestDTO);
    }

    public interface IBoundaryRequestDTO { }
}