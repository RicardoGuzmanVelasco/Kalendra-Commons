using Kalendra.Chess.Runtime.Domain;

namespace Kalendra.Chess.Tests.TestDataBuilders.Domain
{
    internal class KnightChessPieceBuilder : ChessPieceBuilder
    {
        #region ObjectMother/FactoryMethods
        public static KnightChessPieceBuilder New() => new KnightChessPieceBuilder();
        #endregion

        #region Builder implementation
        public override IChessPiece Build() => new KnightChessPiece(set);
        #endregion
    }
}