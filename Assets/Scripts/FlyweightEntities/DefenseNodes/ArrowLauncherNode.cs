using FlyweightSettings.Tower;

namespace FlyweightEntities.DefenseNodes
{
    public class ArrowLauncherNode : DefenseNode,IUpgradable
    {
        private new ArrowLauncherNodeSetting settings => (ArrowLauncherNodeSetting)base.settings;
        public void Upgrade()
        {
            
        }
    }
}