using System;
using System.Threading.Tasks;
using Kalendra.Commons.Runtime.Domain.Merge;

namespace Kalendra.Commons.Runtime.Domain.BoardSystem.BoardOperations
{
    internal class MergeOperation : IBoardOperation
    {
        ITile originTile;
        ITile targetTile;

        IMergeOperatorPolicy mergePolicy;

        #region Constructors
        public MergeOperation(ITile originTile, ITile targetTile, IMergeOperatorPolicy mergePolicy)
        {
            AssertDifferentTiles(originTile, targetTile);
            
            this.originTile = originTile;
            this.targetTile = targetTile;
            this.mergePolicy = mergePolicy;
        }

        void AssertDifferentTiles(ITile tile1, ITile tile2)
        {
            if(tile1 == tile2)
                throw new InvalidOperationException("Can't merge the same tile");
        }
        #endregion

        public bool IsAvailable(IBoard targetBoard)
        {
            throw new NotImplementedException();
        }

#pragma warning disable 1998
        public async Task Execute(IBoard targetBoard)
#pragma warning restore 1998
        {
            //use mergePolicy. if merge is produced,store in target, clean merge in origin. 
            
            throw new System.NotImplementedException();
        }

#pragma warning disable 1998
        public async Task Undo(IBoard targetBoard)
#pragma warning restore 1998
        {
            throw new System.NotImplementedException();
        }
    }
}