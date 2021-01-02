using Kalendra.Commons.Runtime.Domain.BoardSystem;
using Kalendra.Commons.Tests.TestDataBuilders.Domain.BoardSystem;

namespace Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts
{
    public static partial class Build
    {
        internal static BoardBuilder Board() => BoardBuilder.New();
        internal static Board Board_WithNoTiles() => BoardBuilder.BoardWithNoTiles();
        
        internal static BoardTileBuilder BoardTile() => BoardTileBuilder.New();

        internal static SpawnOperationBuilder SpawnOperation() => SpawnOperationBuilder.New();

        internal static BoardOperationsManagerBuilder BoardOperationsManager() => BoardOperationsManagerBuilder.New();
    }
}