using JetBrains.Annotations;

namespace Kalendra.Commons.Runtime.Domain.Merge
{
    public interface IMergeOperatorPolicy
    {
        //TODO: may receive Tiles? Add IsAvailable method? Use MergeRequestInstead?
        ColoredPiece Merge([NotNull] params ColoredPiece[] coloredPieces);
    }
}