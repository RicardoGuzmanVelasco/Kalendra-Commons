using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Kalendra.Commons.Runtime.Domain.Gateways
{
    public interface IWriteRepository<in T>
    {
        Task Save([NotNull] string hashID, [NotNull] T targetToSave);
    }
}