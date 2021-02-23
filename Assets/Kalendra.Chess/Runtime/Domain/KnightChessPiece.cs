namespace Kalendra.Chess.Runtime.Domain
{
    public class KnightChessPiece : AbstractChessPiece
    {
        public ChessSet Set { get; }

        public KnightChessPiece(ChessSet set) : base(set, ChessPiece.Knight, new KnightMovement()) { }
    }
}