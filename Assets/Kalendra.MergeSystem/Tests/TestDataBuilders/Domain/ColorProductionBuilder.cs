using Kalendra.MergeSystem.Runtime.Domain.Entities;

namespace Kalendra.MergeSystem.Tests.TestDataBuilders.Domain
{
    internal class ColorProductionBuilder : Builder<ColorProduction>
    {
        string[] originalColors = {};
        string resultColor = "";

        ColorProductionBuilder() { }

        public ColorProductionBuilder WithOriginalColors(params string[] originalColors)
        {
            this.originalColors = originalColors;
            return this;
        }
        
        public ColorProductionBuilder WithResultColor(string resultColor)
        {
            this.resultColor = resultColor;
            return this;
        }

        public static ColorProductionBuilder New() => new ColorProductionBuilder();
        
        public override ColorProduction Build() => new ColorProduction(originalColors, resultColor);
    }
}