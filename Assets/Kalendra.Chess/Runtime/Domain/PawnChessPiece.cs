namespace Kalendra.Chess.Runtime.Domain
{
    public class PawnChessPiece : AbstractChessPiece
    {
        public ChessSet Set { get; }

        public PawnChessPiece(ChessSet set) : base(set, ChessPiece.Pawn, new PawnMovement()) { }
    }
}