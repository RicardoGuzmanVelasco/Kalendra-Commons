using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kalendra.BoardCore.Infraestructure.Services;
using Kalendra.Commons.Runtime.Application.Merge;
using Kalendra.Commons.Runtime.Architecture.Gateways;
using Kalendra.Commons.Runtime.Architecture.Services;
using Kalendra.Commons.Runtime.Domain.BoardSystem;
using Kalendra.Commons.Runtime.Domain.BoardSystem.BoardOperations;
using Kalendra.Commons.Runtime.Domain.BoardSystem.UseCases;
using Kalendra.Commons.Runtime.Domain.Merge.DataModel;
using Kalendra.Commons.Runtime.Infraestructure.Gateways.Adapters;
using Kalendra.Commons.Runtime.Infraestructure.Merge.ScriptObjs;
using UnityEngine;
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
            InstallOutputBoundaries();
        }

        void InstallEntities()
        {
            Container.Bind<IBoard>().FromInstance(new Board(5, 5)).AsSingle();
        }

        void InstallGateways()
        {
            Container.Bind<IReadOnlyRepository<ColorDataModel>>().To<TestColorsRepository>().AsSingle();
            Container.Bind<IReadOnlyRepository<PieceDataModel>>().To<TestPiecesRepository>().AsSingle();
        }

        void InstallServices()
        {
            //TODO: seed doesn't grant the same values in different executions. :(
            Container.Bind<IRandomService>().FromInstance(new UnityEngineRandomService(304578230)).AsSingle();
        }

        void InstallOperations()
        {
            Container.Bind<ISpawnOperatorPolicy>().To<ColoredPieceSpawnOperator>().AsTransient();
            Container.Bind<Architecture.Patterns.IFactory<SpawnOperation>>()
                .FromInstance(new TestSpawnOperationFactory())
                .AsSingle();
        }

        void InstallInputBoundaries()
        {
            Container.Bind<ISpawnUseCaseInput>().To<SpawnUseCaseInteractor>().AsCached();
        }
        
        void InstallOutputBoundaries()
        {
            Container.Bind<ISpawnNotAvailableUseCaseOutput>().To<DummySpawnUseCaseNotAvailableUseCaseOutputPort>().AsSingle();
            Container.Bind<ISpawnUseCaseOutput>().To<DummySpawnUseCaseUseCaseOutputPort>().AsSingle();
        }
    }

    internal class DummySpawnUseCaseNotAvailableUseCaseOutputPort : ISpawnNotAvailableUseCaseOutput
    {
        public Task Response()
        {
            Debug.Log("No empty tiles");
            return Task.CompletedTask;
        }
    }

    internal class TestSpawnOperationFactory : Architecture.Patterns.IFactory<SpawnOperation>
    {
        public SpawnOperation Create()
        {
            return new SpawnOperation(new ColoredPieceSpawnOperator(
                new SystemRandomService(),
                new TestColorsRepository(),
                new TestPiecesRepository()));
        }
    }
    
    public class TestPiecesRepository : IReadOnlyRepository<PieceDataModel>
    {
        public async Task<IEnumerable<PieceDataModel>> LoadAll() 
        {
            var loadedCollection = Resources.LoadAll<PieceScriptObj>("");
            return await Task.FromResult(loadedCollection.Select(obj => (PieceDataModel) obj));
        }

        public async Task<PieceDataModel> Load(string hashID)
        {
            throw new NotImplementedException();
        }
    }
    
    public class TestColorsRepository : IReadOnlyRepository<ColorDataModel>
    {
        public async Task<IEnumerable<ColorDataModel>> LoadAll() 
        {
            var loadedCollection = Resources.LoadAll<ColorScriptObj>("");
            return await Task.FromResult(loadedCollection.Select(obj => (ColorDataModel) obj));
        }

        public async Task<ColorDataModel> Load(string hashID)
        {
            throw new NotImplementedException();
        }
    }
}