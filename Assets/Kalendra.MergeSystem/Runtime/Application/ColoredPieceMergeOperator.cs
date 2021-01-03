using System.Collections.Generic;
using System.Linq;
using Kalendra.MergeSystem.Runtime.Domain.Entities;

namespace Kalendra.MergeSystem.Runtime.Application
{
    /// <summary>
    /// Policy:
    /// no same tier or no same ID -> no merge
    /// Same tier, same color -> next tier, same color
    /// Same tier, different color -> same tier, produced color if any; no merge otherwise
    /// </summary>
    public class ColoredPieceMergeOperator
    {
        readonly HashSet<ColorProduction> colorProductions;

        public ColoredPieceMergeOperator(HashSet<ColorProduction> colorProductions)
        {
            this.colorProductions = colorProductions;
        }
        
        public ColoredPiece Merge(params ColoredPiece[] coloredPieces)
        {
            if(!AllPiecesHaveSameTier(coloredPieces) || !AllPiecesHaveSamePieceID(coloredPieces))
                return null;
            
            return AllPiecesAreTheSame(coloredPieces)
                ? NextTierPieceFrom(coloredPieces[0])
                : ProducedColorPieceFrom(coloredPieces);
        }

        #region Pieces comparison
        static bool AllPiecesHaveSameTier(IEnumerable<ColoredPiece> coloredPieces) => coloredPieces.GroupBy(piece => piece.Tier).Count() == 1;
        static bool AllPiecesHaveSamePieceID(IEnumerable<ColoredPiece> coloredPieces) => coloredPieces.GroupBy(piece => piece.PieceID).Count() == 1;
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