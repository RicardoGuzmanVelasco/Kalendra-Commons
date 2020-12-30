using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kalendra.Commons.Runtime.Domain.Gateways;
using Kalendra.Commons.Runtime.Domain.Merge.DataModel;
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
    
    public class ByResourcesNameNotAsyncRepository<TDefinition, TModel> : IReadOnlyRepository<TModel> where TDefinition : Object where TModel : class
    {
        public async Task<IEnumerable<TModel>> LoadAll() 
        {
            var loadedCollection = Resources.LoadAll<TDefinition>("");
            return await Task.FromResult(loadedCollection.Cast<TModel>());
        }

        public async Task<TModel> Load(string hashID)
        {
            var loaded = Resources.Load<TDefinition>(hashID);
            return await Task.FromResult(loaded as TModel);
        }
    }
}