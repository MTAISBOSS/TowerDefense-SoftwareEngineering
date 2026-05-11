using FlyweightSettings.FlyweightSettings;

namespace FlyweightEntities.DefenseNodes
{
    public class FireOrbLauncherNode : DefenseNode, IUpgradable
    {
        private new FireOrbLauncherNodeSetting settings => (FireOrbLauncherNodeSetting)base.settings;

        public void Upgrade()
        {
        }
    }
}