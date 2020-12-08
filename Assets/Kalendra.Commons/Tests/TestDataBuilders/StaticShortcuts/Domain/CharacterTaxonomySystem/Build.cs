using Kalendra.Commons.Tests.TestDataBuilders.Domain.CharacterTaxonomySystem;

namespace Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts
{
    internal static partial class Build
    {
        public static WeaponBuilder Weapon() => WeaponBuilder.New();

        public static WeaponTypeBuilder WeaponType() => WeaponTypeBuilder.New();
        public static WeaponTypeBuilder WeaponType_Axe() => WeaponTypeBuilder.New_Axe();

        public static CharacterClassBuilder CharacterClass() => CharacterClassBuilder.New();
        public static CharacterClassBuilder CharacterClass_Bard() => CharacterClassBuilder.New_Bard();
        
        public static CharacterBuilder Character() => CharacterBuilder.New();
    }
}