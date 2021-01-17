using Kalendra.BoardSystem.Runtime.Domain.AdjacencyPolicy;

namespace Kalendra.Chess.Runtime.Domain
{
    internal class KnightMovement : ChessPieceMovementTemplate
    {
        protected override IAdjacencyPolicy GetAdjacencyPolicyTemplateMethod() => new LShapedAdjacencyPolicy();
    }
}