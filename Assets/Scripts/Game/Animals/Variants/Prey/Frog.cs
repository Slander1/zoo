using Game.Animals.Behaviour.Collisions.Data;
using Game.Animals.Behaviour.Collisions.Variants;
using Game.Animals.Behaviour.Movers;
using Game.Animals.Behaviour.Movers.Data;

namespace Game.Animals.Variants.Prey
{
    public sealed class Frog : PreyBase<JumpMover, JumpMoverData, PreyCollisionBeh, CollisionBehaviourData>
    {
    }
}