
using UnityEngine;

namespace Game.Animals.StateInterfaces
{
    public interface IRepulsable
    {
        public void Repulsed(Vector3 direction, float strength);
    }
}