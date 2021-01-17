using System;
using FluentAssertions;
using Kalendra.Chess.Runtime.Domain;
using BoardBuild = Kalendra.BoardSystem.Tests.TestDataBuilders.StaticShortcuts.Build;
using ChessBuild = Kalendra.Chess.Tests.TestDataBuilders.StaticShortcuts.Build;
using NUnit.Framework;

namespace Kalendra.Chess.Tests.Editor.Domain
{
    public class KingPieceTests
    {
        [Test]
        public void KingPiece_HasChessSet()
        {
            var sut = ChessBuild.KingPiece().WithSet(ChessSet.White).Build();
            
            var result = sut.Set;

            result.Should().Be(ChessSet.White);
        }
        
        [Test]
        public void AvailableMovements_OnNotTiledBoard_ReturnsEmpty()
        {
            var notTiledBoard = BoardBuild.Board().Build();
            var sut = ChessBuild.KingPiece().Build();

            var result = sut.ListAvailableMovements(notTiledBoard, notTiledBoard[0, 0]);

            result.AllCoords.Should().BeEmpty();
        }
        
        [Test]
        public void AvailableMovements_OnEmptyBoard_ReturnsNeighbourCoords()
        {
            var chessEmptyBoard = BoardBuild.Board().WithSize(3, 3).Build();
            var sut = ChessBuild.KingPiece().Build();

            var result = sut.ListAvailableMovements(chessEmptyBoard, chessEmptyBoard[1, 1]);

            result.AllCoords.Should().HaveCount(8);
            result.AllCoords.Should().Contain((0, 0));
            result.AllCoords.Should().Contain((0, 1));
            result.AllCoords.Should().Contain((0, 2));
            result.AllCoords.Should().Contain((1, 0));
            result.AllCoords.Should().Contain((1, 2));
            result.AllCoords.Should().Contain((2, 0));
            result.AllCoords.Should().Contain((2, 1));
            result.AllCoords.Should().Contain((2, 2));
        }
    }
}