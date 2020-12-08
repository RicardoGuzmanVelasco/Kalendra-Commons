namespace Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem
{
    internal interface IClassDependantUsable
    {
        bool IsUsableByClass(CharacterClass @class);
    }
}