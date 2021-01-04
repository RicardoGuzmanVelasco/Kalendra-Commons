using System.Collections.Generic;
using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.BoardSystem.Runtime.Domain.AdjacencyPolicy
{
    public class DownAdjacencyPolicy : IAdjacencyPolicy
    {
        public IEnumerable<ITile> GetAdjacentTiles(IBoard board, ITile tile)
        {
            if(tile is null)
                yield break;

            var (x, y) = GetAdjacentCoords(tile.Coords);
            
            if(!board.HasTile(x, y))
                yield break;
            
            yield return board[x, y];
        }

        (int x, int y) GetAdjacentCoords((int x, int y) coords)
        {
            return (coords.x, coords.y - 1);
        }
    }
}