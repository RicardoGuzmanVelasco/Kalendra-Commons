﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kalendra.Commons.Runtime.Domain.BoardSystem.BoardOperations
{
    public class BoardOperationsManager
    {
        readonly Queue<IBoardOperation> scheduled = new Queue<IBoardOperation>();
        readonly Stack<IBoardOperation> executed = new Stack<IBoardOperation>();
        readonly Stack<IBoardOperation> undone = new Stack<IBoardOperation>();

        public IEnumerable<IBoardOperation> Scheduled => scheduled;


        public BoardOperationsManager(ICollection<IBoardOperation> begginingOperations = null)
        {
            if(begginingOperations?.Any() ?? false)
                scheduled = new Queue<IBoardOperation>(begginingOperations);
        }
        
        public void RegisterOperation(IBoardOperation operation)
        {
            scheduled.Enqueue(operation);
        }

        public void DoNext(IBoard board)
        {
            if(scheduled.Count == 0)
                return;
            
            var nextOperation = scheduled.Dequeue();
            executed.Push(nextOperation);
            
            nextOperation.Execute(board);
        }

        public void UndoLast(IBoard board)
        {
            if(executed.Count == 0)
                return;
            
            var lastOperation = executed.Pop();
            undone.Push(lastOperation);

            lastOperation.Undo(board);
        }

        public void RedoLast(IBoard board)
        {
            if(undone.Count == 0)
                return;

            var lastUndoneOperation = undone.Pop();
            executed.Push(lastUndoneOperation);

            lastUndoneOperation.Execute(board);
        }
    }
}