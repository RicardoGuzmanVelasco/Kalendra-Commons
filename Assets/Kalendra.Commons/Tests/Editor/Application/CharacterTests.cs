using FluentAssertions;
using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;
using Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts;
using NSubstitute;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Editor.Application
{
    public class CharacterTests
    {
        [Test]
        public void Character_HasName()
        {
            const string expectedName = "Name";
            Character sut = Build.Character().WithName(expectedName);

            var resultName = sut.Name;

            resultName.Should().Be(expectedName);
        }

        [Test]
        public void Character_CanSetName()
        {
            const string expectedName = "Name";
            Character sut = Build.Character();

            var resultNameBefore = sut.Name;
            sut.Name = expectedName;
            var resultNameAfter = sut.Name;

            resultNameBefore.Should().NotBe(expectedName);
            resultNameAfter.Should().Be(expectedName);
        }

        [Test]
        public void Character_HasClass()
        {
            var expectedClass = Build.CharacterClass_Bard().Build();
            Character sut = Build.Character().WithClass(expectedClass);

            var resultClass = sut.Class;

            resultClass.Should().Be(expectedClass);
        }

        [Test]
        public void Character_HasWeaponNullObjectPattern_ByDefault()
        {
            Character sut = Build.Character();

            var defaultWeapon = sut.Weapon;

            defaultWeapon.Should().BeOfType<NullWeapon>();
        }

        [Test]
        public void Character_CanUseUsable_IfClassIsAllowedByUsable()
        {
            //Arrange
            var someClass = Build.CharacterClass_Bard();
            Character sut = Build.Character().WithClass(someClass);

            var mockUsableAlways = Fake.ClassDependantUsable_AlwaysUsable();

            //Act
            var resultCanUse = sut.CanUse(mockUsableAlways);

            //Assert
            resultCanUse.Should().BeTrue();
        }

        [Test]
        public void Character_CanNotUseUsable_IfClassIsNotAllowedByUsable()
        {
            //Arrange
            var someClass = Build.CharacterClass_Bard();
            Character sut = Build.Character().WithClass(someClass);

            var mockUsableNever = Fake.ClassDependantUsable_NeverUsable();

            //Act
            var resultCanUse = sut.CanUse(mockUsableNever);

            //Assert
            resultCanUse.Should().BeFalse();
        }
    }
}