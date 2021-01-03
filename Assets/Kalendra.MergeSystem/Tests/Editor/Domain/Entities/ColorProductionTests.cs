using NUnit.Framework;

namespace Kalendra.MergeSystem.Tests.Editor.Domain.Entities
{
    public class ColorProductionTests
    {
        [Test]
        public void ColorProductionTestsSimplePasses()
        {
            ColorProduction sut = Build.ColorProduction()
                .WithOriginalColors("blue", "green")
                .WithResultColor("cyan");

            var originalColors = sut.OriginalColors;
            var resultColor = sut.ResultColor;

            originalColors.Should().Contain("green").And.Contain("blue");
            resultColor.Should().Be("cyan");
        }
        
        [Test]
        public void CanProduce_IsFalseByDefault()
        {
            ColorProduction sut = Build.ColorProduction();

            var resultCanProduce = sut.CanProduce("green", "blue");

            resultCanProduce.Should().BeFalse();
        }

        [Test]
        public void CanProduce_RegardlessColorsOrder()
        {
            ColorProduction sut = Build.ColorProduction()
                .WithOriginalColors("blue", "green")
                .WithResultColor("cyan");

            var resultCanProduce = sut.CanProduce("green", "blue");

            resultCanProduce.Should().BeTrue();
        }

        [Test]
        public void CanProduce_IsFalse_IfAnyColorIsNotInProductionOriginal()
        {
            ColorProduction sut = Build.ColorProduction()
                .WithOriginalColors("blue", "green")
                .WithResultColor("cyan");

            var resultCanProduce = sut.CanProduce("green", "red");

            resultCanProduce.Should().BeFalse();
        }
    }
}