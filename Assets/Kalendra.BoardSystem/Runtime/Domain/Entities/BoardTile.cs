using System;

namespace Kalendra.BoardSystem.Runtime.Domain.Entities
{
    internal class BoardTile : ITile
    {
        public (int x, int y) Coords { get; }
        public ITileContent Content { get; set; } = new NullTileContent();

        #region Constructors/Init
        public BoardTile(int coordX, int coordY)
        {
            AssertNonNegativeCoords(coordX, coordY);
            Coords = (coordX, coordY);
        }

        static void AssertNonNegativeCoords(int coordX, int coordY)
        {
            if(coordX < 0 || coordY < 0)
                throw new ArgumentOutOfRangeException();
        }
        #endregion
    }
}