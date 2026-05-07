using System.Collections.Generic;
using UnityEngine;

namespace Entity
{
    public class WayPointArea : MovementArea
    {
        private readonly List<Vector3> _wayPoints = new();

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            SetupPoints();
            for (int i = 0; i < _wayPoints.Count; i++)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawSphere(_wayPoints[i], 0.1f);
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(_wayPoints[i % _wayPoints.Count], _wayPoints[(i + 1) % _wayPoints.Count]);
            }
        }
#endif

        private void Start()
        {
            SetupPoints();
            Count = _wayPoints.Count;
        }

        public override Vector3 GetPoint(int index)
        {
            var point = _wayPoints[index % _wayPoints.Count];
            return point;
        }

        private void SetupPoints()
        {
            _wayPoints.Clear();
            foreach (var wayPointTransform in GetComponentsInChildren<Transform>())
            {
                if(wayPointTransform == transform) continue;
                _wayPoints.Add(wayPointTransform.position);
            }
        }
    }
}