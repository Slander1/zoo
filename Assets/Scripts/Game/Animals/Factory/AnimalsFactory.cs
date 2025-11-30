using System;
using System.Threading;
using CoreLogic.Utility;
using Cysharp.Threading.Tasks;
using Game.Animals.Events;
using Game.Providers;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace Game.Animals.Factory
{
    public sealed class AnimalsFactory : MonoBehaviour, IAnimalsCreator
    {
        public event Action<AnimalBase> AnimalsCreated;
        
        [SerializeField] private AnimalBase[] animals;
        [SerializeField] private Transform animalParent;
        [SerializeField] private float spawnIntervalSeconds = 3f;

        private GetRandomPointOnField _getRandomPointOnField;

        private CancellationTokenSource _cts;

        [Inject]
        public void Construct(IRandomPointProvider randomPointProvider)
        {
            _getRandomPointOnField = randomPointProvider.GetRandomPointOnField;
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
            var randomAnimalIndex = Random.Range(0, animals.Length);
            var animalPrefab = animals[randomAnimalIndex];

            var pos = _getRandomPointOnField.Invoke();
            pos += new Vector3(0f, animalPrefab.GetObjectHeight(), 0f);
            
            var createdAnimal = Instantiate(animalPrefab, pos, Quaternion.identity, animalParent);
            
            createdAnimal.transform.position += new Vector3(0f, createdAnimal.GetObjectHeight() / 2f, 0f);
            AnimalsCreated?.Invoke(createdAnimal);
        }
    }
}