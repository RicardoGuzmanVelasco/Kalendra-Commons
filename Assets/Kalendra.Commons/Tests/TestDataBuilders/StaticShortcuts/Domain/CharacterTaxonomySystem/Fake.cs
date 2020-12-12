using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;
using NSubstitute;

namespace Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts
{
    internal static partial class Fake
    {
        internal static IClassDependantUsable ClassDependantUsable_UsableByClass(params CharacterClass[] classesToReturn)
        {
            var mock = Substitute.For<IClassDependantUsable>();
            mock.AllowedClasses.ReturnsForAnyArgs(classesToReturn);

            return mock;
        }
    }
}