namespace FlyweightEntities.Projectiles.ProjectileCommands
{
    public interface IProjectileCommand
    {
        IProjectileCommand Initialize(params object[] args);
    }
}