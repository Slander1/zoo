using Game.Animals.Behaviour.Collisions.Controllers.Data;
using Game.Animals.Behaviour.Collisions.Controllers.Variants;
using Game.Animals.Behaviour.Movers;
using Game.Animals.Behaviour.Movers.Data;

namespace Game.Animals.Variants.Predators
{
    public class Snake : PredatorBase<LinearMover, DataBase, DefaultPredatorCollisionController, CollisionControllerDataBase>
    { }
}