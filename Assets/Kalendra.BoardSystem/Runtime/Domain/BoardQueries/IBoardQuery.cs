using System.Collections.Generic;
using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.BoardSystem.Runtime.Domain.BoardQueries
{
    
    public interface IBoardQuery<out T> where T : IBoardQueryResult 
    {
        T Request(IBoard board);
    }
    
    public interface IBoardQueryResult{ }

    public class TilesBoardQueryResult : IBoardQueryResult
    {
        public readonly IEnumerable<ITile> tiles;

        public TilesBoardQueryResult(IEnumerable<ITile> tiles)
        {
            this.tiles = tiles;
        }
    }
}