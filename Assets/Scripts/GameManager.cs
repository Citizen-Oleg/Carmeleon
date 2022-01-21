using System;
using ResourceManager;
using SaveSystem;
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
    
    public ScriptsMenu.Map.Level CurrentLevel { get; set; }
    
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

    private void OnApplicationQuit()
    {
        _saveManager.SaveResource();
        _saveManager.SaveLevel();
        _saveManager.SaveTalent();
    }

    [MenuItem("Tools/ClearSave")]
    public static void ClearSave()
    {
        PlayerPrefs.DeleteAll();
    }
}