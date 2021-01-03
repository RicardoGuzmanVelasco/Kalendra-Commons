using Kalendra.Commons.Runtime.Architecture.Boundaries;

namespace Kalendra.BoardSystem.Runtime.Domain.UseCases
{
    public interface ISpawnUseCaseInput : IBoundaryInputPort { }
    
    public interface ISpawnUseCaseOutput : IBoundaryOutputPort { }
    public interface ISpawnNotAvailableUseCaseOutput : IBoundaryOutputPort { }
}