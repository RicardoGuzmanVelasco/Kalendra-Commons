using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Kalendra.Commons.Runtime.Infraestructure.CharacterTaxonomySystem.ScriptableObjects;
using Kalendra.Commons.Tests.TestDataBuilders.StaticShortcuts;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Kalendra.Commons.Tests.Runtime.Infraestructure
{
    public class CharacterClassDefinitionTests
    {
        [Test]
        public void ToCharacterClass_ConvertsID()
        {
            const string expectedID = "ID";
            CharacterClassDefinition sut = Build.CharacterClassDefinition().WithID(expectedID);

            var resultCharacterClass = sut.ToDefined();

            resultCharacterClass.ID.Should().Be(expectedID);
        }

        [Test]
        public void ToCharacterClass_ConvertsDerivedFrom()
        {
            const string expectedParentID = "parentID";
            var parent = Build.CharacterClassDefinition().WithID(expectedParentID);
            CharacterClassDefinition sut = Build.CharacterClassDefinition().WithDerivedFrom(parent);

            var resultCharacterClass = sut.ToDefined();

            resultCharacterClass.AllFamilyID.Should().Contain(expectedParentID);
        }
    }
}