using System.Threading.Tasks;

namespace Kalendra.Commons.Runtime.Domain.Gateways
{
    public interface IDeletionRepository
    {
        Task<bool> Delete(string hashID);
    }
}