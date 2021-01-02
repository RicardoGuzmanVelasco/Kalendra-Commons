using Kalendra.Commons.Runtime.Domain.BoardSystem.UseCases;
using Zenject;

namespace Kalendra.Commons.Runtime.EntryPoint
{
    public class TestInstaller : MonoInstaller
    {
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            InstallInputBoundaries();
            InstallOutputBoundaries();
        }
        
        void InstallInputBoundaries()
        {
            Container.Bind<ISpawnUseCaseInput>().To<DummySpawnUseCaseUseCaseInputPort>().AsSingle();
        }

        void InstallOutputBoundaries()
        {
            Container.Bind<ISpawnUseCaseOutput>().To<DummySpawnUseCaseUseCaseOutputPort>().AsSingle();
        }
    }
}