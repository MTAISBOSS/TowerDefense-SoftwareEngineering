using AttackStrategies;
using Entity.Movement;
using Health;
using UnityEngine;

namespace FlyweightEntities.DefenseNodes
{
    public abstract class DefenseNode : Flyweight.Flyweight
    {
        public float coolDownTimer = 0f;
        protected IAttackStrategy AttackStrategy;
        
        private void Update()
        {
            if(AttackStrategy == null) return;
            var target = FindTarget();
            if (target == null) return;
            coolDownTimer += Time.deltaTime;
            if (coolDownTimer >= 1f / AttackStrategy.FireRate)
            {
                AttackStrategy.Attack(target , transform.position);
                coolDownTimer = 0f;
            }
        }

        public virtual IDamage FindTarget()
        {
            var entities = EntityBatchMovement.instance;
            var shortestDistance = float.MaxValue;
            Transform targetTransform = null;
            foreach (var entityTransform in entities.GetEntityTransforms())
            {
                var distance = Vector2.Distance(entityTransform.position, transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    targetTransform = entityTransform;
                }
            }

            var damageableTarget =
                (targetTransform != null) ? targetTransform.GetComponent<IDamage>() : null;
            return damageableTarget;
        }
    }
}