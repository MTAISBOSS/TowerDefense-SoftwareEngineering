using Health;

namespace FlyweightEntities.Projectiles
{
    public interface IProjectile
    {
        public void Initialize(IDamage moveTarget);
    }
}