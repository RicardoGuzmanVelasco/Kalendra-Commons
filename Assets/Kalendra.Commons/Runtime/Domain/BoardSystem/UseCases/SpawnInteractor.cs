using System.Threading.Tasks;
using Kalendra.Commons.Runtime.Domain.BoardSystem.BoardOperations;
using Kalendra.Commons.Runtime.Domain.Patterns;

namespace Kalendra.Commons.Runtime.Domain.BoardSystem.UseCases
{
    public class SpawnInteractor : ISpawnInputReceiver
    {
        readonly IBoard entityBoard;
        readonly IFactory<SpawnOperation> spawnFactory;
        readonly ISpawnOutputReceiver outputBoundary;
        readonly ISpawnNotAvailableOutputReceiver outputNotAvailableBoundary;
        
        public SpawnInteractor(IBoard entityBoard, IFactory<SpawnOperation> spawnFactory, ISpawnOutputReceiver outputBoundary, ISpawnNotAvailableOutputReceiver outputNotAvailableBoundary = null)
        {
            this.entityBoard = entityBoard;
            this.spawnFactory = spawnFactory;
            this.outputBoundary = outputBoundary;
            this.outputNotAvailableBoundary = outputNotAvailableBoundary;
        }

        public async Task Request()
        {
            var spawnOperation = spawnFactory.Create();

            if(spawnOperation.IsAvailable(entityBoard))
                await LaunchSpawnUseCase(spawnOperation);
            else
                ResponseNotAvailableUseCase();
        }

        async Task LaunchSpawnUseCase(SpawnOperation spawnOperation)
        {
            await WaitForSpawnUseCase(spawnOperation);
        }
        
        async Task WaitForSpawnUseCase(SpawnOperation spawnOperation)
        {
            //TODO: operations command center, to let Undo after.
            await spawnOperation.Execute(entityBoard);
            outputBoundary.Response();
        }
        
        void ResponseNotAvailableUseCase()
        {
            outputNotAvailableBoundary?.Response();
        }
    }
}