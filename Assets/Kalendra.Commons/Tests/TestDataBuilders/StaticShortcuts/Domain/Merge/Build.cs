using Kalendra.Commons.Tests.TestDataBuilders.Domain.Merge;

namespace Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts
{
    internal static partial class Build
    {
        public static ColorProductionBuilder ColorProduction() => ColorProductionBuilder.New();
        
        public static MergeOperatorBuilder MergeOperator() => MergeOperatorBuilder.New();
        
        public static ColoredPieceBuilder ColoredPiece() => ColoredPieceBuilder.New();
        public static ColoredPieceBuilder ColoredPiece_Some() => ColoredPieceBuilder.New().WithTier(1).WithPieceID("pieceID").WithColorID("colorID");
    }
}