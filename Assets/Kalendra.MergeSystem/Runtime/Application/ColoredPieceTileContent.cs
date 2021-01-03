using Kalendra.BoardSystem.Runtime.Domain.Entities;
using Kalendra.MergeSystem.Runtime.Domain.Entities;

namespace Kalendra.MergeSystem.Runtime.Application
{
    public class ColoredPieceTileContent : ITileContent
    {
        public ColoredPiece ContainedPiece { get; }

        public ColoredPieceTileContent(ColoredPiece containedPiece)
        {
            ContainedPiece = containedPiece;
        }

        public override string ToString()
        {
            return $"{nameof(ContainedPiece)}: {ContainedPiece}";
        }
    }
}