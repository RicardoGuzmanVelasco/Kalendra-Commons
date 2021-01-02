using System.Collections.Generic;

namespace Kalendra.CharacterTaxonomySystem.Runtime.Domain.Entities
{
    public interface IClassDependantUsable
    {
        IEnumerable<CharacterClass> AllowedClasses { get; }
    }
}