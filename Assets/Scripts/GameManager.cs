using ResourceManager;
using Tools;
using UnityEngine;

public class GameManager : PersistentSingleton<GameManager>
{
    public static PlayerData PlayerData => instance._playerData;
    public static ScreenManager.ScreenManager ScreenManager => instance._screenManager;
    public static ResourceManagerGame ResourceManagerGame => instance._resourceManagerGame;

    public ScriptsMenu.Map.Level CurrentLevel { get; set; }
    
    [SerializeField]
    private ResourceManagerGame _resourceManagerGame;
    [SerializeField]
    private ScreenManager.ScreenManager _screenManager;
    [SerializeField]
    private PlayerData _playerData;
}