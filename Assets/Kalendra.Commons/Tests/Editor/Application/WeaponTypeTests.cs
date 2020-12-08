using System;
using FluentAssertions;
using Kalendra.Commons.Runtime.Domain.CharacterTaxonomySystem;
using Kalendra.Commons.Tests.TestDataBuilders.Domain.CharacterTaxonomySystem;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Editor.Application
{
    public class WeaponTypeTests
    {
        [Test]
        public void WeaponType_HasID()
        {
            const string expectedID = "ID";
            WeaponType sut = WeaponTypeBuilder.New().WithID(expectedID);

            var result = sut.ID;

            result.Should().Be(expectedID);
        }

        [Test]
        public void WeaponType_CanBeUsedByClass_IfClassWasPassed()
        {
            var someClass = CharacterClassBuilder.New_Bard();
            WeaponType sut = WeaponTypeBuilder.New().WithAllowedClasses(someClass);

            var expectedIsUsable = sut.IsUsableByClass(someClass);

            expectedIsUsable.Should().BeTrue();
        }
        
        [Test]
        public void WeaponType_CanBeUsedByAnyClass_ByDefault()
        {
            var someClass = CharacterClassBuilder.New_Bard();
            WeaponType sut = WeaponTypeBuilder.New();

            var expectedIsUsable = sut.IsUsableByClass(someClass);

            expectedIsUsable.Should().BeTrue();
        }
        
        [Test]
        public void WeaponType_CanNotBeUsedByClass_IfAnyOtherClassWasPassed()
        {
            //Arrange
            var someClass = CharacterClassBuilder.New_Bard();
            var someOtherClass = CharacterClassBuilder.New().WithID("");
            
            WeaponType sut = WeaponTypeBuilder.New().WithAllowedClasses(someOtherClass);

            //Act
            var expectedIsUsable = sut.IsUsableByClass(someClass);

            //Assert
            expectedIsUsable.Should().BeFalse();
        }
    }
}