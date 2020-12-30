using System.Threading.Tasks;
using Kalendra.Commons.Runtime.Domain.BoardSystem.BoardOperations;
using Kalendra.Commons.Runtime.Domain.Boundaries;
using Kalendra.Commons.Runtime.Domain.Patterns;

namespace Kalendra.Commons.Runtime.Domain.BoardSystem.UseCases
{
    public class SpawnInteractor : IBoundaryInputPort
    {
        readonly IBoard entityBoard;
        readonly IFactory<SpawnOperation> spawnFactory;
        readonly IBoundaryOutputPort outputBoundary;
        
        public SpawnInteractor(IBoard entityBoard, IFactory<SpawnOperation> spawnFactory, IBoundaryOutputPort outputBoundary)
        {
            this.entityBoard = entityBoard;
            this.spawnFactory = spawnFactory;
            this.outputBoundary = outputBoundary;
        }

        public void Request()
        {
            var spawnOperation = spawnFactory.Create();

            if(spawnOperation.IsAvailable(entityBoard))
                LaunchSpawnUseCase(spawnOperation);
            else
                ResponseNotAvailableUseCase();
        }

        void LaunchSpawnUseCase(SpawnOperation spawnOperation)
        {
            Task.Run(() => WaitForSpawnUseCase(spawnOperation));
        }
        
        async Task WaitForSpawnUseCase(SpawnOperation spawnOperation)
        {
            //TODO: operations command center, to let Undo after.
            await spawnOperation.Execute(entityBoard);
            outputBoundary.Response();
        }


        void ResponseNotAvailableUseCase()
        {
            throw new System.NotImplementedException();
        }
    }
}