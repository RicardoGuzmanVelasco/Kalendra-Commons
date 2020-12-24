using Kalendra.Commons.Runtime.Domain.BoardSystem;
using Kalendra.Commons.Tests.TestDataBuilders.Domain.BoardSystem;

namespace Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts
{
    internal static partial class Build
    {
        public static BoardBuilder Board() => BoardBuilder.New();
        public static Board Board_WithNoTiles() => BoardBuilder.BoardWithNoTiles();
    }
}