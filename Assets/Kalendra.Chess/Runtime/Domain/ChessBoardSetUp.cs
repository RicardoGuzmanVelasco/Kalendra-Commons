using System;
using System.Collections;
using System.Collections.Generic;

namespace Kalendra.Chess.Runtime.Domain
{
    public class ChessBoardSetUp
    {
        public bool WhiteCastlingAvailable { get; set; } = true;
        public bool BlackCastlingAvailable { get; set; } = true;
    }

    public class ChessBoardState
    {
        public ChessBoardSetUp Setup { get; set; } = new ChessBoardSetUp();
        public ChessBoardDisposition Disposition { get; set; } = new ChessBoardDisposition();
    }

    public class ChessBoardDisposition : IEnumerable<(ChessCoordinate, ChessPieceDefinition)>
    {
        readonly Dictionary<ChessCoordinate, ChessPieceDefinition> piecesInBoard = new Dictionary<ChessCoordinate, ChessPieceDefinition>();

        public void SettlePiece(ChessCoordinate where, ChessPieceDefinition piece)
        {
            if(piecesInBoard.ContainsKey(where))
                throw new InvalidOperationException($"Coord {where} was before occupied by {piecesInBoard[where]}.");

            piecesInBoard[where] = piece;
        }

        #region IEnumerable implementation
        public IEnumerator<(ChessCoordinate, ChessPieceDefinition)> GetEnumerator()
        {
            foreach(var tuple in piecesInBoard)
                yield return (tuple.Key, tuple.Value);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
    }

    /// <summary>
    /// A coordinate in chess-like format. Immutable & Value Object Pattern.
    /// </summary>
    public class ChessCoordinate
    {
        readonly char firstCoord;
        readonly int secondCoord;

        public ChessCoordinate(char firstCoord, int secondCoord)
        {
            AssertCoordsFormat(firstCoord, secondCoord);
            
            this.firstCoord = firstCoord;
            this.secondCoord = secondCoord;
        }
        
        /// <summary>
        /// Tuple implicit conversion.
        /// </summary>
        public void Deconstruct(out int x, out int y)
        {
            x = char.ToLower(firstCoord) - firstCoord;
            y = secondCoord - 1;
        }

        public override string ToString() => $"{char.ToLower(firstCoord)}{secondCoord}";

        #region Equality
        public override bool Equals(object obj)
        {
            return obj is ChessCoordinate other &&
                   firstCoord == other.firstCoord &&
                   secondCoord == other.secondCoord;
        }

        protected bool Equals(ChessCoordinate other)
        {
            return firstCoord == other.firstCoord && secondCoord == other.secondCoord;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (firstCoord.GetHashCode() * 397) ^ secondCoord;
            }
        }
        #endregion

        #region Asserts
        /// <summary>
        /// Limita el mínimo formato y no rango superior, para poder simular ajedrez de otros tamaños. 
        /// </summary>
        void AssertCoordsFormat(char coordLetter, int coordNumber)
        {
            if(!char.IsLetter(coordLetter))
                throw new FormatException("Any chess coord is a letter.");
            if(coordNumber < 1)
                throw new FormatException("Any chess coord starts at 1.");
        }
        #endregion
    }
}