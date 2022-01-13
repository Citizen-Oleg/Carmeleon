using JetBrains.Annotations;
using UnityEngine;

namespace View
{
    public class GameSpeedView : MonoBehaviour
    {
        [UsedImplicitly]
        public void SetSpeedGame(int speed)
        {
            Time.timeScale = speed;
        }
    }
}