using EnemyComponent;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static PlayerData PlayerData => instance._playerData;
        
    [SerializeField]
    private PlayerData _playerData;
}