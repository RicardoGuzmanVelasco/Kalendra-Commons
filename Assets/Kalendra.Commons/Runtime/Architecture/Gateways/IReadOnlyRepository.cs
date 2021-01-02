using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Kalendra.Commons.Runtime.Architecture.Gateways
{
    public interface IReadOnlyRepository<T>
    {
        Task<IEnumerable<T>> LoadAll();
        Task<T> Load([NotNull] string hashID);
    }
}