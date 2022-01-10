using System.Collections.Generic;
using ResourceManager;

namespace ScreenManager
{
    public class RewardScreenContext : BaseContext
    {
        public List<Resource> RewardedResources { get; }
        public int ExperienceReward { get; }

        public RewardScreenContext(List<Resource> rewardedResources, int experienceReward)
        {
            RewardedResources = rewardedResources;
            ExperienceReward = experienceReward;
        }
    }
}