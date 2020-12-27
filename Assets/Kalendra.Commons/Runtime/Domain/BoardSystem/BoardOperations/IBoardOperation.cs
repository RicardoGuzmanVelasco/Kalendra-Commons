using System.Threading.Tasks;

namespace Kalendra.Commons.Runtime.Domain.BoardSystem.BoardOperations
{
    public interface IBoardOperation
    {
        bool IsAvailable(IBoard targetBoard);
        
        Task Execute(IBoard targetBoard); //TODO: somehow will return (or store after execute) BoardOperationResult.
        Task Undo(IBoard targetBoard);
    }
}