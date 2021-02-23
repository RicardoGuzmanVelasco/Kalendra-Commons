using System;
using Kalendra.Commons.Runtime.Architecture.Patterns;

namespace Kalendra.Chess.Runtime.Domain
{
    internal class ChessPieceFactory : IFactory<IChessPiece, ChessPieceDefinition>
    {
        public IChessPiece Create(ChessPieceDefinition definition)
        {
            switch(definition.Piece)
            {
                case ChessPiece.King:
                    return new KingChessPiece(definition.Set);
                case ChessPiece.Queen:
                    return new QueenChessPiece(definition.Set);
                case ChessPiece.Bishop:
                    return new BishopChessPiece(definition.Set);
                case ChessPiece.Knight:
                    return new KnightChessPiece(definition.Set);
                case ChessPiece.Rook:
                    return new RookChessPiece(definition.Set);
                case ChessPiece.Pawn:
                    return new PawnChessPiece(definition.Set);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}