namespace Kalendra.Chess.Runtime.Domain
{
    public class BishopChessPiece : AbstractChessPiece
    {
        public ChessSet Set { get; }

        public BishopChessPiece(ChessSet set) : base(set, ChessPiece.Bishop, new BishopMovement()) { }
    }
}