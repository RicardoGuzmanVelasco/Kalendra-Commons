using FluentAssertions;
using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;
using Kalendra.Commons.Tests.TestDataBuilders.Application;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Runtime.Application
{
    public class CharacterClassTests
    {
        [Test]
        public void CharacterClass_HasID()
        {
            const string characterID = "ID";
            CharacterClass sut = CharacterClassBuilder.New().WithID(characterID);

            var resultID = sut.ID;

            resultID.Should().BeEquivalentTo(characterID);
        }

        [Test]
        public void CharacterClass_HasEquipableWeaponTypes()
        {
            var weaponType = WeaponTypeBuilder.New_Axe().Build();
            CharacterClass sut = CharacterClassBuilder.New().WithEquipableWeaponTypes(weaponType);

            var resultEquipableWeaponTypes = sut.EquipableWeaponTypes;

            resultEquipableWeaponTypes.Should().Contain(weaponType);
            resultEquipableWeaponTypes.Should().HaveCount(1);
        }
    }
}