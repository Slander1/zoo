using System;
using System.Collections.Generic;

namespace Game.Animals.Behaviour.Collisions.Controllers
{
    public abstract class CollisionControllerBase : ICollisionController
    {
        public Dictionary<Type, CollisionReactBase> Reacts => reacts;

        private Dictionary<Type, CollisionReactBase> reacts = new();

        public bool TryGetCollisionReact(Type interfaceType, out CollisionReactBase react)
        {
            return reacts.TryGetValue(interfaceType, out react);
        }
    }
}