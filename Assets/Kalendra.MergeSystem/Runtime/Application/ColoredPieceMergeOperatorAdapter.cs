using System.Linq;
using Kalendra.BoardSystem.Runtime.Domain.Entities;
using Kalendra.BoardSystem.Runtime.Domain.Policy;

namespace Kalendra.MergeSystem.Runtime.Application
{
    public class ColoredPieceMergeOperatorAdapter : IMergeOperatorPolicy
    {
        readonly ColoredPieceMergeOperator adaptee;

        public ColoredPieceMergeOperatorAdapter(ColoredPieceMergeOperator adaptee)
        {
            this.adaptee = adaptee;
        }

        public bool IsAvailable(IBoard board)
        {
            throw new System.NotImplementedException();
        }

        public ITileContent Merge(params ITileContent[] contents)
        {
            var coloredPiecesTileContents = contents.Cast<ColoredPieceTileContent>();
            var coloredPieces = coloredPiecesTileContents.Select(content => content.ContainedPiece);

            var resultColoredPiece = adaptee.Merge(coloredPieces.ToArray());
            return new ColoredPieceTileContent(resultColoredPiece);
        }
    }
}