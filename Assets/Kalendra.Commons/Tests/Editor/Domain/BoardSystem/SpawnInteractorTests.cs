using System.Threading.Tasks;
using FluentAssertions;
using Kalendra.Commons.Runtime.Domain.BoardSystem.BoardOperations;
using Kalendra.Commons.Runtime.Domain.BoardSystem.UseCases;
using Kalendra.Commons.Runtime.Domain.Boundaries;
using Kalendra.Commons.Runtime.Domain.Patterns;
using Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts;
using NSubstitute;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Editor.Domain.BoardSystem
{
    [Category("Integration")]
    public class SpawnInteractorTests
    {
        [Test]
        public async void Request_WhenBoardIsNotFull_SpawnsInEmptyTile()
        {
            //Arrange
            var someBoard = Build.Board().Build();
            
            IBoardOperation spawnOperation = Build.SpawnOperation().WithSpawnPolicy(Build.ColoredPieceSpawnOperator_WithSystemRandom()).Build();
            var mockFactory = Substitute.For<IFactory<SpawnOperation>>();
            mockFactory.Create().Returns(spawnOperation);

            var boundaryOutputStub = Substitute.For<IBoundaryOutputPort>();
            IBoundaryInputPort sut = new SpawnInteractor(someBoard, mockFactory, boundaryOutputStub);

            //Act
            var resultEmptyTilesBefore = someBoard.ListAllEmptyTiles;
            sut.Request();
            var resultEmptyTilesAfter = someBoard.ListAllEmptyTiles;

            //Assert
            resultEmptyTilesBefore.Should().NotBeEmpty();
            await Task.Delay(1);
            boundaryOutputStub.Received().Response();
            resultEmptyTilesAfter.Should().BeEmpty();
        }
    }
}