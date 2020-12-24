using Kalendra.Commons.Runtime.Domain.BoardSystem;
using Kalendra.Commons.Runtime.Domain.Merge;

namespace Kalendra.Commons.Runtime.Application.BoardSystem
{
    public class ColoredPieceTileContent : ITileContent
    {
        public ColoredPiece ContainedPiece { get; set; } = new NullColoredPiece();
    }
}