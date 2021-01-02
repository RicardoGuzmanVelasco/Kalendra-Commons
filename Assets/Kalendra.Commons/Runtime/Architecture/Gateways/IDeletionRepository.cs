using System.Threading.Tasks;

namespace Kalendra.Commons.Runtime.Architecture.Gateways
{
    public interface IDeletionRepository
    {
        Task<bool> Delete(string hashID);
    }
}