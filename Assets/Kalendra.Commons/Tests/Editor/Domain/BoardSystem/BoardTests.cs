using System;
using FluentAssertions;
using Kalendra.Commons.Runtime.Domain.BoardSystem;
using Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Editor.Domain.BoardSystem
{
    public class BoardTests
    {
        [Test]
        public void New_IsCreatedWithSize()
        {
            var (expectedSizeX, expectedSizeY) = (2, 3);
            Board sut = Build.Board().WithSize(expectedSizeX, expectedSizeY);

            var resultSize = sut.Size;
            
            resultSize.Should().BeEquivalentTo((expectedSizeX, expectedSizeY));
        }

        [Test]
        public void New_WithSize_NonPositive_ThrowsException()
        {
            Board sut;
            
            Action actFirstArg = () => sut = Build.Board().WithSize(-1, 2);
            Action actSecondArg = () => sut = Build.Board().WithSize(2, 0);

            actFirstArg.Should().Throw<ArgumentOutOfRangeException>();
            actSecondArg.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetTile_TileIsNotNull_ByDefault()
        {
            Board sut = Build.Board();

            var result = sut.GetTile(0, 0);

            result.Should().NotBeNull();
        }
    }
}