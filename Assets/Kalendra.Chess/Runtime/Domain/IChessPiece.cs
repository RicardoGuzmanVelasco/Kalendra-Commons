using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.Chess.Runtime.Domain
{
    public enum ChessSet
    {
        White,
        Black
    }

    public enum ChessPiece
    {
        King,
        Queen,
        Bishop,
        Knight,
        Rook,
        Pawn
    }

    public class ChessPieceDefinition
    {
        public ChessSet Set { get; }
        public ChessPiece Piece { get; }

        public ChessPieceDefinition(ChessSet set, ChessPiece piece)
        {
            Set = set;
            Piece = piece;
        }
    }
    
    public interface IChessPiece : ITileContent
    {
        ChessSet Set { get; }
        ChessPiece PieceType { get; }
        ChessAvailableMovements ListAvailableMovements(IBoard board, ITile tile);
    }
}