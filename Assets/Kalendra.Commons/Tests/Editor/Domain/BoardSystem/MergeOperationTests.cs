using System;
using FluentAssertions;
using Kalendra.Commons.Runtime.Domain.BoardSystem.BoardOperations;
using Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts;
using NUnit.Framework;

namespace Kalendra.Commons.Tests.Editor.Domain.BoardSystem
{
    public class MergeOperationTests
    {
        [Test]
        public void New_WhenOriginAndTargetTilesAreTheSame_ThrowsException()
        {
            var someOperator = Build.MergeOperator().Build();
            var sameTile = Build.BoardTile().Build();
            MergeOperation sut;
                
            Action act = () => sut = new MergeOperation(sameTile, sameTile, someOperator);

            act.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Execute_DoesNothing_IfMergeIsNotAvailable()
        {
            throw new NotImplementedException("TODO! To continue with after spawn operation!");
        }
    }
}