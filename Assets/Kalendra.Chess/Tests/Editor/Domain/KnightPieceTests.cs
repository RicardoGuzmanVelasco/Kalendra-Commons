using System.Linq;
using FluentAssertions;
using Kalendra.Chess.Runtime.Domain;
using Kalendra.Chess.Tests.TestDataBuilders.StaticShortcuts;
using NUnit.Framework;
using BoardBuild = Kalendra.BoardSystem.Tests.TestDataBuilders.StaticShortcuts.Build;
using ChessBuild = Kalendra.Chess.Tests.TestDataBuilders.StaticShortcuts.Build;

namespace Kalendra.Chess.Tests.Editor.Domain
{
    public class KnightPieceTests
    {
        [Test]
        public void KnightPiece_HasChessSet()
        {
            var sut = ChessBuild.KnightPiece().WithSet(ChessSet.White).Build();
            
            var result = sut.Set;

            result.Should().Be(ChessSet.White);
        }
        
        [Test]
        public void AvailableMovements_OnNotTiledBoard_ReturnsEmpty()
        {
            var notTiledBoard = BoardBuild.Board().Build();
            var sut = ChessBuild.KnightPiece().Build();

            var result = sut.ListAvailableMovements(notTiledBoard, notTiledBoard[0, 0]);

            result.AllCoords.Should().BeEmpty();
        }

        [Test]
        public void AvailableMovements_OnEmptyBoard_ReturnsLCoords()
        {
            var chessEmptyBoard = BoardBuild.Board().WithSize(8, 8).Build(); //TODO: chessboard.
            var sut = ChessBuild.KnightPiece().Build();

            var result = sut.ListAvailableMovements(chessEmptyBoard, chessEmptyBoard[2, 2]);

            result.AllCoords.Should().HaveCount(8);
            result.AllCoords.Should().Contain((0, 1));
            result.AllCoords.Should().Contain((1, 0));
            result.AllCoords.Should().Contain((3, 0));
            result.AllCoords.Should().Contain((0, 3));
            result.AllCoords.Should().Contain((4, 1));
            result.AllCoords.Should().Contain((1, 4));
            result.AllCoords.Should().Contain((4, 3));
            result.AllCoords.Should().Contain((3, 4));
        }

        [Test]
        public void AvailableMovements_OnCorner_NotReturnsCoordsOutOfRange()
        {
            var chessEmptyBoard = BoardBuild.Board().WithSize(2, 3).Build();
            var sut = ChessBuild.KnightPiece().Build();

            var result = sut.ListAvailableMovements(chessEmptyBoard, chessEmptyBoard[0, 0]);

            result.AllCoords.Single().Should().Be((1, 2));
        }

        [Test]
        public void AvailableMovements_IncludesCoords_WithPieceOfDifferentSet()
        {
            //Arrange
            var someBoard = BoardBuild.Board().WithSize(2, 3).Build();
            someBoard[1, 2].Content = Fake.BlackPiece().Build();
            
            var sut = ChessBuild.KnightPiece().WithSet(ChessSet.White).Build();
            someBoard[0, 0].Content = sut;

            //Act
            var result = sut.ListAvailableMovements(someBoard, someBoard[2, 2]);
            
            //Assert
            result.AllCoords.Single().Should().Be((1, 2));
        }
        
        [Test]
        public void AvailableMovements_ExcludesCoords_WithPieceOfSameSet()
        {
            //Arrange
            var someBoard = BoardBuild.Board().WithSize(2, 3).Build();
            someBoard[1, 2].Content = Fake.WhitePiece().Build();
            
            var sut = ChessBuild.KnightPiece().WithSet(ChessSet.White).Build();
            someBoard[0, 0].Content = sut;

            //Act
            var result = sut.ListAvailableMovements(someBoard, someBoard[2, 2]);
            
            //Assert
            result.AllCoords.Should().BeEmpty();
        }
    }
}