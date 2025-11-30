using Game.Animals.Behaviour.Movers;
using Game.Animals.Behaviour.Movers.Data;
using UnityEngine;

namespace Game.Animals.Variants
{
    public abstract class JumpingAnimals: AnimalBase
    {
        [SerializeField] private JumpMoverData jumpMoverData;
        
        protected override void InitializeMover()
        {
            jumpMoverData.Initialize(view, transform);
            Mover = new JumpMover(jumpMoverData);
        }
    }
}