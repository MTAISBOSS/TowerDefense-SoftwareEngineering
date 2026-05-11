using System;
using System.Collections.Generic;
using Entity.Movement.Area;
using Flyweight;
using Unity.Collections;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;

namespace Entity.Movement
{
    public class EntityBatchMovement : MonoBehaviour
    {
        public static EntityBatchMovement Instance;
        [SerializeField] private WayPointArea movementArea;
        [SerializeField] private float speed;
        [SerializeField] private float delayBetweenEntities;
        [SerializeField] private float reachDistance = 0.1f;

        private NativeArray<Vector2> currentPositions;
        private NativeArray<Vector2> targetPositions;
        private NativeArray<float> startTimes;

        private int[] wayPointIndices;
        private List<IMovable> movableEntities = new();
        private List<IMovable> movableEntitiesToBeAdded = new();
        private List<IMovable> movableEntitiesToBeKilled = new();
        private List<Transform> entityTransforms = new();
        private int entityCount;
        private bool[] activeSlots;

        private Vector2 initialPosition;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            initialPosition = transform.position;
        }

        private void Update()
        {
            if (activeSlots == null) InitializeArrays();
            if (activeSlots == null) return;

            ProcessPendingChanges();
            DoMovementJob();
            ApplyNewPositions();
            CheckWayPointReached();
        }

        private void InitializeArrays()
        {
            if (movableEntitiesToBeAdded.Count == 0) return;

            movableEntities.AddRange(movableEntitiesToBeAdded);
            movableEntitiesToBeAdded.Clear();
    
            entityCount = movableEntities.Count;
            entityTransforms = new List<Transform>();
            for (int i = 0; i < entityCount; i++)
                entityTransforms.Add(movableEntities[i].GetTransform());

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

            activeSlots = new bool[entityCount];
            for (int i = 0; i < entityCount; i++)
                activeSlots[i] = true;
        }

        private void ProcessPendingChanges()
        {
            for (int i = 0; i < movableEntitiesToBeKilled.Count; i++)
            {
                int index = movableEntities.IndexOf(movableEntitiesToBeKilled[i]);
                if (index >= 0)
                {
                    activeSlots[index] = false;
                }
            }

            movableEntitiesToBeKilled.Clear();

            for (int i = 0; i < movableEntitiesToBeAdded.Count; i++)
            {
                int freeSlot = -1;
                for (int j = 0; j < activeSlots.Length; j++)
                {
                    if (!activeSlots[j])
                    {
                        freeSlot = j;
                        break;
                    }
                }

                if (freeSlot < 0)
                {
                    GrowArrays(movableEntitiesToBeAdded[i]);
                }
                else
                {
                    var entity = movableEntitiesToBeAdded[i];
                    movableEntities[freeSlot] = entity;
                    entityTransforms[freeSlot] = entity.GetTransform();
                    currentPositions[freeSlot] = entity.GetTransform().position;
                    targetPositions[freeSlot] = movementArea.GetPoint(0);
                    startTimes[freeSlot] = Time.time + freeSlot * delayBetweenEntities;
                    wayPointIndices[freeSlot] = 0;
                    activeSlots[freeSlot] = true;
                }
            }

            movableEntitiesToBeAdded.Clear();
        }

        private void GrowArrays(IMovable newEntity)
        {
            int oldCount = entityCount;
            entityCount++;

            var newCurrentPositions = new NativeArray<Vector2>(entityCount, Allocator.Persistent);
            var newTargetPositions = new NativeArray<Vector2>(entityCount, Allocator.Persistent);
            var newStartTimes = new NativeArray<float>(entityCount, Allocator.Persistent);
            var newWayPointIndices = new int[entityCount];
            var newActiveSlots = new bool[entityCount];
            var newMovableEntities = new List<IMovable>(movableEntities);
            var newEntityTransforms = new List<Transform>(entityTransforms);

            for (int i = 0; i < oldCount; i++)
            {
                newCurrentPositions[i] = currentPositions[i];
                newTargetPositions[i] = targetPositions[i];
                newStartTimes[i] = startTimes[i];
                newWayPointIndices[i] = wayPointIndices[i];
                newActiveSlots[i] = activeSlots[i];
            }

            newMovableEntities.Add(newEntity);
            newEntityTransforms.Add(newEntity.GetTransform());
            newCurrentPositions[oldCount] = newEntity.GetTransform().position;
            newTargetPositions[oldCount] = movementArea.GetPoint(0);
            newStartTimes[oldCount] = Time.time + oldCount * delayBetweenEntities;
            newWayPointIndices[oldCount] = 0;
            newActiveSlots[oldCount] = true;

            DisposeAll();

            currentPositions = newCurrentPositions;
            targetPositions = newTargetPositions;
            startTimes = newStartTimes;
            wayPointIndices = newWayPointIndices;
            activeSlots = newActiveSlots;
            movableEntities = newMovableEntities;
            entityTransforms = newEntityTransforms;
        }

        private void DisposeAll()
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
                if (!activeSlots[i]) continue;
                entityTransforms[i].position = currentPositions[i];
            }
        }

        private void CheckWayPointReached()
        {
            float reachDistanceSqr = reachDistance * reachDistance;

            for (int i = 0; i < entityCount; i++)
            {
                if (!activeSlots[i]) continue;
                if (!HasReachedTarget(i, reachDistanceSqr))
                    continue;

                AdvanceToNextWaypoint(i);
            }
        }

        private bool HasReachedTarget(int index, float reachDistanceSqr)
        {
            Vector2 currentPosition = currentPositions[index];
            Vector2 targetPosition = targetPositions[index];

            return (currentPosition - targetPosition).sqrMagnitude <= reachDistanceSqr;
        }

        private void AdvanceToNextWaypoint(int index)
        {
            if (!activeSlots[index]) return;
    
            wayPointIndices[index]++;

            Vector2 nextPoint = movementArea.GetPoint(wayPointIndices[index]);

            if (nextPoint == UnInitializedVector2.Value)
            {
                movableEntities[index].Stop();
                return;
            }

            targetPositions[index] = nextPoint;
        }

        public void Register(IMovable movable)
        {
            if (movableEntitiesToBeAdded.Contains(movable))
                return;
    
            movable.GetTransform().position = initialPosition;
            movableEntitiesToBeAdded.Add(movable);
        }

        public void UnRegister(IMovable movable)
        {
            if (movableEntitiesToBeKilled.Contains(movable))
                return;
    
            movable.GetTransform().position = initialPosition;
            movableEntitiesToBeKilled.Add(movable);
        }
    }
}