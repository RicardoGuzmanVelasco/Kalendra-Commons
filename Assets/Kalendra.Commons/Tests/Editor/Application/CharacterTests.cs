using System;
using FluentAssertions;
using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;
using Kalendra.Commons.Tests.TestDataBuilders.Domain.CharacterTaxonomySystem;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Editor.Application
{
    public class CharacterTests
    {
        [Test]
        public void Character_HasName()
        {
            const string expectedName = "Name";
            Character sut = CharacterBuilder.New().WithName(expectedName);

            var resultClass = sut.CharacterClass;

            resultClass.Should().Be(expectedName);
        }
        
        [Test]
        public void Character_HasClass()
        {
            var expectedClass = CharacterClassBuilder.New_Bard().Build();
            Character sut = CharacterBuilder.New().WithClass(expectedClass);

            var resultClass = sut.CharacterClass;

            resultClass.Should().Be(expectedClass);
        }
        
        [Test]
        public void Character_ByDefault_HasWeaponNullObjectPattern()
        {
            Character sut = CharacterBuilder.New();

            var defaultWeapon = sut.Weapon;

            defaultWeapon.Should().BeOfType<NullWeapon>();
        }

        [Test]
        public void Character_CanEquipWeapon_IfCharacterClassDoes()
        {
            throw new NotImplementedException();
        }
    }
}