using Kalendra.Commons.Runtime.Architecture.Boundaries;

namespace Kalendra.Commons.Runtime.Domain.BoardSystem.UseCases
{
    public interface ISpawnUseCaseInput : IBoundaryInputPort { }
    
    public interface ISpawnUseCaseOutput : IBoundaryOutputPort { }
    public interface ISpawnNotAvailableUseCaseOutput : IBoundaryOutputPort { }
}