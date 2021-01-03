using System;
using FluentAssertions;
using Kalendra.BoardSystem.Runtime.Domain.Entities.BoardOperations;
using Kalendra.BoardSystem.Tests.TestDataBuilders.StaticShortcuts;
using NUnit.Framework;

namespace Kalendra.BoardSystem.Tests.Editor
{
    public class MergeOperationTests
    {
        [Test, Category("TODO")]
        public void New_WhenOriginAndTargetTilesAreTheSame_ThrowsException()
        {
            // var someOperator = Build.MergeOperator().Build();
            // var sameTile = Build.BoardTile().Build();
            // MergeOperation sut;
            //     
            // Action act = () => sut = new MergeOperation(sameTile, sameTile, someOperator);
            //
            // act.Should().Throw<InvalidOperationException>();
        }

        [Test, Category("TODO")]
        public void Execute_DoesNothing_IfMergeIsNotAvailable()
        {
            
        }
    }
}