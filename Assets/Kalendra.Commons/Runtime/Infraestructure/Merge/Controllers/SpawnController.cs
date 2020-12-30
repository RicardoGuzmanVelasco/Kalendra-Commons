using System;
using Kalendra.Commons.Runtime.Domain.BoardSystem.UseCases;
using UnityEngine;
using Zenject;

namespace Kalendra.Commons.Runtime.Infraestructure.Merge.Controllers
{
    public class SpawnController : MonoBehaviour
    {
        [Inject] ISpawnInputReceiver spawnReceiver;

        void Update()
        {
            if(Input.anyKeyDown)
                spawnReceiver.Request();
        }
    }
}