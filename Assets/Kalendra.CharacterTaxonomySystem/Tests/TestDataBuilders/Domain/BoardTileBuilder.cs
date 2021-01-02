using Kalendra.Commons.Runtime.Domain.BoardSystem;
using Kalendra.Commons.Tests.TestDataBuilders.Builders;

namespace Kalendra.Commons.Tests.TestDataBuilders.Domain.BoardSystem
{
    internal class BoardTileBuilder : Builder<BoardTile>
    {
        int coordX, coordY;        

        #region Fluent API
        public BoardTileBuilder WithCoords(int x, int y)
        {
            coordX = x;
            coordY = y;
            
            return this;
        }
        #endregion

        #region ObjectMother/FactoryMethods
        public static BoardTileBuilder New() => new BoardTileBuilder();
        #endregion

        #region Builder implementation
        public override BoardTile Build() => new BoardTile(coordX, coordY);
        #endregion
    }
}