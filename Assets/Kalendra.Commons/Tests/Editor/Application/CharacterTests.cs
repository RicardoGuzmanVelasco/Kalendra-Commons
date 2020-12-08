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

            var resultName = sut.Name;

            resultName.Should().Be(expectedName);
        }

        [Test]
        public void Character_CanSetName()
        {
            const string expectedName = "Name";
            Character sut = CharacterBuilder.New();

            var resultNameBefore = sut.Name;
            sut.Name = expectedName;
            var resultNameAfter = sut.Name;

            resultNameBefore.Should().NotBe(expectedName);
            resultNameAfter.Should().Be(expectedName);
        }
        
        [Test]
        public void Character_HasClass()
        {
            var expectedClass = CharacterClassBuilder.New_Bard().Build();
            Character sut = CharacterBuilder.New().WithClass(expectedClass);

            var resultClass = sut.Class;

            resultClass.Should().Be(expectedClass);
        }
        
        [Test]
        public void Character_HasWeaponNullObjectPattern_ByDefault()
        {
            Character sut = CharacterBuilder.New();

            var defaultWeapon = sut.Weapon;

            defaultWeapon.Should().BeOfType<NullWeapon>();
        }
    }
}