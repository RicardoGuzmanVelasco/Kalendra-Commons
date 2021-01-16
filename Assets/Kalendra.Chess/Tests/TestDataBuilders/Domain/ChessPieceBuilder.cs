using Kalendra.Chess.Runtime.Domain;
using Kalendra.Commons.Tests.TestDataBuilders.Builders;

namespace Kalendra.Chess.Tests.TestDataBuilders.Domain
{
    internal abstract class ChessPieceBuilder : Builder<IChessPiece>
    {
        protected ChessSet set = ChessSet.White;

        #region Fluent API
        public ChessPieceBuilder WithSet(ChessSet set)
        {
            this.set = set;
            return this;
        }
        #endregion
        
        #region Builder implementation
        public abstract override IChessPiece Build();
        #endregion
    }
}