using System.Collections.Generic;
using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.BoardSystem.Runtime.Domain.BoardQueries
{
    public interface IBoardQueryResult { }

    public class TilesBoardQueryResult : IBoardQueryResult
    {
        public readonly IEnumerable<ITile> tiles;

        public TilesBoardQueryResult(IEnumerable<ITile> tiles)
        {
            this.tiles = tiles;
        }
    }
}