using System;
using System.Linq;
using Game.Animals.Behaviour.Collisions.InteractionInterfaces;
using UnityEngine;

namespace Game.Animals.Behaviour.Collisions
{
    public sealed class CollisionDefiner
    {
        public void OnCollision(IAnimalCollisionBehaviour animalCollisionBehaviour, Collision collision )
        {
            if (collision.collider.CompareTag("Wall"))
            {
                if (animalCollisionBehaviour.TryGetController<IWallInteractable>(out var wallInteractable)) 
                    wallInteractable.OnWallCollision(collision.transform.position);
                
                return;
            }
            
            if (collision.collider.TryGetComponent<AnimalBase>(out var collisionAnimal))
            {
                foreach (var collisionAnimalRole in collisionAnimal.Roles)
                {
                    Debug.Log(collisionAnimalRole);
                    
                    //
                    // collisionAnimalRole
                    // if (animalCollisionBehaviour.TryGetController<IWallInteractable>(out var wallInteractable)) 
                    //     wallInteractable.OnWallCollision(collision.transform.position);
                }
            }

            // throw new NotImplementedException();
        }
    }
}

// using Game.Animals.Events;
// using Game.Animals.Pool;
// using Game.Providers;
// using UnityEngine;
// using VContainer;
//
// namespace Game.Animals.Behaviour.Collisions
// { 
//     public sealed class CollisionProvider : MonoBehaviour
//     {
//         
//         private IAnimalsCreator _animalsCreator;
//         private IGameFieldCenterProvider _gameFieldCenterProvider;
//         private IAnimalsHashSetProvider _animalsHashSetProvider;
//         
//         [Inject]
//         public void Construct(IAnimalsCreator animalsCreator, 
//             IAnimalsHashSetProvider hashSetProvider, 
//             IGameFieldCenterProvider  gameFieldCenterProvider)
//         {
//             _animalsCreator = animalsCreator;
//             _animalsHashSetProvider = hashSetProvider;
//             _gameFieldCenterProvider = gameFieldCenterProvider;
//         }
//
//         #region === Unity Events ===
//
//         private void OnEnable()
//         {
//             SubscribeOnEvents();
//         }
//
//         private void OnDisable()
//         {
//             UnsubscribeFromEvents();
//         }
//
//         #endregion === Unity Events ===
//         
//         private void SubscribeOnEvents()
//         {
//             _animalsCreator.AnimalsCreated += OnAnimalsCreated;
//         }
//
//         private void UnsubscribeFromEvents()
//         {
//             _animalsCreator.AnimalsCreated -= OnAnimalsCreated;
//             
//             foreach (var animalBase in _animalsHashSetProvider.AnimalsOnField) 
//                 animalBase.CollisionEntered -= AnimalOnCollisionEntered;
//         }
//         
//         private void OnAnimalsCreated(AnimalBase animal)
//         {
//             animal.CollisionEntered += AnimalOnCollisionEntered;
//         }
//
//         private void AnimalOnCollisionEntered(AnimalBase animal, Collision collision)
//         {
//             if (collision.collider.CompareTag("Wall"))
//             {
//                 RedirectFromWall(animal, collision);
//                 return;
//             }
//             
//         }
//
//         private void RedirectFromWall(AnimalBase animal, Collision collision)
//         {
//             var animalPos = animal.transform.position;
//             var wallPos   = collision.transform.position;
//
//             var directionToWall = (wallPos - animalPos).normalized;
//             var viewDir = animal.transform.forward;
//             var angleToWall = Vector3.Angle(viewDir, directionToWall);
//
//             if (angleToWall > wallRedirectAngleThreshold)
//                 return;
//
//             var outward3 = (wallPos - _gameFieldCenterProvider.GetFieldCenter()).normalized;
//             var normal2D = new Vector2(outward3.x, outward3.z);
//
//             animal.OnBlockedByObstacle(normal2D);
//         }
//         
//         public void Dispose()
//         {
//             UnsubscribeFromEvents();
//         }
//     }
// }