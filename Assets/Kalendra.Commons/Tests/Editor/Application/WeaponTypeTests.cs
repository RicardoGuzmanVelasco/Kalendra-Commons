using FluentAssertions;
using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;
using Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Editor.Application
{
    public class WeaponTypeTests
    {
        [Test]
        public void WeaponType_HasID()
        {
            const string expectedID = "ID";
            WeaponType sut = Build.WeaponType().WithID(expectedID);

            var result = sut.ID;

            result.Should().Be(expectedID);
        }

        [Test]
        public void WeaponType_CanBeUsedByClass_IfClassWasPassed()
        {
            var someClass = Build.CharacterClass_Bard();
            WeaponType sut = Build.WeaponType().WithAllowedClasses(someClass);

            var expectedIsUsable = sut.IsUsableByClass(someClass);

            expectedIsUsable.Should().BeTrue();
        }
        
        [Test]
        public void WeaponType_CanBeUsedByAnyClass_ByDefault()
        {
            var someClass = Build.CharacterClass_Bard();
            WeaponType sut = Build.WeaponType();

            var expectedIsUsable = sut.IsUsableByClass(someClass);

            expectedIsUsable.Should().BeTrue();
        }
        
        [Test]
        public void WeaponType_CanNotBeUsedByClass_IfAnyOtherClassWasPassed()
        {
            //Arrange
            var someClass = Build.CharacterClass_Bard();
            var someOtherClass = Build.CharacterClass().WithID("");
            
            WeaponType sut = Build.WeaponType().WithAllowedClasses(someOtherClass);

            //Act
            var expectedIsUsable = sut.IsUsableByClass(someClass);

            //Assert
            expectedIsUsable.Should().BeFalse();
        }
    }
}