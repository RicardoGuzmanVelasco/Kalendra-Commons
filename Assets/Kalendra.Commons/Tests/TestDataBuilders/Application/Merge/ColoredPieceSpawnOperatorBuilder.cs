using Kalendra.BoardCore.Infraestructure.Services;
using Kalendra.Commons.Runtime.Application.Merge;
using Kalendra.Commons.Runtime.Architecture.Gateways;
using Kalendra.Commons.Runtime.Architecture.Services;
using Kalendra.Commons.Runtime.Domain.Merge.DataModel;
using Kalendra.Commons.Tests.TestDataBuilders.Builders;
using Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts;

namespace Kalendra.Commons.Tests.TestDataBuilders.Domain.Merge
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