using Entity.Movement;
using Health;
using UnityEngine;
namespace FlyweightEntities.DefenseNodes
{
    public static class ClosestDamagableFinder
    {
        private static EntityBatchMovement EntityBatchMovement => EntityBatchMovement.instance;
        public static IDamagable GetClosestDamagable(Transform transform)
        {
            var shortestDistance = float.MaxValue;
            Transform targetTransform = null;
            foreach (var entityTransform in EntityBatchMovement.GetEntityTransforms())
            {
                var distance = Vector2.Distance(entityTransform.position, transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    targetTransform = entityTransform;
                }
            }

            var damageableTarget =
                (targetTransform != null) ? targetTransform.GetComponent<IDamagable>() : null;
            return damageableTarget;
        }
    }
}