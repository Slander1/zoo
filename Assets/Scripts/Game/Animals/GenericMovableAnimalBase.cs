using Game.Animals.Behaviour.Collisions.Controllers;
using Game.Animals.Behaviour.Collisions.Controllers.Data;
using Game.Animals.Behaviour.Movers;
using Game.Animals.Behaviour.Movers.Data;
using UnityEngine;

namespace Game.Animals
{
    public abstract class GenericMovableAnimalBase<TMover, TMoverData, TCollisionController, TCollisionData>
        : AnimalBase
        where TMover : IGenericMover<TMoverData>, new()
        where TMoverData  : IMoverData
        where TCollisionController : IGenericICollisionController<TCollisionData>, new()
        where TCollisionData : ICollisionControllerData
     {
        [SerializeField] private TMoverData moverData;
        [SerializeField] private TCollisionData collisionData;
        
        protected override void InitializeMover()
        {
            var genericMover = new TMover();
            genericMover.Initialize(moverData);
            Mover = genericMover;
            moverData.Initialize(view, transform);
        }

        protected override void InitializeCollisionController()
        {
            var genericICollisionController = new TCollisionController();
            genericICollisionController.Initialize(collisionData);
            CollisionController = genericICollisionController;
            collisionData.Initialize(Mover.OnBlockedByObstacle, Mover.Repulsed);
        }
     }
}