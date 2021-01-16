using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.Chess.Runtime.Domain
{
    public enum ChessSet
    {
        White,
        Black
    }
    
    public interface IChessPiece : ITileContent
    {
        ChessSet Set { get; }
        ChessAvailableMovements ListAvailableMovements(IBoard board, ITile tile);
    }
}