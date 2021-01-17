using Kalendra.Chess.Runtime.Domain;
using Kalendra.Chess.Tests.TestDataBuilders.Domain;

namespace Kalendra.Chess.Tests.TestDataBuilders.StaticShortcuts
{
    internal static partial class Build
    {
        public static ChessPieceBuilder<KnightChessPiece> KnightPiece() => ChessPieceBuilder<KnightChessPiece>.New<KnightChessPiece>();
        public static ChessPieceBuilder<KingChessPiece> KingPiece() => ChessPieceBuilder<KingChessPiece>.New<KingChessPiece>();
    }
}