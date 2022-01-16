using JetBrains.Annotations;
using ScreenManager;
using UnityEngine;

namespace ScriptsLevels.Screen
{
    public class ButtonMenu : MonoBehaviour
    {
        [UsedImplicitly]
        public void OpenMenu()
        {
            GameManager.ScreenManager.OpenScreen(ScreenType.Menu);
        }
    }
}
