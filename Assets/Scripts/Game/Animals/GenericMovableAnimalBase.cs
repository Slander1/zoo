using Game.Animals.Behaviour.Movers;
using Game.Animals.Behaviour.Movers.Data;
using UnityEngine;

namespace Game.Animals
{
    public class GenericMovableAnimalBase<TMover, TData>: AnimalBase
        where TMover : IGenericMover<TData>, new()
        where TData  : IMoverData
    {
        [SerializeField] private TData data;
        
        protected override void InitializeMover()
        {
            var genericMover = new TMover();
            genericMover.Initialize(data);
            Mover = genericMover;
            data.Initialize(view, transform);
        }
    }
}