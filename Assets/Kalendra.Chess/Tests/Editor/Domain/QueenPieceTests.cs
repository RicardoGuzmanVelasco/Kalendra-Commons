using FluentAssertions;
using Kalendra.Chess.Runtime.Domain;
using NUnit.Framework;
using BoardBuild = Kalendra.BoardSystem.Tests.TestDataBuilders.StaticShortcuts.Build;
using ChessBuild = Kalendra.Chess.Tests.TestDataBuilders.StaticShortcuts.Build;

namespace Kalendra.Chess.Tests.Editor.Domain
{
    public class QueenPieceTests
    {
        [Test]
        public void QueenPiece_HasChessSet()
        {
            var sut = ChessBuild.QueenPiece().WithSet(ChessSet.White).Build();

            var result = sut.Set;

            result.Should().Be(ChessSet.White);
        }

        [Test]
        public void AvailableMovements_OnNotTiledBoard_ReturnsEmpty()
        {
            var notTiledBoard = BoardBuild.Board().Build();
            var sut = ChessBuild.QueenPiece().Build();

            var result = sut.ListAvailableMovements(notTiledBoard, notTiledBoard[0, 0]);

            result.AllCoords.Should().BeEmpty();
        }
        
        [Test]
        public void AvailableMovements_OneRowBoard_ReturnsAllRow()
        {
            var chessEmptyBoard = BoardBuild.Board().WithSize(5, 1).Build();
            var sut = ChessBuild.QueenPiece().Build();

            var result = sut.ListAvailableMovements(chessEmptyBoard, chessEmptyBoard[2, 0]);

            result.AllCoords.Should().HaveCount(4);
            result.AllCoords.Should().Contain((0, 0));
            result.AllCoords.Should().Contain((1, 0));
            result.AllCoords.Should().Contain((3, 0));
            result.AllCoords.Should().Contain((4, 0));
        }
    }
}