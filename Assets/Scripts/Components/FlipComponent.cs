using UnityEngine;

namespace CloudeDev.Components
{
    public class FlipComponent
    {
        public bool faceRight;
        public Transform Reflect(float directionX, Transform transform)
        {
            if (directionX < 0 && !faceRight)
            {
                transform.Rotate(0, -180, 0);
                faceRight = !faceRight;
                return transform;
            }
            else if (directionX > 0 && faceRight)
            {
                transform.Rotate(0, 180, 0);
                faceRight = !faceRight;
                return transform;
            }

            return null;
        }
    }
}