using System.Collections.Generic;

namespace Kalendra.Commons.Runtime.Domain.Gateways
{
    public interface IReadOnlyRepository<T>
    {
        IEnumerable<T> LoadAll();
        T Load(string hashID);
    }
}