using Kalendra.Commons.Runtime.Domain.BoardSystem;
using Kalendra.Commons.Tests.TestDataBuilders.Domain.BoardSystem;

namespace Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts
{
    internal static partial class Fake
    {
        public static ITileContent TileContent_NotNull() => TileContentMockBuilder.New().Build();
    }
}