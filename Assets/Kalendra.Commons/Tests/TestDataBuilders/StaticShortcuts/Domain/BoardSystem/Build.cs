using Kalendra.Commons.Runtime.Domain.BoardSystem;
using Kalendra.Commons.Tests.TestDataBuilders.Domain.BoardSystem;

namespace Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts
{
    internal static partial class Build
    {
        public static BoardBuilder Board() => BoardBuilder.New();
        public static Board Board_WithNoTiles() => BoardBuilder.BoardWithNoTiles();
        
        public static BoardTileBuilder BoardTile() => BoardTileBuilder.New();

        public static SpawnOperationBuilder SpawnOperation() => SpawnOperationBuilder.New();

        public static BoardOperationsManagerBuilder BoardOperationsManager() => BoardOperationsManagerBuilder.New();
    }
}