namespace Kalendra.Chess.Runtime.Domain
{
    public class KingChessPiece : ChessPiece
    {
        public ChessSet Set { get; }

        public KingChessPiece(ChessSet set) : base(set, new KingMovement()) { }
    }
}