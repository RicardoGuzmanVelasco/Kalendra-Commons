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

        public void Request()
        {
            output?.Response();
        }
    }

    internal class DummySpawnUseCaseOutputPort : ISpawnOutputReceiver
    {
        public void Response()
        {
            Debug.Log("Received");
        }
    }
}