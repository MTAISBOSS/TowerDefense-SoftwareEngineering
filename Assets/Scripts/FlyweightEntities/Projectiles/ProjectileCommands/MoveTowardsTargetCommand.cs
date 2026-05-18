using UnityEngine;

namespace FlyweightEntities.Projectiles.ProjectileCommands
{
    public class MoveTowardsTargetCommand : MonoBehaviour , IProjectileCommand
    {
        private float speed;

        public void Execute(Transform targetTransform)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                targetTransform.position, speed * Time.deltaTime);
        }

        public IProjectileCommand Initialize(params object[] args)
        {
            speed = (float)args[0];
            return this;
        }
    }
}