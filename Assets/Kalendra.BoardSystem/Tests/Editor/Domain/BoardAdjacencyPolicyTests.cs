using System.Linq;
using FluentAssertions;
using Kalendra.BoardSystem.Runtime.Domain.AdjacencyPolicy;
using Kalendra.BoardSystem.Tests.TestDataBuilders.StaticShortcuts;
using NUnit.Framework;

namespace Kalendra.BoardSystem.Tests.Editor
{
    public class BoardAdjacencyPolicyTests
    {
        #region Up
        [Test]
        public void Up_Null_ReturnsEmpty()
        {
            var board = Build.Board().Build();
            UpAdjacencyPolicy sut = new UpAdjacencyPolicy();

            var result = sut.GetAdjacentTiles(board, null);

            result.Should().BeEmpty();
        }

        [Test]
        public void Up_OutOfRange_ReturnsEmpty()
        {
            var board = Build.Board().Build();
            UpAdjacencyPolicy sut = new UpAdjacencyPolicy();

            var result = sut.GetAdjacentTiles(board, board[0, 0]);

            result.Should().BeEmpty();
        }

        [Test]
        public void Up_InRange_ReturnsTileAbove()
        {
            var board = Build.Board().WithSize(1, 2).Build();
            UpAdjacencyPolicy sut = new UpAdjacencyPolicy();

            var result = sut.GetAdjacentTiles(board, board[0, 0]);

            result.Single().Coords.Should().Be((0, 1));
        }
        #endregion
        
        #region Down
        [Test]
        public void Down_Null_ReturnsEmpty()
        {
            var board = Build.Board().Build();
            DownAdjacencyPolicy sut = new DownAdjacencyPolicy();

            var result = sut.GetAdjacentTiles(board, null);

            result.Should().BeEmpty();
        }

        [Test]
        public void Down_OutOfRange_ReturnsEmpty()
        {
            var board = Build.Board().Build();
            DownAdjacencyPolicy sut = new DownAdjacencyPolicy();

            var result = sut.GetAdjacentTiles(board, board[0, 0]);

            result.Should().BeEmpty();
        }

        [Test]
        public void Down_InRange_ReturnsTileBelow()
        {
            var board = Build.Board().WithSize(1, 2).Build();
            DownAdjacencyPolicy sut = new DownAdjacencyPolicy();

            var result = sut.GetAdjacentTiles(board, board[0, 1]);

            result.Single().Coords.Should().Be((0, 0));
        }
        #endregion
    }
}