using System;
using System.Collections.Generic;

namespace Game.Animals.Behaviour.Collisions.Controllers
{
    public abstract class CollisionControllerBase : ICollisionController
    {
        public Dictionary<Type, CollisionReactBase> Reacts => _reacts;

        private readonly Dictionary<Type, CollisionReactBase> _reacts = new();

        public bool TryGetCollisionReact(Type interfaceType, out CollisionReactBase react)
        {
            return _reacts.TryGetValue(interfaceType, out react);
        }
    }
}