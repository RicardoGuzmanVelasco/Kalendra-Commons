using Kalendra.MergeSystem.Runtime.Application;
using Kalendra.MergeSystem.Runtime.Domain.Entities.DataModel;
using Kalendra.MergeSystem.Tests.TestDataBuilders.StaticShortcuts;

namespace Kalendra.MergeSystem.Tests.TestDataBuilders.Application
{
    internal class ColoredPieceSpawnOperatorBuilder : Builder<ColoredPieceSpawnOperator>
    {
        IRandomService randomService;
        IReadOnlyRepository<PieceDataModel> pieceGateway = Fake.ReadOnlyRepository<PieceDataModel>();
        IReadOnlyRepository<ColorDataModel> colorGateway = Fake.ReadOnlyRepository<ColorDataModel>();

        #region Fluent API
        public ColoredPieceSpawnOperatorBuilder WithRandomService(IRandomService randomService)
        {
            this.randomService = randomService;
            return this;
        }
        #endregion

        #region ObjectMother/FactoryMethods
        public static ColoredPieceSpawnOperatorBuilder New() => new ColoredPieceSpawnOperatorBuilder();
        public static ColoredPieceSpawnOperator WithSystemRandomService() => new ColoredPieceSpawnOperatorBuilder().WithRandomService(new SystemRandomService());
        #endregion

        #region Builder implementation
        public override ColoredPieceSpawnOperator Build() => new ColoredPieceSpawnOperator(randomService, colorGateway, pieceGateway);
        #endregion
    }
}