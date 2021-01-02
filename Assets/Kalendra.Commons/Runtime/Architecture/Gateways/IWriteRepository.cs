using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Kalendra.Commons.Runtime.Architecture.Gateways
{
    public interface IWriteRepository<in T>
    {
        Task Save([NotNull] string hashID, [NotNull] T targetToSave);
    }
}