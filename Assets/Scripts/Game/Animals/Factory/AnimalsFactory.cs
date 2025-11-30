using System;
using System.Threading;
using CoreLogic.Utility;
using Cysharp.Threading.Tasks;
using Game.Animals.EventHub;
using Game.Providers;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace Game.Animals.Factory
{
    public sealed class AnimalsFactory : MonoBehaviour
    {
        [SerializeField] private AnimalBase[] animals;
        [SerializeField] private Transform animalParent;
        [SerializeField] private float spawnIntervalSeconds = 3f;

        private GetRandomPointOnField _getRandomPointOnField;
        private IObjectPoolProvider _objectPoolProvider;

        private CancellationTokenSource _cts;
        private IAnimalsEventHub _eventHub;
        
        [Inject]
        public void Construct(IRandomPointProvider randomPointProvider, IObjectPoolProvider objectPoolProvider, IAnimalsEventHub eventHub)
        {
            _getRandomPointOnField = randomPointProvider.GetRandomPointOnField;
            _objectPoolProvider = objectPoolProvider;
            _eventHub = eventHub;
        }

        private void Start()
        {
            _cts = new CancellationTokenSource();
            SpawnLoopAsync(_cts.Token).Forget();
        }

        private void OnDestroy()
        {
            TokenHelper.Dispose(_cts);
        }
        
        private async UniTaskVoid SpawnLoopAsync(CancellationToken token)
        {
            await UniTask.NextFrame();
            
            while (!token.IsCancellationRequested)
            {
                CreateRandomAnimal();

                try
                {
                    await UniTask.Delay(
                        TimeSpan.FromSeconds(spawnIntervalSeconds),
                        cancellationToken: token
                    );
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
        }

        private void CreateRandomAnimal()
        {
            AnimalBase createdAnimal;
            
            var pos = _getRandomPointOnField.Invoke();
            
            if (_objectPoolProvider.TryGetElemFromObjectPool(out createdAnimal))
            {
                // pos += new Vector3(0f, createdAnimal.GetObjectHeight(), 0f);
                createdAnimal.transform.SetParent(animalParent);
            }
            else
            {
                var randomAnimalIndex = Random.Range(0, animals.Length);
                var animalPrefab = animals[randomAnimalIndex];
                // pos += new Vector3(0f, animalPrefab.GetObjectHeight(), 0f);
                createdAnimal = Instantiate(animalPrefab, pos, Quaternion.identity, animalParent);
            }
            
            createdAnimal.transform.position += new Vector3(0f, createdAnimal.GetObjectHeight() / 2f, 0f);
            _eventHub.RaiseAnimalSpawned(createdAnimal);
        }
    }
}