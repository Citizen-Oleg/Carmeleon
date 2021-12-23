using System.Collections.Generic;
using Inventory;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public List<TowerItem> StandardTowerLevel => _standardTowerLevel;
    public List<TowerItem> ImprovedLevelTowers => _improvedLevelTowers;
    public List<Item> ReagentsLevel => _reagentsLevel;
    public int ReagentShopSize => _reagentShopSize;
    public int ImprovedTowersSize => _improvedTowersSize;

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
}
