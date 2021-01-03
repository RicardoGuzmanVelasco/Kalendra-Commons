﻿using NUnit.Framework;

namespace Kalendra.BoardSystem.Tests.Editor
{
    [Category("Integration")]
    public class SpawnInteractorTests
    {
        [Test, Category("TODO")]
        public async void Request_WhenBoardIsNotFull_SpawnsInEmptyTile()
        {
            // //Arrange
            // var someBoard = Build.Board().Build();
            //
            // IBoardOperation spawnOperation = Build.SpawnOperation().WithSpawnPolicy(Build.ColoredPieceSpawnOperator_WithSystemRandom()).Build();
            // var mockFactory = Substitute.For<IFactory<SpawnOperation>>();
            // mockFactory.Create().Returns(spawnOperation);
            //
            // var outputReceiverStub = Substitute.For<ISpawnUseCaseOutput>();
            // IBoundaryInputPort sut = new SpawnUseCaseInteractor(someBoard, mockFactory, outputReceiverStub);
            //
            // //Act
            // var resultEmptyTilesBefore = someBoard.ListAllEmptyTiles;
            // sut.Request();
            // await Task.Delay(1);
            // var resultEmptyTilesAfter = someBoard.ListAllEmptyTiles;
            //
            // //Assert
            // resultEmptyTilesBefore.Should().NotBeEmpty();
            // resultEmptyTilesAfter.Should().BeEmpty();
        }
        
        [Test, Category("TODO")]
        public async void Request_WhenBoardIsNotFull_CallsReceiverAfterSpawn()
        {
            // //Arrange
            // var someBoard = Build.Board().Build();
            // //TODO: Build.ColoredPiece --> mock.
            // IBoardOperation spawnOperation = Build.SpawnOperation().WithSpawnPolicy(Build.ColoredPieceSpawnOperator_WithSystemRandom()).Build();
            // var mockFactory = Substitute.For<IFactory<SpawnOperation>>();
            // mockFactory.Create().Returns(spawnOperation);
            //
            // var outputReceiverStub = Substitute.For<ISpawnUseCaseOutput>();
            // IBoundaryInputPort sut = new SpawnUseCaseInteractor(someBoard, mockFactory, outputReceiverStub);
            //
            // //Act
            // sut.Request();
            //
            // //Assert
            // await Task.Delay(1);
            // outputReceiverStub.Received().Response();
        }

        [Test, Category("TODO")]
        public async void Request_WhenBoardIsFull_DoesNotCallsReceiverAfterSpawn()
        {
            // //Arrange
            // var someBoard = Build.Board_WithNoTiles();
            //
            // IBoardOperation spawnOperation = Build.SpawnOperation().WithSpawnPolicy(Build.ColoredPieceSpawnOperator_WithSystemRandom()).Build();
            // var mockFactory = Substitute.For<IFactory<SpawnOperation>>();
            // mockFactory.Create().Returns(spawnOperation);
            //
            // var outputReceiverStub = Substitute.For<ISpawnUseCaseOutput>();
            // IBoundaryInputPort sut = new SpawnUseCaseInteractor(someBoard, mockFactory, outputReceiverStub);
            //
            // //Act
            // sut.Request();
            //
            // //Assert
            // await Task.Delay(1);
            // outputReceiverStub.DidNotReceive().Response();
        }
        
        [Test, Category("TODO")]
        public async void Request_WhenBoardIsFull_CallsNotAvailableReceiverAfterSpawn()
        {
            // //Arrange
            // var someBoard = Build.Board_WithNoTiles();
            //
            // IBoardOperation spawnOperation = Build.SpawnOperation().WithSpawnPolicy(Build.ColoredPieceSpawnOperator_WithSystemRandom()).Build();
            // var mockFactory = Substitute.For<IFactory<SpawnOperation>>();
            // mockFactory.Create().Returns(spawnOperation);
            //
            // var outputReceiverStub = Substitute.For<ISpawnUseCaseOutput>();
            // var outputNotAvailableReceiverStub = Substitute.For<ISpawnNotAvailableUseCaseOutput>();
            // IBoundaryInputPort sut = new SpawnUseCaseInteractor(someBoard, mockFactory, outputReceiverStub, outputNotAvailableReceiverStub);
            //
            // //Act
            // sut.Request();
            // await Task.Delay(1);
            //
            // //Assert
            // outputNotAvailableReceiverStub.Received().Response();
            // outputReceiverStub.DidNotReceive().Response();
        }
    }
}