using System;
using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.Chess.Runtime.Domain
{
    public class ChessBoard : Board
    {
        readonly ChessBoardSetUp metaData = new ChessBoardSetUp();
        readonly ChessPieceFactory pieceFactory = new ChessPieceFactory();
        
        public ChessBoard() : base(8, 8) { }
        public ChessBoard(ChessBoardSetUp setup) : base(8, 8) => metaData = setup;
        public ChessBoard(ChessBoardState initialState) : this(initialState.Setup) => SettleInitialDisposition(initialState.Disposition);

        void SettleInitialDisposition(ChessBoardDisposition disposition)
        {
            foreach(var ((x, y), chessPieceDefinition) in disposition)
                tiles[(x, y)].Content = pieceFactory.Create(chessPieceDefinition);
        }

        public bool IsCastlingStillAvailable(ChessSet set)
        {
            switch(set)
            {
                case ChessSet.White:
                    return metaData.WhiteCastlingAvailable;
                case ChessSet.Black:
                    return metaData.BlackCastlingAvailable;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}