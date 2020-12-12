using System.Collections.Generic;
using System.Linq;
using Kalendra.Commons.Runtime.Infraestructure.CharacterTaxonomySystem.ScriptableObjects;
using Kalendra.Commons.Tests.TestDataBuilders.Builders;
using UnityEngine;

namespace Kalendra.Commons.Tests.TestDataBuilders.Infraestructure.CharacterTaxonomySystem
{
    public class CharacterClassDefinitionBuilder : Builder<CharacterClassDefinition>
    {
        string id = "";
        List<CharacterClassDefinition> derivedFrom = new List<CharacterClassDefinition>();

        public CharacterClassDefinitionBuilder WithID(string newID)
        {
            id = newID;
            return this;
        }

        public CharacterClassDefinitionBuilder WithDerivedFrom(params CharacterClassDefinition[] newDerivedFrom)
        {
            derivedFrom = newDerivedFrom.ToList();
            return this;
        }
        
        public static CharacterClassDefinitionBuilder New() => new CharacterClassDefinitionBuilder();
        
        public override CharacterClassDefinition Build()
        {
            var instance = ScriptableObject.CreateInstance<CharacterClassDefinition>();
            
            var instanceID = instance.GetType().GetField("id",
                System.Reflection.BindingFlags.NonPublic | 
                System.Reflection.BindingFlags.Instance);
            instanceID.SetValue(instance, id);
            
            var instanceDerivedFrom = instance.GetType().GetField("derivedFrom",
                System.Reflection.BindingFlags.NonPublic | 
                System.Reflection.BindingFlags.Instance);
            instanceDerivedFrom.SetValue(instance, derivedFrom);

            return instance;
        }
    }
}