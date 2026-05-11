using UnityEngine;

namespace Entity.Movement
{
    public interface IMovable
    {
        void Stop();
        Transform GetTransform();
    }
}