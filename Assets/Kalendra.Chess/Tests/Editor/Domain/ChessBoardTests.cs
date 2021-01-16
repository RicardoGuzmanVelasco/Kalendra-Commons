using FluentAssertions;
using Kalendra.Chess.Runtime.Domain;
using NUnit.Framework;

namespace Kalendra.Chess.Tests.Editor.Domain
{
    public class ChessBoardTests
    {
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
    }
}