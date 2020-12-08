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
            const string expectedID = "Axe";
            WeaponType sut = WeaponTypeBuilder.New().WithID(expectedID);

            var result = sut.ID;

            result.Should().Be(expectedID);
        }

        [Test]
        public void WeaponType_CanBeUsedByAnyClass_ByDefault()
        {
            throw new NotImplementedException();
        }
    }
}