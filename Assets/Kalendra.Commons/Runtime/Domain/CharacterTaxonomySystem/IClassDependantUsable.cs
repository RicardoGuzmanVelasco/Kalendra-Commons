using System.Collections.Generic;

namespace Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem
{
    public interface IClassDependantUsable
    {
        IEnumerable<CharacterClass> AllowedClasses { get; }
    }
}