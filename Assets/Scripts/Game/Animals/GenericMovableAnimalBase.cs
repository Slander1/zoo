using Game.Animals.Behaviour.Collisions;
using Game.Animals.Behaviour.Collisions.Data;
using Game.Animals.Behaviour.Movers;
using Game.Animals.Behaviour.Movers.Data;
using UnityEngine;

namespace Game.Animals
{
    public class GenericMovableAnimalBase<TMover, TMoverData, TCollisionBeh, TTCollisionBehData>: AnimalBase
        where TMover : IGenericMover<TMoverData>, new()
        where TMoverData  : IMoverData
        where TCollisionBeh : IAnimalCollisionBehaviour, new()
        where TTCollisionBehData  : ICollisionBehaviourData
    {
        [SerializeField] private TMoverData data;
        [SerializeField] private TTCollisionBehData collisionBehaviourData;
        
        protected override void InitializeMover()
        {
            var genericMover = new TMover();
            genericMover.Initialize(data);
            Mover = genericMover;
            data.Initialize(view, transform);
        }

        protected override void InitializeCollisionBehaviour()
        {
            var genericBeh = new TCollisionBeh();
            genericBeh.Initialize(collisionBehaviourData);
            collisionBehaviourData.Initialize(transform, OnBlockedByObstacle);
            CollisionBehaviour = genericBeh;
        }
    }
}