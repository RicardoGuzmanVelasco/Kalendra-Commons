using System.Linq;
using Kalendra.BoardSystem.Runtime.Domain.AdjacencyPolicy;
using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.Chess.Runtime.Domain
{
    internal class KingMovement : IChessMovementStrategy
    {
        public ChessAvailableMovements ListAvailableMovements(IBoard board, ITile tile)
        {
            var availableMovements = new ChessAvailableMovements();

            var tiles = new LShapedAdjacencyPolicy().GetAdjacentTiles(board, tile);
            tiles = tiles.Where(potentialTile => !CoordsAreOccupiedBySameChessSet(tile, potentialTile));
            
            foreach(var tiletoAdd in tiles)
                availableMovements.AddNewTrajectory(tiletoAdd);
            
            return availableMovements;
        }

        //TODO: to SRP?
        /// <summary>
        /// Whether <see cref="targetTile"/> still contains any piece having the same set <see cref="originTile"/> has.
        /// Returns false if any tile hasn't a chess piece. 
        /// </summary>
        bool CoordsAreOccupiedBySameChessSet(ITile originTile, ITile targetTile)
        {
            return targetTile.Content is IChessPiece targetPiece &&
                   originTile.Content is IChessPiece selfPiece &&
                   targetPiece.Set == selfPiece.Set;
        }
    }
}