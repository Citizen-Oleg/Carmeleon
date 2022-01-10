using Tools;
using UnityEngine;

public class GameManager : PersistentSingleton<GameManager>
{
    public static PlayerData PlayerData => instance._playerData;
    public ScriptsMenu.Map.Level CurrentLevel { get; set; }

    [SerializeField]
    private PlayerData _playerData;
}