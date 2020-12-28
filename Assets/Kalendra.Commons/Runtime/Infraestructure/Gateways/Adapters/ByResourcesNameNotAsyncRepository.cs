using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kalendra.Commons.Runtime.Domain.Gateways;
using UnityEngine;

namespace Kalendra.Commons.Runtime.Infraestructure.Gateways.Adapters
{
    public class ByResourcesNameNotAsyncRepository<T> : IReadOnlyRepository<T> where T : Object
    {
        public async Task<IEnumerable<T>> LoadAll() 
        {
            var loadedCollection = Resources.LoadAll<T>("");
            return await Task.FromResult(loadedCollection);
        }

        public async Task<T> Load(string hashID)
        {
            var loaded = Resources.Load<T>(hashID);
            return await Task.FromResult(loaded);
        }
    }
}