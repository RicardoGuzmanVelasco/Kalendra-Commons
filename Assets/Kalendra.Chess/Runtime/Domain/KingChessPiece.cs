namespace Kalendra.Chess.Runtime.Domain
{
    public class KingChessPiece : AbstractChessPiece
    {
        public KingChessPiece(ChessSet set) : base(set, ChessPiece.King, new KingMovement()) { }
    }
}