using Entity.Movement.Area;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Entity.Movement
{
    [BurstCompile]
    public struct EntityMovementJob : IJobParallelFor
    {
        public NativeArray<Vector2> CurrentPositions;
        public NativeArray<Vector2> TargetPositions;
        public NativeArray<float> StartTimes;
        
        public float DeltaTime;
        public float CurrentTime;
        public float Speed;

        public void Execute(int index)
        {
            if(CurrentTime < StartTimes[index]) return;
            var current = CurrentPositions[index];
            var target = TargetPositions[index];
            if(target ==  UnInitializedVector2.Value) return;
            
            var newPosition = Vector2.MoveTowards(current, target, Speed * DeltaTime);
            CurrentPositions[index] = newPosition;
        }
    }
}