using Kalendra.Chess.Runtime.Domain;
using Kalendra.Chess.Tests.TestDataBuilders.Domain;

namespace Kalendra.Chess.Tests.TestDataBuilders.StaticShortcuts
{
    internal static partial class Fake
    {
        public static ChessPieceMockBuilder WhitePiece() => ChessPieceMockBuilder.New().WithSet(ChessSet.White);
        public static ChessPieceMockBuilder BlackPiece() => ChessPieceMockBuilder.New().WithSet(ChessSet.Black);
    }
}