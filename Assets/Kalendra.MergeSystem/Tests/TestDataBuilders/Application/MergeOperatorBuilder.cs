using System.Collections.Generic;
using Kalendra.Commons.Tests.TestDataBuilders.Builders;
using Kalendra.MergeSystem.Runtime.Application;
using Kalendra.MergeSystem.Runtime.Domain.Entities;

namespace Kalendra.MergeSystem.Tests.TestDataBuilders.Application
{
    internal class MergeOperatorBuilder : Builder<MergeOperator>
    {
        HashSet<ColorProduction> colorProductions = new HashSet<ColorProduction>();

        public MergeOperatorBuilder WithColorProductions(params ColorProduction[] colorProductions)
        {
            this.colorProductions = new HashSet<ColorProduction>(colorProductions);
            return this;
        }

        public static MergeOperatorBuilder New() => new MergeOperatorBuilder();
        
        public override MergeOperator Build() => new MergeOperator(colorProductions);
    }
}