using Kalendra.Chess.Tests.TestDataBuilders.Domain;

namespace Kalendra.Chess.Tests.TestDataBuilders.StaticShortcuts
{
    internal static partial class Build
    {
        public static ChessPieceBuilder KnightPiece() => KnightChessPieceBuilder.New();
    }
}