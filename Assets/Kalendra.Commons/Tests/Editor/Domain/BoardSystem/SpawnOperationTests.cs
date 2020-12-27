using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Kalendra.Commons.Runtime.Domain.BoardSystem.BoardOperations;
using Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts;
using NUnit.Framework;
using UnityEngine;

namespace Kalendra.Commons.Tests.Editor.Domain.BoardSystem
{
    public class SpawnOperationTests
    {
        #region IsAvailable
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
        #endregion

        #region Execute
        [Test]
        public async void Execute_WhenIsNotAvailable_ThrowsException()
        {
            //Arrange
            var someFullBoard = Build.Board().Build();
            someFullBoard.GetTile(0, 0).Content = Fake.TileContent_NotNull();

            var mockSpawnPolicy = Fake.SpawnOperatorPolicy();
            SpawnOperation sut = Build.SpawnOperation().WithSpawnPolicy(mockSpawnPolicy);
            
            //Act
            var act = sut.Execute(someFullBoard);

            //Assert
            act.Status.Should().Be(TaskStatus.Faulted);
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
        #endregion
    }
}