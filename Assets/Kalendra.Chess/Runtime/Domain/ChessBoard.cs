using System;
using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.Chess.Runtime.Domain
{
    public class ChessBoardSetUp
    {
        public bool WhiteCastlingAvailable { get; set; } = true;
        public bool BlackCastlingAvailable { get; set; } = true;
    }
    
    public class ChessBoard : Board
    {
        readonly ChessBoardSetUp state = new ChessBoardSetUp();
        
        public ChessBoard() : base(8, 8) { }
        public ChessBoard(ChessBoardSetUp setup) : base(8, 8) => state = setup;

        public bool IsCastlingStillAvailable(ChessSet set)
        {
            switch(set)
            {
                case ChessSet.White:
                    return state.WhiteCastlingAvailable;
                case ChessSet.Black:
                    return state.BlackCastlingAvailable;
                default:
                    throw new ArgumentOutOfRangeException(nameof(set), set, null);
            }
        }
    }
}