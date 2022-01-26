using System;
using DefaultNamespace;
using ResourceManager;
using SaveSystem;
using ScriptsLevels.Providers;
using ScriptsMenu.Settings;
using Tools;
using UnityEditor;
using UnityEngine;

public class GameManager : PersistentSingleton<GameManager>
{
    public static PlayerData PlayerData => instance._playerData;
    public static ScreenManager.ScreenManager ScreenManager => instance._screenManager;
    public static ResourceManagerGame ResourceManagerGame => instance._resourceManagerGame;
    public static LoadManager LoadManager => instance._loadManager;
    public static SaveManager SaveManager => instance._saveManager;
    public static SpriteProvider SpriteProvider => instance._spriteProvider;
    public static LoadingController LoadingController => instance._loadingController;
    public static SettingsGame SettingsGame => instance._settingsGame;
    
    public ScriptsMenu.Map.Level CurrentLevel { get; set; }

    [SerializeField]
    private SettingsGame _settingsGame;
    [SerializeField]
    private SpriteProvider _spriteProvider;
    [SerializeField]
    private ResourceManagerGame _resourceManagerGame;
    [SerializeField]
    private ScreenManager.ScreenManager _screenManager;
    [SerializeField]
    private PlayerData _playerData;
    [SerializeField]
    private LoadManager _loadManager;
    [SerializeField]
    private SaveManager _saveManager;
    [SerializeField]
    private LoadingController _loadingController;

    private void OnApplicationQuit()
    {
        _saveManager.SaveResource();
        _saveManager.SaveLevel();
        _saveManager.SaveTalent();
        _saveManager.SaveSettings();
    }
    
#if UNITY_EDITOR
    [MenuItem("Tools/ClearSave")]
    public static void ClearSave()
    {
        PlayerPrefs.DeleteAll();
    }
#endif
}