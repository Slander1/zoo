using System;
using Game.ObjectOnSceneMarkers;

namespace Game.Animals.StateInterfaces
{
    public interface IReactTo<in TOther> where TOther : IInteractableObjectOnScene
    {
        public Type ReactToType => typeof(TOther);
    }
}