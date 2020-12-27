using System;
using System.Linq;
using Kalendra.Commons.Runtime.Application.Merge;

namespace Kalendra.Commons.Runtime.Domain.BoardSystem.BoardOperations
{
    class SpawnOperation : IBoardOperation
    {
        ISpawnOperatorPolicy spawnPolicy;

        public SpawnOperation(ISpawnOperatorPolicy spawnPolicy)
        {
            this.spawnPolicy = spawnPolicy;
        }

        #region IBoardOperation implementation
        public bool IsAvailable(IBoard targetBoard)
        {
            return targetBoard.ListAllEmptyTiles.Any();
        }

        public void Execute(IBoard targetBoard)
        {
            //select tile where spawn and content to spawn from SpawnOperator;
            //targetBoard[targetTile].Content = spawnedContent;
            throw new NotImplementedException();
        }

        public void Undo(IBoard targetBoard)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}