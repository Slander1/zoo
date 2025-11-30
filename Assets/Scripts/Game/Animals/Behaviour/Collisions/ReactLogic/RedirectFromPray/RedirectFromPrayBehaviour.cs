using System;
using Game.Animals.Roles;
using Game.Animals.StateInterfaces;
using Game.ObjectOnSceneMarkers;
using UnityEngine;

namespace Game.Animals.Behaviour.Collisions.ReactLogic.RedirectFromPray
{
    public sealed class RedirectFromPrayBehaviour : CollisionReactGenericBase<RedirectFromPrayData>, IReactTo<IPray>
    {
        public RedirectFromPrayBehaviour(RedirectFromPrayData data) : base(data)
        { }

        public override void ReactTo(IInteractableObjectOnScene reactFrom, InteractableObjectOnScene reactTo)
        {
            if (reactFrom is not IPray prayFrom || reactTo is not IPray prayTo)
                throw new NotImplementedException();
            
            var fromPos = prayFrom.Transform.position;
            var toPos   = prayTo.Transform.position;

            var dirFrom = (fromPos - toPos);
            dirFrom.y = 0f;

            if (dirFrom == Vector3.zero) dirFrom = UnityEngine.Random.insideUnitSphere;

            dirFrom.Normalize();
            var strength = Data.PushStrength;

            Data.OnRepulsed(dirFrom, strength);
        }
    }
}