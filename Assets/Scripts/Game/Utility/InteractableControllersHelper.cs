using System;
using System.Collections.Generic;

namespace Game.Utility
{
    public class InteractableControllersHelper
    {
        public static void RegisterMarkerInterfaces<TMarker>(object source,
            Dictionary<Type, TMarker> targetDict)
        {
            if (source is not TMarker marker)
                throw new ArgumentException("source must implement TMarker", nameof(source));

            var type = source.GetType();
            var interfaces = type.GetInterfaces();

            foreach (var iface in interfaces)
            {
                if (!typeof(TMarker).IsAssignableFrom(iface))
                    continue;

                if (iface == typeof(TMarker))
                    continue;

                if (targetDict.ContainsKey(iface))
                    throw new ArgumentException(
                        $"Dictionary already contains controller for interface {iface.Name}");

                targetDict[iface] = marker;
            }
        }
    }
}