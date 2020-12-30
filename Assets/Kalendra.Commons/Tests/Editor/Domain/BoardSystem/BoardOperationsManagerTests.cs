using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Kalendra.Commons.Runtime.Domain.BoardSystem.BoardOperations;
using Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts;
using NSubstitute;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Editor.Domain.BoardSystem
{
    public class BoardOperationsManagerTests
    {
        #region New
        [Test]
        public void New_ReceivesOptionalOperationCollection()
        {
            var operationMocks = Fake.BoardOperations(2);

            BoardOperationsManager sut = Build.BoardOperationsManager().WithOperations(operationMocks);

            sut.Scheduled.Should().ContainInOrder(operationMocks[0], operationMocks[1]);
        }

        [Test]
        public void RegisterOperation_ThenOperationIsAdded()
        {
            var operationMock = Fake.BoardOperation();
            BoardOperationsManager sut = Build.BoardOperationsManager().WithOperations(operationMock);

            sut.RegisterOperation(operationMock);

            sut.Scheduled.Should().Contain(operationMock);
        }
        #endregion

        #region Do
        [Test]
        public void DoNext_CallsOperationExecution()
        {
            var someBoard = Build.Board().Build();
            var operationMock = Fake.BoardOperation();
            BoardOperationsManager sut = Build.BoardOperationsManager().WithOperations(operationMock);

            sut.DoNext(someBoard);

            operationMock.Received().Execute(someBoard);
        }

        [Test]
        public void DoNext_Twice_RegisteredTwoOperations()
        {
            var someBoard = Build.Board().Build();
            var operationMocks = Fake.BoardOperations(2);
            BoardOperationsManager sut = Build.BoardOperationsManager().WithOperations(operationMocks);

            sut.DoNext(someBoard);
            sut.DoNext(someBoard);

            operationMocks[0].Received().Execute(someBoard);
            operationMocks[1].Received().Execute(someBoard);
            
        }
        #endregion

        #region Undo
        [Test]
        public void UndoLast_AfterDoAnOperation_ThenUndoThatOperation()
        {
            var someBoard = Build.Board().Build();
            var operationMock = Fake.BoardOperation();
            BoardOperationsManager sut = Build.BoardOperationsManager().WithOperations(operationMock);

            sut.DoNext(someBoard);
            sut.UndoLast(someBoard);

            operationMock.Received().Undo(someBoard);
        }

        [Test]
        public void UndoLast_DoesNothing_OnNotExecutedOperations()
        {
            //Arrange
            var someBoard = Build.Board().Build();
            var notExecutedOperationMock = Fake.BoardOperation();

            BoardOperationsManager sut = Build.BoardOperationsManager().WithOperations(Fake.BoardOperation());
            sut.DoNext(someBoard);
            sut.RegisterOperation(notExecutedOperationMock);

            //Act
            sut.UndoLast(someBoard);
            sut.UndoLast(someBoard);

            //Assert
            notExecutedOperationMock.DidNotReceive().Undo(someBoard);
        }
        #endregion

        #region Redo
        [Test]
        public void RedoLast_DoesNothing_IfNoOperationWasDone()
        {
            //Arrange
            var someBoard = Build.Board().Build();
            var notDoneOperationMock = Fake.BoardOperation();
            
            BoardOperationsManager sut = Build.BoardOperationsManager().WithOperations(notDoneOperationMock);
            
            //Act
            sut.RedoLast(someBoard);

            //Assert
            notDoneOperationMock.DidNotReceive().Execute(someBoard);
        }
        
        [Test]
        public void RedoLast_DoesNothing_IfNoOperationWasUndone()
        {
            //Arrange
            var someBoard = Build.Board().Build();
            var notUndoneOperationMock = Fake.BoardOperation();
            
            BoardOperationsManager sut = Build.BoardOperationsManager().WithOperations(notUndoneOperationMock);
            sut.DoNext(someBoard);
            notUndoneOperationMock.ClearReceivedCalls();
                        
            //Act
            sut.RedoLast(someBoard);

            //Assert
            notUndoneOperationMock.DidNotReceive().Execute(someBoard);
        }
        
        [Test]
        public void RedoLast_WhenOperationWasUndone_CallsThatOperationExecution()
        {
            //Arrange
            var someBoard = Build.Board().Build();
            var undoneOperationMock = Fake.BoardOperation();
            
            BoardOperationsManager sut = Build.BoardOperationsManager().WithOperations(undoneOperationMock);
            sut.DoNext(someBoard);
            sut.UndoLast(someBoard);
            undoneOperationMock.ClearReceivedCalls();
                        
            //Act
            sut.RedoLast(someBoard);

            //Assert
            undoneOperationMock.Received().Execute(someBoard);
        }
        #endregion
    }
}