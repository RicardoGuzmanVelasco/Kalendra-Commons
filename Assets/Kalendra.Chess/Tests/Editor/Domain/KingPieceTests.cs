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
    }
}