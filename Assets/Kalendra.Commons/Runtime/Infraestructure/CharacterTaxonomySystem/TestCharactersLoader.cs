using System;
using System.Linq;
using System.Threading.Tasks;
using Kalendra.Commons.Runtime.Domain.Gateways;
using Kalendra.Commons.Utils.StaticExtensions.Adapters;
using UnityEngine;

namespace Kalendra.Commons.Runtime.Infraestructure.CharacterTaxonomySystem
{
    public class TestCharactersLoader : MonoBehaviour
    {
        readonly IReadOnlyRepository<CharacterScriptObj> loader = new ByResourcesNameNotAsyncRepository<CharacterScriptObj>();

        async void Start()
        {
            var result1 = await loader.Load("Character1");
            LogLoaded(result1);
            
            var result2 = await loader.Load("Character2");
            LogLoaded(result2);
            
            var resultAll = await loader.LoadAll();
            foreach(var result in resultAll)
                LogLoaded(result);
        }

        static void LogLoaded(CharacterScriptObj loaded) => Debug.Log(Time.timeSinceLevelLoad + " | " + loaded.TestLogText);
    }
}