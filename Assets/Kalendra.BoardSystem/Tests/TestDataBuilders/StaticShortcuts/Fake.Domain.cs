using System.Threading.Tasks;
using Kalendra.Commons.Runtime.Application.BoardSystem;
using Kalendra.Commons.Runtime.Application.Merge;
using Kalendra.Commons.Runtime.Domain.BoardSystem;
using Kalendra.Commons.Runtime.Domain.BoardSystem.BoardOperations;
using Kalendra.Commons.Tests.TestDataBuilders.Domain.BoardSystem;
using NSubstitute;

namespace Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts
{
    //TODO: shortcuts to Fake MockBuilders.
    internal static partial class Fake
    {
        public static ITileContent TileContent_NotNull() => TileContentMockBuilder.New().Build();

        public static ISpawnOperatorPolicy SpawnOperatorPolicy()
        {
            var mockSpawnPolicy = Substitute.For<ISpawnOperatorPolicy>();
            var someContent = new ColoredPieceTileContent(Build.ColoredPiece());
            mockSpawnPolicy.SpawnContent().Returns(Task.FromResult((ITileContent) someContent));

            return mockSpawnPolicy;
        }

        public static IBoardOperation BoardOperation() => Substitute.For<IBoardOperation>();

        public static IBoardOperation[] BoardOperations(int count)
        {
            var collection = new IBoardOperation[count];
            for(var i = 0; i < collection.Length; i++)
                collection[i] = Substitute.For<IBoardOperation>();
            return collection;
        }
    }
}