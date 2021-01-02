using System.Threading.Tasks;
using Kalendra.Commons.Runtime.Domain.BoardSystem.UseCases;
using UnityEngine;

namespace Kalendra.Commons.Runtime.EntryPoint
{
    internal class DummySpawnUseCaseUseCaseInputPort : ISpawnUseCaseInput
    {
        readonly ISpawnUseCaseOutput useCaseOutput;

        public DummySpawnUseCaseUseCaseInputPort(ISpawnUseCaseOutput useCaseOutput)
        {
            this.useCaseOutput = useCaseOutput;
        }

        public async Task Request()
        {
            await useCaseOutput?.Response();
        }
    }

    internal class DummySpawnUseCaseUseCaseOutputPort : ISpawnUseCaseOutput
    {
        public Task Response()
        {
            Debug.Log("Received");
            return Task.CompletedTask;
        }
    }
}