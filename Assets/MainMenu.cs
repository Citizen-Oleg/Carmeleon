using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using ScreenManager;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [UsedImplicitly]
    public void OpenBestiary()
    {
        GameManager.ScreenManager.OpenScreen(ScreenType.BestiaryScreen);
    }
}
