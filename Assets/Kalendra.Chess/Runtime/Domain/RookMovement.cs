using Kalendra.BoardSystem.Runtime.Domain.AdjacencyPolicy;

namespace Kalendra.Chess.Runtime.Domain
{
    internal class RookMovement : ChessPieceMovementTemplate
    {
        protected override IAdjacencyPolicy GetAdjacencyPolicyTemplateMethod()
        {
            return null; //TODO
        }
    }
}