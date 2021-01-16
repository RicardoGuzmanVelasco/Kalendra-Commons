using Kalendra.Chess.Runtime.Domain;
using Kalendra.Commons.Tests.TestDataBuilders.Builders;
using NSubstitute;

namespace Kalendra.Chess.Tests.TestDataBuilders.Domain
{
    internal class ChessPieceMockBuilder : MockBuilder<IChessPiece>
    {
        #region Fluent API
        public ChessPieceMockBuilder WithSet(ChessSet set)
        {
            mock.Set.Returns(set);
            return this;
        }
        #endregion

        #region ObjectMother/FactoryMethods
        public static ChessPieceMockBuilder New() => new ChessPieceMockBuilder();
        #endregion
    }
}