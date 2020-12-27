using System.Collections.Generic;

namespace Kalendra.Commons.Runtime.Domain.BoardSystem
{
    public interface IBoard
    {
        (int x, int y) Size { get; }

        bool HasTile(int i, int j);
        ITile GetTile(int i, int j);
        bool RemoveTile(int i, int j);
        bool AddTile(int i, int j);
        
        IEnumerable<(int x, int y)> ListAllEmptyTiles { get; }
    }
}