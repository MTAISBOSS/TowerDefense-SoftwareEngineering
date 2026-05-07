using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Entity
{
    public class EntityBatchMovement : MonoBehaviour
    {
        [SerializeField] private MovementArea movementArea;
        [SerializeField] private float speed;
        [SerializeField] private float delayBetweenEntities;
        [SerializeField] private float reachDistance = 0.1f;

        private NativeArray<Vector3> currentPositions;
        private NativeArray<Vector3> targetPositions;
        private NativeArray<float> startTimes;
        
        private int[] wayPointIndices;
        private List<Transform> entityTransforms;
        private int entityCount;

        public void Setup(List<Transform> transforms)
        {
            entityTransforms = transforms;
            entityCount = entityTransforms.Count;
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
            currentPositions = new NativeArray<Vector3>(entityCount, Allocator.Persistent);
            targetPositions = new NativeArray<Vector3>(entityCount, Allocator.Persistent);
            startTimes = new NativeArray<float>(entityCount, Allocator.Persistent);
            
            wayPointIndices = new int[entityCount];
            for (int i = 0; i < entityCount; i++)
            {
                currentPositions[i] = entityTransforms[i].position;
                targetPositions[i] = movementArea.GetPoint(0);
                startTimes[i] =  i * delayBetweenEntities;
                wayPointIndices[i] = 0;
            }
        }

        private void DoMovementJob()
        {
            var job = new EntityMovement()
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
            for (int i = 0; i < entityCount; i++)
            {
                if (Vector2.Distance(entityTransforms[i].position, targetPositions[i]) <= reachDistance)
                {
                    wayPointIndices[i]++;
                    var nextIndex = wayPointIndices[i] % movementArea.Count;
                    targetPositions[i] = movementArea.GetPoint(nextIndex);
                }
            }
        }
    }
}