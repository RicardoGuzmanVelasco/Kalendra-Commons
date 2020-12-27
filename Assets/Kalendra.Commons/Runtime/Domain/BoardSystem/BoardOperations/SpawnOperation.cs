using System;
using System.Linq;
using System.Threading.Tasks;
using Kalendra.Commons.Runtime.Application.Merge;

namespace Kalendra.Commons.Runtime.Domain.BoardSystem.BoardOperations
{
    internal class SpawnOperation : IBoardOperation
    {
        readonly ISpawnOperatorPolicy spawnPolicy;

        public SpawnOperation(ISpawnOperatorPolicy spawnPolicy)
        {
            this.spawnPolicy = spawnPolicy;
        }

        #region IBoardOperation implementation
        public bool IsAvailable(IBoard targetBoard)
        {
            return targetBoard.ListAllEmptyTiles.Any();
        }

        public async Task Execute(IBoard targetBoard)
        {
            if(!IsAvailable(targetBoard))
                await Task.FromException(new InvalidOperationException());
            
            var (whereSpawnX, whereSpawnY) = spawnPolicy.SelectTileWhereSpawn(targetBoard).Coords;
            var spawnedContent = await spawnPolicy.SpawnContent();

            targetBoard.GetTile(whereSpawnX, whereSpawnY).Content = spawnedContent;
        }

        public async Task Undo(IBoard targetBoard)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}