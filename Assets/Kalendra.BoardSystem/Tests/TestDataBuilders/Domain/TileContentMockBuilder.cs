using Kalendra.BoardSystem.Runtime.Domain.Entities;
using Kalendra.Commons.Tests.TestDataBuilders.Builders;

namespace Kalendra.Commons.Tests.TestDataBuilders.Domain.BoardSystem
{
    internal class TileContentMockBuilder : MockBuilder<ITileContent>
    {
        TileContentMockBuilder() { }
        
        #region ObjectMother/FactoryMethods
        public static TileContentMockBuilder New() => new TileContentMockBuilder();
        #endregion
    }
}