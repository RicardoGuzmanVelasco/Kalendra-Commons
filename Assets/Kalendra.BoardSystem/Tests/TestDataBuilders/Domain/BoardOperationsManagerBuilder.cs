using System.Collections.Generic;
using Kalendra.BoardSystem.Runtime.Domain.Entities.BoardOperations;
using Kalendra.Commons.Tests.TestDataBuilders.Builders;

namespace Kalendra.BoardSystem.Tests.TestDataBuilders.Domain
{
    internal class BoardOperationsManagerBuilder : Builder<BoardOperationsManager>
    {
        List<IBoardOperation> begginingOperations;

        #region Fluent API
        public BoardOperationsManagerBuilder WithOperations(params IBoardOperation[] begginingOperations)
        {
            this.begginingOperations = new List<IBoardOperation>(begginingOperations);
            return this;
        }
        #endregion

        #region ObjectMother/FactoryMethods
        public static BoardOperationsManagerBuilder New() => new BoardOperationsManagerBuilder();
        #endregion

        #region Builder implementation
        public override BoardOperationsManager Build() => new BoardOperationsManager(begginingOperations);
        #endregion
    }
}