using System.Threading.Tasks;
using Kalendra.BoardSystem.Runtime.Domain.Entities;

namespace Kalendra.BoardSystem.Runtime.Domain.Policy
{
    public interface ISpawnOperatorPolicy
    {
        ITile SelectTileWhereSpawn(IBoard board);
        Task<ITileContent> SpawnContent();
    }
}