using System;
using Unit;

namespace Events
{
    public static class BuildNodeEvent
    {
        public static Action<BuildNode> OnBuildNodeCreated;
        public static void RaiseBuildNodeCreated(BuildNode node) => OnBuildNodeCreated?.Invoke(node);
        
        public static Action<BuildNode> OnBuildNodeDestroyed;
        public static void RaiseBuildNodeDestroyed(BuildNode node) => OnBuildNodeDestroyed?.Invoke(node);
    }
}