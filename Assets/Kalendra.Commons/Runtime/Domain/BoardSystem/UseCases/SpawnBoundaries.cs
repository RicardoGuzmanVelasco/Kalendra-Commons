using Kalendra.Commons.Runtime.Domain.Boundaries;

namespace Kalendra.Commons.Runtime.Domain.BoardSystem.UseCases
{
    public interface ISpawnInputReceiver : IBoundaryInputPort { }
    
    public interface ISpawnOutputReceiver : IBoundaryOutputPort { }
    public interface ISpawnNotAvailableOutputReceiver : IBoundaryOutputPort { }
}