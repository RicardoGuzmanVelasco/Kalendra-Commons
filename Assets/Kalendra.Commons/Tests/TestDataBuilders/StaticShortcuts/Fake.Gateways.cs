using Kalendra.BoardSystem.Tests.TestDataBuilders.Domain;
using Kalendra.Commons.Runtime.Architecture.Gateways;

namespace Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts
{
    internal static partial class Fake
    {
        public static IReadOnlyRepository<T> ReadOnlyRepository<T>() where T : new() => ReadOnlyRepositoryMockBuilder<T>.New().ReturnsDefaults();
    }
}