using System.Collections.Generic;
using System.Linq;
using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.Chess.Runtime.Domain
{
    public class ChessAvailableMovements
    {
        readonly List<List<ITile>> tilesByTrajectory;

        public ChessAvailableMovements(List<List<ITile>> tilesByTrajectory)
        {
            this.tilesByTrajectory = tilesByTrajectory;
        }

        public IEnumerable<ITile> AllCoords => tilesByTrajectory.SelectMany(list => list);
    }
}