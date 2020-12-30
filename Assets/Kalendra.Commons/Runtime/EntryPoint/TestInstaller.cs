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
            Container.Bind<ISpawnInputReceiver>().To<DummySpawnUseCaseInputPort>().AsSingle();
        }

        void InstallOutputBoundaries()
        {
            Container.Bind<ISpawnOutputReceiver>().To<DummySpawnUseCaseOutputPort>().AsSingle();
        }
    }
}