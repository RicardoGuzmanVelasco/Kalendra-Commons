using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.Chess.Runtime.Domain
{
    internal abstract class ChessPiece : IChessPiece
    {
        readonly IChessMovementStrategy movementStrategy;
        public ChessSet Set { get; }

        protected ChessPiece(ChessSet set, IChessMovementStrategy movementStrategy)
        {
            Set = set;
            this.movementStrategy = movementStrategy;
        }

        public ChessAvailableMovements ListAvailableMovements(Board board, ITile tile)
        {
            return movementStrategy.ListAvailableMovements(board, tile);
        }
    }
    
    internal class KnightChessPiece : ChessPiece
    {
        public ChessSet Set { get; }

        public KnightChessPiece() : this(ChessSet.White) { }
        public KnightChessPiece(ChessSet set) : base(set, new KnightMovement()) { }
    }
}