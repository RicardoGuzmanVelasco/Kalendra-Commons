using Kalendra.Commons.Runtime.Architecture.Patterns;

namespace Kalendra.Commons.Runtime.Domain.BoardSystem.BoardOperations
{
    public interface IBoardOperation : ICommandAsync<IBoard>
    {
        bool IsAvailable(IBoard targetBoard);
        
        //TODO: somehow will return (or store after execute) BoardOperationResult.
        //Task Execute(IBoard targetBoard);
    }
}