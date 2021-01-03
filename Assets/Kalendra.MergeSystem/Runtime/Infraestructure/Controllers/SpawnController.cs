using System.Threading.Tasks;
using Kalendra.BoardSystem.Runtime.Domain.UseCases;
using UnityEngine;
using Zenject;

namespace Kalendra.Commons.Runtime.Infraestructure.Merge.Controllers
{
    public class SpawnController : MonoBehaviour
    {
        [Inject] ISpawnUseCaseInput spawnUseCase;

        async void Update()
        {
            if(Input.anyKeyDown)
            {
                LogPressedKeys();
                await RequestSpawnUseCase();
            }
        }

        void LogPressedKeys()
        {
            var pressedKeysMsg = string.Empty;
            
            foreach(KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
                if(Input.GetKeyDown(vKey))
                    pressedKeysMsg += vKey + " | ";
            
            Debug.Log(pressedKeysMsg);
        }

        async Task RequestSpawnUseCase()
        {
            await spawnUseCase.Request();
        }
    }
}