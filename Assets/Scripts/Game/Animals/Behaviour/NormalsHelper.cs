using UnityEngine;

namespace Game.Animals.Behaviour
{
    public static class NormalsHelper
    {
        public static Vector2 GetPerpendicular(Vector2 v, bool clockwise)
        {
            return clockwise
                ? new Vector2(v.y, -v.x)
                : new Vector2(-v.y, v.x);
        }

        public static Vector2 ChooseSlideDirection(Vector2 dir, Vector2 normal, Vector2 cw, Vector2 ccw)
        {
            var dotCw  = Vector2.Dot(cw,  normal);
            var dotCcw = Vector2.Dot(ccw, normal);

            var cwInside  = dotCw  < 0f;
            var ccwInside = dotCcw < 0f;

            if (cwInside && ccwInside)
                return (dotCw < dotCcw ? cw : ccw).normalized;

            if (cwInside)
                return cw.normalized;

            if (ccwInside)
                return ccw.normalized;

            return (-dir).normalized;
        }
    }
}