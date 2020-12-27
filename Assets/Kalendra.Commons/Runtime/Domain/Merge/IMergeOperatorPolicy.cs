using JetBrains.Annotations;

namespace Kalendra.Commons.Runtime.Domain.Merge
{
    public interface IMergeOperatorPolicy
    {
        [CanBeNull] ColoredPiece Merge([NotNull] params ColoredPiece[] coloredPieces);
    }
}