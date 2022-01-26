using JetBrains.Annotations;
using ScriptsLevels.Level;
using UnityEngine;

namespace View
{
    public class GameSpeedView : MonoBehaviour
    {
        [UsedImplicitly]
        public void SetSpeedGame(int speed)
        {
            if (speed == 0)
            {
                LevelManager.instance.SetState(StateLevel.Pause);
            }
            else
            {
                LevelManager.instance.SetState(StateLevel.Normal, speed);
            }
        }
    }
}