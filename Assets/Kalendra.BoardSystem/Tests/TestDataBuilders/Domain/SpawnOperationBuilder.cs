using Kalendra.Commons.Runtime.Application.Merge;
using Kalendra.Commons.Runtime.Domain.BoardSystem.BoardOperations;
using Kalendra.Commons.Tests.TestDataBuilders.Builders;
using NSubstitute;

namespace Kalendra.Commons.Tests.TestDataBuilders.Domain.BoardSystem
{
    internal class SpawnOperationBuilder : Builder<SpawnOperation>
    {
        ISpawnOperatorPolicy spawnPolicy = Substitute.For<ISpawnOperatorPolicy>();

        SpawnOperationBuilder() { }

        #region Fluent API
        public SpawnOperationBuilder WithSpawnPolicy(ISpawnOperatorPolicy spawnPolicy)
        {
            this.spawnPolicy = spawnPolicy;
            return this;
        }
        #endregion
        
        #region ObjectMother/FactoryMethods
        public static SpawnOperationBuilder New() => new SpawnOperationBuilder();
        #endregion

        #region Builder implementation
        public override SpawnOperation Build() => new SpawnOperation(spawnPolicy);
        #endregion
    }
}