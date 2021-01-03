using Kalendra.MergeSystem.Runtime.Application;
using Kalendra.MergeSystem.Tests.TestDataBuilders.Application;
using Kalendra.MergeSystem.Tests.TestDataBuilders.Domain;

namespace Kalendra.MergeSystem.Tests.TestDataBuilders.StaticShortcuts
{
    public static partial class Build
    {
        internal static ColorProductionBuilder ColorProduction() => ColorProductionBuilder.New();
        
        internal static MergeOperatorBuilder MergeOperator() => MergeOperatorBuilder.New();
        
        internal static ColoredPieceBuilder ColoredPiece() => ColoredPieceBuilder.New();
        internal static ColoredPieceBuilder ColoredPiece_Some() => ColoredPieceBuilder.New().WithTier(1).WithPieceID("pieceID").WithColorID("colorID");

        internal static ColoredPieceSpawnOperatorBuilder ColoredPieceSpawnOperator() => ColoredPieceSpawnOperatorBuilder.New();
        internal static ColoredPieceSpawnOperator ColoredPieceSpawnOperator_WithSystemRandom() => ColoredPieceSpawnOperatorBuilder.WithSystemRandomService();
    }
}