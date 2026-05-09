using UnityEngine;

namespace Entity.Movement.Area
{
    public abstract class MovementArea : MonoBehaviour
    {
        public abstract Vector2 GetPoint(int index);
        protected int Count { get; set; }
    }
}