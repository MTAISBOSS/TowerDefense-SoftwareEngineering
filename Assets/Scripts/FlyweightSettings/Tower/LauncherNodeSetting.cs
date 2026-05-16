using FlyweightSettings.Projectiles;

namespace FlyweightSettings.Tower
{
    public class LauncherNodeSetting : Flyweight.FlyweightSettings
    {
        public ProjectileSetting projectileSetting;
        public float upgradeRate;
    }
}