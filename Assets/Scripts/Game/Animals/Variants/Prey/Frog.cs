using Game.Animals.Behaviour.Collisions.Controllers.Data;
using Game.Animals.Behaviour.Collisions.Controllers.Variants;
using Game.Animals.Behaviour.Movers;
using Game.Animals.Behaviour.Movers.Data;

namespace Game.Animals.Variants.Prey
{
    public sealed class Frog : PreyBase<JumpMover, JumpMoverData, 
        DefaultPreyCollisionController, CollisionControllerDataBase>
    { }
}