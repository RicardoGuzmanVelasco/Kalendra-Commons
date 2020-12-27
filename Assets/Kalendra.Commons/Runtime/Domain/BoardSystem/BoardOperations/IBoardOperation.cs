namespace Kalendra.Commons.Runtime.Domain.BoardSystem.BoardOperations
{
    public interface IBoardOperation
    {
        bool IsAvailable(IBoard targetBoard);
        
        void Execute(IBoard targetBoard); //TODO: somehow will return (or store after execute) BoardOperationResult.
        void Undo(IBoard targetBoard);
    }
}