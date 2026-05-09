using System.Collections.Generic;
using UnityEngine;

namespace Entity.Movement.Area
{
    public class WayPointArea : MovementArea
    {
        [SerializeField] private bool isLoop = true;
        private readonly List<Vector3> _wayPoints = new();

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            SetupPoints();
            for (int i = 0; i < _wayPoints.Count; i++)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawSphere(_wayPoints[i], 0.1f);
                
                var nextIndex = i + 1;
                if (nextIndex == _wayPoints.Count)
                {
                    if (!isLoop) return;
                    nextIndex = 0;
                }
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(_wayPoints[i % _wayPoints.Count], _wayPoints[nextIndex % _wayPoints.Count]);
            }
        }
#endif

        private void Awake()
        {
            SetupPoints();
            Count = _wayPoints.Count;
        }

        public override Vector2 GetPoint(int index)
        {
            if (!isLoop && index == Count)
            {
                return UnInitializedVector2.Value;
            }
            
            var point = _wayPoints[index % Count];
            return point;
        }

        private void SetupPoints()
        {
            _wayPoints.Clear();
            foreach (var wayPointTransform in GetComponentsInChildren<Transform>())
            {
                if (wayPointTransform == transform) continue;
                _wayPoints.Add(wayPointTransform.position);
            }
        }
    }
}