using System.Linq;
using FluentAssertions;
using Kalendra.BoardSystem.Tests.TestDataBuilders.StaticShortcuts;
using Kalendra.Chess.Runtime.Domain;
using NUnit.Framework;

namespace Kalendra.Chess.Tests.Editor.Domain
{
    public class HorseMovementTests
    {
        [Test]
        public void HorseMovement_OnNotTiledBoard_ReturnsEmpty()
        {
            var notTiledBoard = Build.Board().Build();
            var sut = new HorseMovement();

            var result = sut.ListAvailableMovements(notTiledBoard, notTiledBoard[0, 0]);

            result.AllCoords.Should().BeEmpty();
        }

        [Test]
        public void HorseMovement_OnEmptyBoard_ReturnsLCoords()
        {
            var chessEmptyBoard = Build.Board().WithSize(8, 8).Build();
            var sut = new HorseMovement();

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
        public void HorseMovement_OnCorner_NotReturnsCoordsOutOfRange()
        {
            var chessEmptyBoard = Build.Board().WithSize(2, 3).Build();
            var sut = new HorseMovement();

            var result = sut.ListAvailableMovements(chessEmptyBoard, chessEmptyBoard[0, 0]);

            result.AllCoords.Single().Should().Be((1, 2));
        }
    }
}