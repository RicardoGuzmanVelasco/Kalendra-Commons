using FluentAssertions;
using Kalendra.Commons.Runtime.Domain.Merge;
using Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Editor.Domain.Merge
{
    public class ColoredPieceTests
    {
        #region Equals
        [Test]
        public void Equals_IfTierAndIDsMatch()
        {
            var samePiece = Build.ColoredPiece().WithTier(1).WithPieceID("ID").WithColorID("ID").Build();
            ColoredPiece sut = Build.ColoredPiece().WithTier(1).WithPieceID("ID").WithColorID("ID");

            var resultEquals = sut.Equals(samePiece);

            resultEquals.Should().BeTrue();
        }

        [Test]
        public void NotEquals_IfNotSameTier()
        {
            var otherPiece = Build.ColoredPiece().WithTier(2).Build();
            ColoredPiece sut = Build.ColoredPiece().WithTier(1);

            var resultEquals = sut.Equals(otherPiece);

            resultEquals.Should().BeFalse();
        }
        
        [Test]
        public void NotEquals_IfNotSamePieceID()
        {
            var otherPiece = Build.ColoredPiece().WithPieceID("Other").Build();
            ColoredPiece sut = Build.ColoredPiece().WithPieceID("ID");

            var resultEquals = sut.Equals(otherPiece);

            resultEquals.Should().BeFalse();
        }
        
        [Test]
        public void NotEquals_IfNotSameColorID()
        {
            var otherPiece = Build.ColoredPiece().WithColorID("Other").Build();
            ColoredPiece sut = Build.ColoredPiece().WithColorID("ID");

            var resultEquals = sut.Equals(otherPiece);

            resultEquals.Should().BeFalse();
        }
        #endregion
    }
}