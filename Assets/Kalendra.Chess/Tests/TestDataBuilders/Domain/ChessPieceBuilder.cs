using System;
using Kalendra.Chess.Runtime.Domain;
using Kalendra.Commons.Tests.TestDataBuilders.Builders;

namespace Kalendra.Chess.Tests.TestDataBuilders.Domain
{
    internal class ChessPieceBuilder<T> : Builder<T> where T : ChessPiece
    {
        protected ChessSet set = ChessSet.White;

        #region Fluent API
        public ChessPieceBuilder<T> WithSet(ChessSet set)
        {
            this.set = set;
            return this;
        }
        #endregion
        
        #region ObjectMother/FactoryMethods
        public static ChessPieceBuilder<T> New<T>() where T : ChessPiece => new ChessPieceBuilder<T>();
        #endregion
        
        #region Builder implementation
        public override T Build() => (T) Activator.CreateInstance(typeof(T), set);
        #endregion
    }
}