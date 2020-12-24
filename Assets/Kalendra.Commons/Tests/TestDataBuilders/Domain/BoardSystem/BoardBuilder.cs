using Kalendra.Commons.Runtime.Domain.BoardSystem;
using Kalendra.Commons.Tests.TestDataBuilders.Builders;

namespace Kalendra.Commons.Tests.TestDataBuilders.Domain.BoardSystem
{
    internal class BoardBuilder : Builder<Board>
    {
        int sizeX = 1, sizeY = 1;

        #region Fluent API
        public BoardBuilder WithSize(int sizeX, int sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            
            return this;
        }
        #endregion

        #region ObjectMother/FactoryMethods
        public static BoardBuilder New() => new BoardBuilder();
        #endregion

        #region Builder implementation
        public override Board Build() => new Board(sizeX, sizeY);
        #endregion
    }
}