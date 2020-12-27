using FluentAssertions;
using Kalendra.Commons.Runtime.Application.Merge;
using Kalendra.Commons.Runtime.Domain.Merge;
using Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Editor.Application
{
    public class MergeOperatorTests
    {
        [Test]
        public void Merge_ReturnsNullIfCanNotMerge()
        {
            var coloredPiece1 = Build.ColoredPiece().WithPieceID("1");
            var coloredPiece2 = Build.ColoredPiece().WithPieceID("2");
            MergeOperator sut = Build.MergeOperator();

            var result = sut.Merge(coloredPiece1, coloredPiece2);

            result.Should().BeNull();
        }

        [Test]
        public void Merge_ReturnsNextTierPiece_WhenMergingEquivalentPieces()
        {
            var piece1 = Build.ColoredPiece_Some().Build();
            var piece2 = Build.ColoredPiece_Some().Build();
            MergeOperator sut = Build.MergeOperator();

            var resultMerged = sut.Merge(piece1, piece2);

            resultMerged.Should().NotBeNull();
            resultMerged.Tier.Should().Be(piece1.Tier + 1);
            resultMerged.PieceID.Should().BeEquivalentTo(piece1.PieceID);
            resultMerged.ColorID.Should().BeEquivalentTo(piece1.ColorID);
        }

        [Test]
        public void Merge_ReturnsSameTierProducedColor_WhenMergingEquivalentPiecesDifferentColors()
        {
            //Arrange
            const string color1 = "1";
            const string color2 = "2";
            const string expectedColorResult = "result";

            var piece1 = Build.ColoredPiece_Some().WithColorID(color1).Build();
            var piece2 = Build.ColoredPiece_Some().WithColorID(color2).Build();
            
            MergeOperator sut = Build.MergeOperator()
                .WithColorProductions(Build.ColorProduction()
                    .WithOriginalColors(color1, color2)
                    .WithResultColor(expectedColorResult));
            
            //Act
            var resultMerged = sut.Merge(piece1, piece2);

            //Assert
            resultMerged.ColorID.Should().Be(expectedColorResult);
            resultMerged.Tier.Should().Be(piece1.Tier);
            resultMerged.PieceID.Should().Be(piece1.PieceID);
        }
    }
}