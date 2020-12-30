using System;
using Kalendra.Commons.Runtime.Domain.BoardSystem.UseCases;
using UnityEngine;

namespace Kalendra.Commons.Runtime.Infraestructure.Merge.Controllers
{
    public class SpawnController : MonoBehaviour
    {
        ISpawnInputReceiver spawnReceiver;

        void Update()
        {
            if(Input.anyKeyDown)
                spawnReceiver.Request();
        }
    }
}