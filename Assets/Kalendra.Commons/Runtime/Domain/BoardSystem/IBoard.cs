using System;
using System.Collections.Generic;

namespace Kalendra.Commons.Runtime.Domain.BoardSystem
{
    public interface IBoard
    {
        (int, int) Size { get; }
    }

    internal class Board : IBoard
    {
        public (int, int) Size { get; }
        readonly Dictionary<(int, int), ITile> tiles = new Dictionary<(int, int), ITile>();

        #region Constructors/Init
        public Board(int sizeX, int sizeY)
        {
            AssertPositiveSize(sizeX, sizeY);
            
            Size = (sizeX, sizeY);
            InitTiles();
        }

        static void AssertPositiveSize(int sizeX, int sizeY)
        {
            if(sizeX < 1 || sizeY < 1)
                throw new ArgumentOutOfRangeException();
        }

        void InitTiles()
        {
            var (sizeX, sizeY) = Size;

            for(var i = 0; i < sizeX; i++)
            for(var j = 0; j < sizeY; j++)
                tiles[(i, j)] = new NullTile();
        }
        #endregion

        public ITile GetTile(int i, int j)
        {
            return tiles[(i, j)];
        }
    }
}