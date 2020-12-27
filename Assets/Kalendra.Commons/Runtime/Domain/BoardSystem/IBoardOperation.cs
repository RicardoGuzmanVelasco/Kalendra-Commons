namespace Kalendra.Commons.Runtime.Domain.BoardSystem
{
    public interface IBoardOperation
    {
        BoardOperationResult Execute(IBoard targetBoard);
        void Undo(IBoard targetBoard);
    }
}