using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Entity
{
    [BurstCompile]
    public struct EntityMovement : IJobParallelFor
    {
        public NativeArray<Vector3> CurrentPositions;
        public NativeArray<Vector3> TargetPositions;
        public NativeArray<float> StartTimes;
        
        public float DeltaTime;
        public float CurrentTime;
        public float Speed;

        public void Execute(int index)
        {
            if(CurrentTime < StartTimes[index]) return;
            var current = CurrentPositions[index];
            var target = TargetPositions[index];
            var newPosition = Vector2.MoveTowards(current, target, Speed * DeltaTime);
            CurrentPositions[index] = newPosition;
        }
    }
}