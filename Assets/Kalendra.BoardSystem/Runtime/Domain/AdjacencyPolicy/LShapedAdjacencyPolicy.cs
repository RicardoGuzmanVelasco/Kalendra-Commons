using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.BoardSystem.Runtime.Domain.AdjacencyPolicy
{
    public class LShapedAdjacencyPolicy : IAdjacencyPolicy
    {
        public IEnumerable<ITile> GetAdjacentTiles(IBoard board, ITile tile)
        {
            if(tile is null)
                return Enumerable.Empty<ITile>();

            var allCoords = GetAllAdjacentCoords(tile.Coords);

            return allCoords
                .Where(coords => board.HasTile(coords.x, coords.y))
                .Select(coords => board[coords.x, coords.y]);
        }

        IEnumerable<(int x, int y)> GetAllAdjacentCoords((int x, int y) coords)
        {
            var (x, y) = coords;
            return new[]
            {
                (x - 1, y - 2),
                (x - 1, y + 2),
                (x + 1, y - 2),
                (x + 1, y + 2),
                (x - 2, y - 1),
                (x - 2, y + 1),
                (x + 2, y - 1),
                (x + 2, y + 1)
            };
        }
    }
}