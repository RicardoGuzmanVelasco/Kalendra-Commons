using FluentAssertions;
using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;
using Kalendra.Commons.Tests.TestDataBuilders.Application;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Runtime.Application
{
    public class CharacterTests
    {
        [Test]
        public void Character_HasClass()
        {
            var expectedClass = CharacterClassBuilder.New_Bard().Build();
            Character sut = CharacterBuilder.New().WithClass(expectedClass);

            var resultClass = sut.characterClass;

            resultClass.Should().Be(expectedClass);
        }
        
        [Test]
        public void Character_ByDefault_HasWeaponNullObjectPattern()
        {
            Character sut = CharacterBuilder.New();

            var defaultWeapon = sut.Weapon;

            defaultWeapon.Should().BeOfType<NullWeapon>();
        }
    }
}