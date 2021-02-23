
using Kalendra.BoardSystem.Runtime.Domain.AdjacencyPolicy;

namespace Kalendra.Chess.Runtime.Domain
{
    internal class PawnMovement : ChessPieceMovementTemplate
    {
        protected override IAdjacencyPolicy GetAdjacencyPolicyTemplateMethod()
        {
            return null; //TODO
        }
    }
}