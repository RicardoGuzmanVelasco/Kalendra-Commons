using System.Threading.Tasks;
using Kalendra.Commons.Runtime.Application.BoardSystem;
using Kalendra.Commons.Runtime.Application.Merge;
using Kalendra.Commons.Runtime.Domain.BoardSystem;
using Kalendra.Commons.Tests.TestDataBuilders.Domain.BoardSystem;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts
{
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
    }
}