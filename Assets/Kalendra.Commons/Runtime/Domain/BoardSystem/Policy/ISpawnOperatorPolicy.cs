using System.Threading.Tasks;
using Kalendra.Commons.Runtime.Domain.BoardSystem;

namespace Kalendra.Commons.Runtime.Application.Merge
{
    public interface ISpawnOperatorPolicy
    {
        ITile SelectTileWhereSpawn(IBoard board);
        Task<ITileContent> SpawnContent();
    }
}