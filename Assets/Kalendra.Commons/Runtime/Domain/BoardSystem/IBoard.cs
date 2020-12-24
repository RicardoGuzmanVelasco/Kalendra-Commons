using System;
using System.Collections.Generic;

namespace Kalendra.Commons.Runtime.Domain.BoardSystem
{
    public interface IBoard
    {
        (int, int) Size { get; }
        
        bool HasTile(int i, int j);
        ITile GetTile(int i, int j);
        bool RemoveTile(int i, int j);
        bool AddTile(int i, int j);
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
                tiles[(i, j)] = new BoardTile(i, j);
        }
        #endregion

        #region Tile manipulation
        public ITile GetTile(int i, int j)
        {
            return HasTile(i, j) ? tiles[(i, j)] : new NullTile();
        }

        public bool HasTile(int i, int j)
        {
            var (sizeX, sizeY) = Size;
            
            return 0 <= i && i < sizeX &&
                   0 <= j && j < sizeY &&
                   !(tiles[(i, j)] is NullTile);
        }

        public bool RemoveTile(int i, int j)
        {
            if(!HasTile(i, j) || GetTile(i, j) is NullTile)
                return false;
            
            tiles[(i, j)] = new NullTile();
            return true;
        }

        public bool AddTile(int i, int j)
        {
            if(HasTile(i, j))
                return false;

            tiles[(i, j)] = new BoardTile(i, j);
            return true;
        }
        #endregion
    }
}