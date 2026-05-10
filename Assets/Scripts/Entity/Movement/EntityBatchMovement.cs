using System.Collections.Generic;
using Entity.Movement.Area;
using Flyweight;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Entity.Movement
{
    public class EntityBatchMovement : MonoBehaviour
    {
        [SerializeField] private WayPointArea movementArea;
        [SerializeField] private float speed;
        [SerializeField] private float delayBetweenEntities;
        [SerializeField] private float reachDistance = 0.1f;

        private NativeArray<Vector2> currentPositions;
        private NativeArray<Vector2> targetPositions;
        private NativeArray<float> startTimes;

        private int[] wayPointIndices;
        private List<Flyweight.Flyweight> flyweightEntities;
        private List<Transform> entityTransforms;
        private int entityCount;

        public void Setup(List<Transform> transforms, List<Flyweight.Flyweight> entities)
        {
            entityTransforms = transforms;
            entityCount = entityTransforms.Count;
            flyweightEntities = entities;
            InitializeArrays();
        }

        private void Update()
        {
            DoMovementJob();
            ApplyNewPositions();
            CheckWayPointReached();
        }

        private void OnDestroy()
        {
            if (currentPositions.IsCreated)
            {
                currentPositions.Dispose();
            }

            if (targetPositions.IsCreated)
            {
                targetPositions.Dispose();
            }

            if (startTimes.IsCreated)
            {
                startTimes.Dispose();
            }
        }

        private void InitializeArrays()
        {
            currentPositions = new NativeArray<Vector2>(entityCount, Allocator.Persistent);
            targetPositions = new NativeArray<Vector2>(entityCount, Allocator.Persistent);
            startTimes = new NativeArray<float>(entityCount, Allocator.Persistent);

            wayPointIndices = new int[entityCount];
            for (int i = 0; i < entityCount; i++)
            {
                currentPositions[i] = entityTransforms[i].position;
                targetPositions[i] = movementArea.GetPoint(0);
                startTimes[i] = i * delayBetweenEntities;
                wayPointIndices[i] = 0;
            }
        }

        private void DoMovementJob()
        {
            var job = new EntityMovementJob()
            {
                CurrentPositions = currentPositions,
                TargetPositions = targetPositions,
                StartTimes = startTimes,
                DeltaTime = Time.deltaTime,
                CurrentTime = Time.time,
                Speed = speed
            };
            var handle = job.Schedule(currentPositions.Length, 64);
            handle.Complete();
        }


        private void ApplyNewPositions()
        {
            for (int i = 0; i < entityCount; i++)
            {
                entityTransforms[i].position = currentPositions[i];
            }
        }

        private void CheckWayPointReached()
        {
            float reachDistanceSqr = reachDistance * reachDistance;

            for (int i = 0; i < entityCount; i++)
            {
                if (!HasReachedTarget(i, reachDistanceSqr))
                    continue;

                AdvanceToNextWaypoint(i);
            }
        }

        private bool HasReachedTarget(int index, float reachDistanceSqr)
        {
            Vector2 currentPosition = entityTransforms[index].position;
            Vector2 targetPosition = targetPositions[index];

            return (currentPosition - targetPosition).sqrMagnitude <= reachDistanceSqr;
        }

        private void AdvanceToNextWaypoint(int index)
        {
            wayPointIndices[index]++;

            Vector2 nextPoint = movementArea.GetPoint(wayPointIndices[index]);

            if (nextPoint == UnInitializedVector2.Value)
            {
                FlyweightFactory.ReturnToPool(flyweightEntities[index]);
                return;
            }

            targetPositions[index] = nextPoint;
        }

    }
}