using System.Linq;
using FluentAssertions;
using Kalendra.Chess.Runtime.Domain;
using NUnit.Framework;

namespace Kalendra.Chess.Tests.Editor.Domain
{
    public class ChessBoardTests
    {
        #region Castling
        [Theory]
        public void IsCastlingStillAvailable_IsTrue_ByDefault(ChessSet set)
        {
            var sut = new ChessBoard();

            var resultCastlingAvailable = sut.IsCastlingStillAvailable(set);

            resultCastlingAvailable.Should().BeTrue();
        }

        [Test]
        public void IsCastlingStillAvailable_ModifiedByBoardSetup()
        {
            var setup = new ChessBoardSetUp {BlackCastlingAvailable = false, WhiteCastlingAvailable = true};
            var sut = new ChessBoard(setup);

            var whiteCastlingAvailable = sut.IsCastlingStillAvailable(ChessSet.White);
            var blackCastlingAvailable = sut.IsCastlingStillAvailable(ChessSet.Black);

            whiteCastlingAvailable.Should().BeTrue();
            blackCastlingAvailable.Should().BeFalse();
        }

        [Test, Category("TODO")]
        public void CastlingIsNotAvailable_AfterSetMovesKingOrBothRooks()
        {
            //store any rook movement. If both moved, state set castling to false. Same with king.
        }
        #endregion

        #region Disposition
        [Test]
        public void FromBoardState_WithEmptyDisposition_ThenBoardHasNotPieces()
        {
            var state = new ChessBoardState();
            var sut = new ChessBoard(state);

            var emptyPiecesCount = sut.ListAllEmptyTiles.Count();

            emptyPiecesCount.Should().Be(64);
        }

        [Theory]
        public void BoardSettlePieces_FromBoardStateDisposition_WithOnePiece(ChessSet set, ChessPiece piece)
        {
            //Arrange
            var disposition = new ChessBoardDisposition();
            disposition.SettlePiece(new ChessCoordinate('a', 1), new ChessPieceDefinition(set, piece));
            var sut = new ChessBoard(new ChessBoardState {Disposition = disposition});

            //Act
            var resultContent = sut[0, 0].Content as IChessPiece;

            //Assert
            resultContent.Set.Should().Be(set);
            resultContent.PieceType.Should().Be(piece);
        }
        #endregion
        
        #region ChessPiece shortcuts
        
        #endregion
    }
}