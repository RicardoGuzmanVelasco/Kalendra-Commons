using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Kalendra.Commons.Runtime.Application.BoardSystem;
using Kalendra.Commons.Runtime.Application.Merge;
using Kalendra.Commons.Runtime.Domain.BoardSystem;
using Kalendra.Commons.Runtime.Domain.BoardSystem.BoardOperations;
using Kalendra.Commons.Runtime.Domain.Merge;
using Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts;
using NSubstitute;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Editor.Domain.BoardSystem
{
    public class SpawnOperationTests
    {
        [Test]
        public void IsAvailable_IfBoardHasAnyEmptyTile()
        {
            var someEmptyBoard = Build.Board().Build();
            SpawnOperation sut = Build.SpawnOperation();

            var result = sut.IsAvailable(someEmptyBoard);

            result.Should().BeTrue();
        }

        [Test]
        public void IsNotAvailable_IfBoardHasNotAnyEmptyTile()
        {
            var someFullBoard = Build.Board_WithNoTiles();
            SpawnOperation sut = Build.SpawnOperation();

            var result = sut.IsAvailable(someFullBoard);

            result.Should().BeFalse();
        }

        [Test]
        public void Execute_WhenIsNotAvailable_DoesNothing()
        {
            var someFullBoard = Build.Board_WithNoTiles();
            SpawnOperation sut = Build.SpawnOperation();
            
            Action act = () => sut.Execute(someFullBoard);
            
            act.Should().NotThrow();
        }

        [Test]
        public async void Execute_WhenIsAvailable_SpawnsContent()
        {
            //Arrange
            var someEmptyBoard = Build.Board().Build();

            var mockSpawnPolicy = Fake.SpawnOperatorPolicy();
            SpawnOperation sut = Build.SpawnOperation().WithSpawnPolicy(mockSpawnPolicy);
            
            //Act
            await sut.Execute(someEmptyBoard);

            //Assert
            var expectedSpawnedContent = await mockSpawnPolicy.SpawnContent();
            var resultSpawnedContent = someEmptyBoard.GetTile(0, 0).Content;
            
            resultSpawnedContent.Should().Be(expectedSpawnedContent);
        }
    }
}