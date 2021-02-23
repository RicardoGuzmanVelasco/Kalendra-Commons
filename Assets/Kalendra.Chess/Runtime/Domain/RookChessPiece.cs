namespace Kalendra.Chess.Runtime.Domain
{
    public class RookChessPiece : AbstractChessPiece
    {
        public ChessSet Set { get; }

        public RookChessPiece(ChessSet set) : base(set, ChessPiece.Rook, new RookMovement()) { }
    }
}