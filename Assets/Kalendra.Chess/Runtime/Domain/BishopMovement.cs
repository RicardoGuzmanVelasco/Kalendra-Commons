using Kalendra.BoardSystem.Runtime.Domain.AdjacencyPolicy;

namespace Kalendra.Chess.Runtime.Domain
{
    internal class BishopMovement : ChessPieceMovementTemplate
    {
        protected override IAdjacencyPolicy GetAdjacencyPolicyTemplateMethod()
        {
            return null; //TODO
        }
    }
}