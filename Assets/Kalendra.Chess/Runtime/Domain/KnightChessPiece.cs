namespace Kalendra.Chess.Runtime.Domain
{
    public class KnightChessPiece : ChessPiece
    {
        public ChessSet Set { get; }

        public KnightChessPiece(ChessSet set) : base(set, new KnightMovement()) { }
    }
}