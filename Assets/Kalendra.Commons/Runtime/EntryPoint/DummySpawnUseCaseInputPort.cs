using System.Threading.Tasks;
using Kalendra.Commons.Runtime.Domain.BoardSystem.UseCases;
using UnityEngine;

namespace Kalendra.Commons.Runtime.EntryPoint
{
    internal class DummySpawnUseCaseInputPort : ISpawnInputReceiver
    {
        readonly ISpawnOutputReceiver output;

        public DummySpawnUseCaseInputPort(ISpawnOutputReceiver output)
        {
            this.output = output;
        }

        public async Task Request()
        {
            await output?.Response();
        }
    }

    internal class DummySpawnUseCaseOutputPort : ISpawnOutputReceiver
    {
        public Task Response()
        {
            Debug.Log("Received");
            return Task.CompletedTask;
        }
    }
}