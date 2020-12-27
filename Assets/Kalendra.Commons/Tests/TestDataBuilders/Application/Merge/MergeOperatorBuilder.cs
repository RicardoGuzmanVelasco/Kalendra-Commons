using System.Collections.Generic;
using Kalendra.Commons.Runtime.Application.Merge;
using Kalendra.Commons.Runtime.Domain.Merge;
using Kalendra.Commons.Tests.TestDataBuilders.Builders;

namespace Kalendra.Commons.Tests.TestDataBuilders.Domain.Merge
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