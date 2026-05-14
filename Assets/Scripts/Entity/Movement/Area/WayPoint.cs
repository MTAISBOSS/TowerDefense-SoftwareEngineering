using UnityEngine;

namespace Entity.Movement.Area
{
    public class WayPoint : MonoBehaviour
    {
        [SerializeField] private bool flipWhenReached = false;

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public bool IsFlipped()
        {
            return flipWhenReached;
        }
    }
}