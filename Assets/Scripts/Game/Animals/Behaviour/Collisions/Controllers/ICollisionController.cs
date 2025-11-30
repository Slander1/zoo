using System;
using System.Collections.Generic;

namespace Game.Animals.Behaviour.Collisions.Controllers
{
    public interface ICollisionController
    {
        public Dictionary<Type, CollisionReactBase> Reacts { get; }
        public bool TryGetCollisionReact(Type interfaceType, out CollisionReactBase react);
    }
}