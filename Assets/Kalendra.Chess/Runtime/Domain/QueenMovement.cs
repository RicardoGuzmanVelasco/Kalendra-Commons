using Kalendra.BoardSystem.Runtime.Domain.AdjacencyPolicy;
using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.Chess.Runtime.Domain
{
    internal class QueenMovement : IChessMovementStrategy
    {
        public ChessAvailableMovements ListAvailableMovements(IBoard board, ITile tile)
        {
            var result = new ChessAvailableMovements();

                
            
            return result;
        }
    }
}