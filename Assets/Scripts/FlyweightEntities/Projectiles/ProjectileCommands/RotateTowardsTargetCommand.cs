using UnityEngine;

namespace FlyweightEntities.Projectiles.ProjectileCommands
{
    public class RotateTowardsTargetCommand : MonoBehaviour
    {
        public void Execute(Transform targetTransform)
        {
            var direction = (targetTransform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }
}