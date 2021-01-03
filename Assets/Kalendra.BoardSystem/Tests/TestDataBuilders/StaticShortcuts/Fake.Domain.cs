using System.Threading.Tasks;
using Kalendra.BoardSystem.Runtime.Domain.Entities;
using Kalendra.BoardSystem.Runtime.Domain.Entities.BoardOperations;
using Kalendra.BoardSystem.Runtime.Domain.Policy;
using Kalendra.BoardSystem.Tests.TestDataBuilders.Domain;
using NSubstitute;

namespace Kalendra.BoardSystem.Tests.TestDataBuilders.StaticShortcuts
{
    //TODO: shortcuts to Fake MockBuilders.
    internal static partial class Fake
    {
        public static ITile Tile() => TileMockBuilder.New().Build();
        
        public static ITileContent TileContent_NotNull() => TileContentMockBuilder.New().Build();

        public static ISpawnOperatorPolicy SpawnOperatorPolicy()
        {
            var mockSpawnPolicy = Substitute.For<ISpawnOperatorPolicy>();
            var someContent = TileContent_NotNull(); //TODO.
            mockSpawnPolicy.SpawnContent().Returns(Task.FromResult(someContent), Task.FromResult(someContent));

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