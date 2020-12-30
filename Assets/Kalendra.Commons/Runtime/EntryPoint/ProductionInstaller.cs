using Kalendra.BoardCore.Domain.Services;
using Kalendra.BoardCore.Infraestructure.Services;
using Kalendra.Commons.Runtime.Application.Merge;
using Kalendra.Commons.Runtime.Domain.BoardSystem;
using Kalendra.Commons.Runtime.Domain.BoardSystem.BoardOperations;
using Kalendra.Commons.Runtime.Domain.BoardSystem.UseCases;
using Kalendra.Commons.Runtime.Domain.Gateways;
using Kalendra.Commons.Runtime.Domain.Merge.DataModel;
using Kalendra.Commons.Runtime.Domain.Patterns;
using Kalendra.Commons.Runtime.Infraestructure.Gateways.Adapters;
using Kalendra.Commons.Runtime.Infraestructure.Merge.ScriptObjs;
using Zenject;


namespace Kalendra.Commons.Runtime.EntryPoint
{
    public class ProductionInstaller : MonoInstaller
    {
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            InstallEntities();
            InstallGateways();
            InstallServices();
            InstallOperations();
            InstallInputBoundaries();
        }

        void InstallEntities()
        {
            Container.Bind<IBoard>().FromInstance(new Board(5, 5)).AsSingle();
        }

        void InstallGateways()
        {
            // Container.Bind<IReadOnlyRepository<ColorDataModel>>().To<ByResourcesNameNotAsyncRepository<ColorScriptObj>>();
        }

        void InstallServices()
        {
            Container.Bind<IRandomService>().FromInstance(new SystemRandomService()).AsSingle();
        }

        void InstallOperations()
        {
            Container.Bind<ISpawnOperatorPolicy>().To<ColoredPieceSpawnOperator>();
            Container.Bind<Domain.Patterns.IFactory<SpawnOperation>>()
                .FromInstance(new GenericFactory<SpawnOperation>())
                .AsSingle();
        }

        void InstallInputBoundaries()
        {
            Container.Bind<ISpawnInputReceiver>().To<SpawnInteractor>();
        }
    }
}