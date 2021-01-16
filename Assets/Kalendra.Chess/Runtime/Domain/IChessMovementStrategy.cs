using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.Chess.Runtime.Domain
{
    internal interface IChessMovementStrategy
    {
        ChessAvailableMovements ListAvailableMovements(Board board, ITile tile);
    }
}