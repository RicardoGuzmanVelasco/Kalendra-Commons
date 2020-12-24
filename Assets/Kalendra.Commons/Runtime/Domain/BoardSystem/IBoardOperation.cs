namespace Kalendra.Commons.Runtime.Domain.BoardSystem
{
    public interface IBoardOperation
    {
        BoardOperationResult Do();
        void Undo();
    }
}