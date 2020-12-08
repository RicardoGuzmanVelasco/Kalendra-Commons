using System.Collections.Generic;
using System.Threading.Tasks;
using Kalendra.Commons.Runtime.Domain.Gateways;
using UnityEngine;

#pragma warning disable 1998

namespace Kalendra.Commons.Runtime.Infraestructure.Gateways.Adapters
{
    public class ByResourcesNameNotAsyncRepository<T> : IReadOnlyRepository<T> where T : Object
    {
        public async Task<IEnumerable<T>> LoadAll() 
        {
            var loadedCollection = Resources.LoadAll<T>("");
            return loadedCollection;
        }

        public async Task<T> Load(string hashID)
        {
            var loaded = Resources.Load<T>(hashID);
            return loaded;
        }
    }
}