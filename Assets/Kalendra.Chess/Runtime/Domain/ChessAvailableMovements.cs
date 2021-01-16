using System.Collections.Generic;
using System.Linq;
using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.Chess.Runtime.Domain
{
    public class ChessAvailableMovements
    {
        readonly ICollection<IEnumerable<ITile>> tilesByTrajectory;

        public ChessAvailableMovements() : this(new List<IEnumerable<ITile>>()) { }
        public ChessAvailableMovements(ICollection<IEnumerable<ITile>> tilesByTrajectory)
        {
            this.tilesByTrajectory = tilesByTrajectory;
        }

        public IEnumerable<(int x, int y)> AllCoords => tilesByTrajectory.SelectMany(trajectory => trajectory.Select(tile => tile.Coords));

        public void AddNewTrajectory(params ITile[] tilesInTrajectory) => tilesByTrajectory.Add(tilesInTrajectory);
    }
}