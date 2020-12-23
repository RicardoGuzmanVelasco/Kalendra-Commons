using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Kalendra.Commons.Runtime.Domain.Merge
{
    public class MergeOperator
    {
        readonly HashSet<ColorProduction> colorProductions;

        public MergeOperator(HashSet<ColorProduction> colorProductions)
        {
            this.colorProductions = colorProductions;
        }

        [CanBeNull] public ColoredPiece Merge([NotNull] params ColoredPiece[] coloredPieces)
        {
            if(!AllPiecesHaveSameTier(coloredPieces) || !AllPiecesHaveSamePieceID(coloredPieces))
                return null;
            
            return AllPiecesAreTheSame(coloredPieces)
                ? NextTierPieceFrom(coloredPieces[0])
                : ProducedColorPieceFrom(coloredPieces);
        }

        #region Pieces comparison
        static bool AllPiecesHaveSameTier(ColoredPiece[] coloredPieces) => coloredPieces.GroupBy(piece => piece.Tier).Count() == 1;
        static bool AllPiecesHaveSamePieceID(ColoredPiece[] coloredPieces) => coloredPieces.GroupBy(piece => piece.PieceID).Count() == 1;
        //TODO: extension method utils for collections.
        static bool AllPiecesAreTheSame(ColoredPiece[] coloredPieces) => coloredPieces.All(piece => piece.Equals(coloredPieces.First()));
        #endregion
        
        #region Merging
        ColoredPiece NextTierPieceFrom(ColoredPiece samplePiece) => new ColoredPiece(samplePiece.Tier + 1, samplePiece.PieceID, samplePiece.ColorID);

        ColoredPiece ProducedColorPieceFrom(IReadOnlyList<ColoredPiece> originalPieces)
        {
            var colorIDs = originalPieces.Select(piece => piece.ColorID);
            var production = colorProductions.SingleOrDefault(colorProd => colorProd.CanProduce(colorIDs));

            if(production is null)
                return null;

            var samplePiece = originalPieces[0];
            return new ColoredPiece(samplePiece.Tier, samplePiece.PieceID, production.ResultColor);
        }
        #endregion
    }
}