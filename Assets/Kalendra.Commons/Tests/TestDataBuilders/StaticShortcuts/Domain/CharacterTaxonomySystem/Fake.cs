using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;
using NSubstitute;

namespace Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts
{
    internal static partial class Fake
    {
        internal static IClassDependantUsable ClassDependantUsable_AlwaysUsable()
        {
            var mock = Substitute.For<IClassDependantUsable>();
            mock.IsUsableByClass(default).ReturnsForAnyArgs(true);

            return mock;
        }
        
        internal static IClassDependantUsable ClassDependantUsable_NeverUsable()
        {
            var mock = Substitute.For<IClassDependantUsable>();
            mock.IsUsableByClass(default).ReturnsForAnyArgs(false);

            return mock;
        }
    }
}