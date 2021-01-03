namespace Kalendra.MergeSystem.Tests.TestDataBuilders.StaticShortcuts
{
    internal static partial class Fake
    {
        public static IReadOnlyRepository<T> ReadOnlyRepository<T>() where T : new() => ReadOnlyRepositoryMockBuilder<T>.New().ReturnsDefaults();
    }
}