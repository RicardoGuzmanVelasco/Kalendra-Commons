using Kalendra.BoardSystem.Runtime.Domain.AdjacencyPolicy;

namespace Kalendra.Chess.Runtime.Domain
{
    internal class KingMovement : ChessPieceMovementTemplate
    {
        protected override IAdjacencyPolicy GetAdjacencyPolicyTemplateMethod() => new SquareAdjacencyPolicy();
    }
}