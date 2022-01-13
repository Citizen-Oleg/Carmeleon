using System.Collections.Generic;
using Inventory;
using Towers;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public List<TowerItem> StandardTowerLevel { get; private set; }
    public List<TowerItem> ImprovedLevelTowers { get; private set; }
    public List<Item> ReagentsLevel => _reagentsLevel;
    public int ReagentShopSize => _reagentShopSize;
    public int ImprovedTowersSize => _improvedTowersSize;

    public List<ScriptsMenu.Map.Level> PassedLevel => _passedLevel;

    [SerializeField]
    private int _reagentShopSize;
    [SerializeField]
    private int _improvedTowersSize;
    
    [SerializeField]
    private List<TowerItem> _standardTowerLevel = new List<TowerItem>();
    [SerializeField]
    private List<TowerItem> _improvedLevelTowers = new List<TowerItem>();
    [SerializeField]
    private List<Item> _reagentsLevel = new List<Item>();

    private readonly List<ScriptsMenu.Map.Level> _passedLevel = new List<ScriptsMenu.Map.Level>();

    public void AddPassedLevel(ScriptsMenu.Map.Level passedLevel)
    {
        _passedLevel.Add(passedLevel);
    }
    
    public void SetTowersForTheLevel()
    {
        StandardTowerLevel = new List<TowerItem>(_standardTowerLevel);
        ImprovedLevelTowers = new List<TowerItem>(_improvedLevelTowers);
    }
}