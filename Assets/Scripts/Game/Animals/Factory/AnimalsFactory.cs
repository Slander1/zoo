using System;
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
        
        private AnimalsPositioner _positioner = new();
        
        private GetRandomPointOnField _getRandomPointOnField;

        [Inject]
        public void Construct(IRandomPointProvider randomPointProvider)
        {
            _getRandomPointOnField = randomPointProvider.GetRandomPointOnField;
        }

        #region === Unity Events ===

        private void Start()
        {
            CreateRandomAnimal();
        }

        #endregion === Unity Events ===

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