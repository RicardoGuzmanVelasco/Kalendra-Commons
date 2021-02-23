namespace Kalendra.Chess.Runtime.Domain
{
    public class QueenChessPiece : AbstractChessPiece
    {
        public QueenChessPiece(ChessSet set) : base(set, ChessPiece.Queen, new QueenMovement()) { }
    }
}