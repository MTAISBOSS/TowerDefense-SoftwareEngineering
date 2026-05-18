using System.Collections.Generic;
using UnityEngine;
using Logger = Utilities.Logger;

namespace Entity.Movement.Area
{
    public class WayPointArea : MonoBehaviour
    {
        [SerializeField] private bool isLoop = true;
        private readonly List<WayPoint> _wayPoints = new();

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            SetupPoints();
            for (int i = 0; i < _wayPoints.Count; i++)
            {
                Gizmos.color = (_wayPoints[i].IsFlipped()) ? Color.red : Color.blue;
                Gizmos.DrawSphere(_wayPoints[i].GetPosition(), 0.1f);
                
                var nextIndex = i + 1;
                if (nextIndex == _wayPoints.Count)
                {
                    if (!isLoop) return;
                    nextIndex = 0;
                }
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(_wayPoints[i % _wayPoints.Count].GetPosition() , _wayPoints[nextIndex % _wayPoints.Count].GetPosition());
            }
        }

#endif

        private void Awake()
        {
            SetupPoints();
        }

        public int GetWayPointCount()
        {
            return _wayPoints.Count;
        }

        public Vector2 GetPointPosition(int index)
        {
            if (!isLoop && index >= _wayPoints.Count)
            {
                return UnInitializedVector2.Value;
            }
            
            var point = GetPoint(index);
            return point.GetPosition();
        }

        public bool IsWayPointFlipped(int index)
        {
            var point = GetPoint(index);
            return point.IsFlipped();
        }

        private WayPoint GetPoint(int index)
        {
            return _wayPoints[index % _wayPoints.Count];
        }

        private void SetupPoints()
        {
            _wayPoints.Clear();
            var wayPoints = GetComponentsInChildren<WayPoint>();
            foreach (var wayPoint in wayPoints)
            {
                _wayPoints.Add(wayPoint);
            }
        }
    }
}