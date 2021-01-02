using System;
using FluentAssertions;
using Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts;
using NUnit.Framework;

namespace Kalendra.BoardSystem.Tests.Editor
{
    public class BoardTileTests
    {
        [Test]
        public void New_WithNegativeCoords_ThrowsException()
        {
            BoardTile sut;
            
            Action act = () => sut = Build.BoardTile().WithCoords(-1, -1);

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Coords_AreImmutable_SinceConstructor()
        {
            BoardTile sut = Build.BoardTile().WithCoords(2, 3);

            var result = sut.Coords;

            result.Should().BeEquivalentTo((2, 3));
        }

        [Test]
        public void Content_IsNullContent_ByDefault()
        {
            BoardTile sut = Build.BoardTile();

            var result = sut.Content;

            result.Should().BeOfType<NullTileContent>();
        }
    }
}