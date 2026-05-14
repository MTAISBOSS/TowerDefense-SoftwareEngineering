using FlyweightSettings.Tower.FlyweightSettings;

namespace FlyweightEntities.DefenseNodes
{
    public class LaserBeamNode: DefenseNode,IUpgradable
    {
        private new LaserBeamNodeSetting settings => (LaserBeamNodeSetting)base.settings;

        public void Upgrade()
        {
            
        }
    }
}