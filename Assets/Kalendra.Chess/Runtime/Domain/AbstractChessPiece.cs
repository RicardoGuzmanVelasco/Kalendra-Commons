using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.Chess.Runtime.Domain
{
    public abstract class AbstractChessPiece : IChessPiece
    {
        readonly IChessMovementStrategy movementStrategy;
        readonly ChessPieceDefinition definition;

        public ChessSet Set => definition.Set;
        public ChessPiece PieceType => definition.Piece;

        protected AbstractChessPiece(ChessSet set, ChessPiece type, IChessMovementStrategy movementStrategy)
        {
            definition = new ChessPieceDefinition(set, type);
            this.movementStrategy = movementStrategy;
        }

        public ChessAvailableMovements ListAvailableMovements(IBoard board, ITile tile)
        {
            return movementStrategy.ListAvailableMovements(board, tile);
        }
    }
}