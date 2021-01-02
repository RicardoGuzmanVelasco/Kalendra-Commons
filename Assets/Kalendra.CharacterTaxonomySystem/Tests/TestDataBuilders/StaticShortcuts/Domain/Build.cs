using Kalendra.CharacterTaxonomySystem.Tests.TestDataBuilders.Domain;

namespace Kalendra.CharacterTaxonomySystem.Tests.TestDataBuilders.StaticShortcuts
{
    public static partial class Build
    {
        internal static WeaponBuilder Weapon() => WeaponBuilder.New();

        internal static WeaponTypeBuilder WeaponType() => WeaponTypeBuilder.New();
        internal static WeaponTypeBuilder WeaponType_Axe() => WeaponTypeBuilder.New_Axe();

        internal static CharacterClassBuilder CharacterClass() => CharacterClassBuilder.New();
        internal static CharacterClassBuilder CharacterClass_Bard() => CharacterClassBuilder.New_Bard();
        
        internal static CharacterBuilder Character() => CharacterBuilder.New();
    }
}