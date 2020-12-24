using Kalendra.Commons.Tests.TestDataBuilders.Domain.BoardSystem;

namespace Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts
{
    internal static partial class Build
    {
        public static BoardBuilder Board() => BoardBuilder.New();
    }
}