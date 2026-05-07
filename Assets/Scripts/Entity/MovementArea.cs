using UnityEngine;

namespace Entity
{
    public abstract class MovementArea : MonoBehaviour
    {
        public abstract Vector3 GetPoint(int index);
        public int Count { get; protected set; }
    }
}