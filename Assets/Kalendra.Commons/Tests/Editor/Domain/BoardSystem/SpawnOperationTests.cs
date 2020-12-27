using FluentAssertions;
using Kalendra.BoardCore.Domain.Services;
using Kalendra.Commons.Runtime.Application.Merge;
using Kalendra.Commons.Runtime.Domain.BoardSystem.BoardOperations;
using Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts;
using NSubstitute;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Editor.Domain.BoardSystem
{
    public class SpawnOperationTests
    {
        [Test]
        public void SpawnOperation_IsAvailable_IfBoardHasAnyEmptyTile()
        {
            var emptyBoard = Build.Board().Build();
            SpawnOperation sut = Build.SpawnOperation();

            var result = sut.IsAvailable(emptyBoard);

            result.Should().BeTrue();
        }

        [Test]
        public void SpawnOperation_IsNotAvailable_IfBoardHasNotAnyEmptyTile()
        {
            var fullBoard = Build.Board_WithNoTiles();
            SpawnOperation sut = Build.SpawnOperation();

            var result = sut.IsAvailable(fullBoard);

            result.Should().BeFalse();
        }
    }
}