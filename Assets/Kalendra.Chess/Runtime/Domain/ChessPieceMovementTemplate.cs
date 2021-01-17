using System.Linq;
using Kalendra.BoardSystem.Runtime.Domain.AdjacencyPolicy;
using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.Chess.Runtime.Domain
{
    internal abstract class ChessPieceMovementTemplate : IChessMovementStrategy
    {
        readonly IAdjacencyPolicy adjacency;

        public ChessPieceMovementTemplate()
        {
            adjacency = GetAdjacencyPolicyTemplateMethod();
        }

        protected abstract IAdjacencyPolicy GetAdjacencyPolicyTemplateMethod();

        public ChessAvailableMovements ListAvailableMovements(IBoard board, ITile tile)
        {
            var availableMovements = new ChessAvailableMovements();

            var tiles = adjacency.GetAdjacentTiles(board, tile);
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