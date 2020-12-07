using System.Collections.Generic;
using System.Threading.Tasks;
using Kalendra.Commons.Runtime.Domain.Gateways;
using Kalendra.Commons.Utils.Persistence;
using Kalendra.Commons.Utils.Serialization;

namespace Kalendra.Commons.Runtime.Infraestructure.Gateways.Adapters
{
    public class SavingControllerThroughPlayerPrefsRepository<T> : IRepository<T> where T : class, IJsonizable, new()
    {
        public async Task<IEnumerable<T>> LoadAll()
        {
            var loadedElements = await SavingController.LoadBunch<T>();
            return loadedElements;
        }

        public Task<T> Load(string hashID)
        {
            throw new System.NotImplementedException();
        }

        public Task Save(string hashID, T targetToSave)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(string hashID)
        {
            throw new System.NotImplementedException();
        }
    }
}