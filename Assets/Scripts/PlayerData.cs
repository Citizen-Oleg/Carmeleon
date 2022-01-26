using System.Collections.Generic;
using ScriptsLevels.Inventory;
using ScriptsMenu;
using ScriptsMenu.Map;
using ScriptsMenu.Tree;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int ReagentShopSize
    {
        get => _reagentShopSize;
        set => _reagentShopSize = value;
    }
    public int ImprovedTowersSize
    {
        get => _improvedTowersSize;
        set => _improvedTowersSize = value;
    }
    public int InventorySize
    {
        get => _inventorySize;
        set => _inventorySize = value;
    }
    
    public float StoreDiscount { get; set; }
    
    public List<InventoryItem> StandardTowerLevel { get; private set; }
    public List<InventoryItem> ImprovedLevelTowers { get; private set; }

    public List<InventoryItem> ReagentsLevel => _reagentsLevel;
    public List<LevelData> PassedLevel => _passedLevel;
    public List<TalentData> ActivatedTalentDatas => _activatedTalentData;

    [SerializeField]
    private int _reagentShopSize = 2;
    [SerializeField]
    private int _improvedTowersSize = 2;
    [SerializeField]
    private int _inventorySize = 4;
    
    [SerializeField]
    private List<InventoryItem> _standardTowerLevel = new List<InventoryItem>();
    [SerializeField]
    private List<InventoryItem> _improvedLevelTowers = new List<InventoryItem>();
    [SerializeField]
    private List<InventoryItem> _reagentsLevel = new List<InventoryItem>();

    private List<LevelData> _passedLevel = new List<LevelData>();
    private List<TalentData> _activatedTalentData = new List<TalentData>();
    
    private void Start()
    {
        var loadManager = GameManager.LoadManager;
        
        _passedLevel = loadManager.LoadLevelPassed();
        _activatedTalentData = loadManager.LoadTalent();
        
        GameManager.ResourceManagerGame.SetResource(loadManager.LoadResource());
        GameManager.SettingsGame.HasHealthDisplay = loadManager.LoadSettings();
        MenuManager.TreeTalent.ActivatedTalent(_activatedTalentData);
    }

    public void StartNewLevel()
    {
        MenuManager.TreeTalent.DeactivateTalent(_activatedTalentData);
        
        var loadManager = GameManager.LoadManager;
        _passedLevel = new List<LevelData>();
        _activatedTalentData = new List<TalentData>();
        
        GameManager.ResourceManagerGame.SetResource(loadManager.DefaultSave.Resources);
        MenuManager.TreeTalent.ActivatedTalent(_activatedTalentData);
    }

    public void AddPassedLevel(LevelData passedLevelData)
    {
        _passedLevel.Add(passedLevelData);
    }

    public void AddActivatedNode(TalentData talentData)
    {
        _activatedTalentData.Add(talentData);
    }

    public void ClearActivatedTalent()
    {
        _activatedTalentData.Clear();
    }
    
    public void SetTowersForTheLevel()
    {
        StandardTowerLevel = new List<InventoryItem>(_standardTowerLevel);
        ImprovedLevelTowers = new List<InventoryItem>(_improvedLevelTowers);
    }

    public void AddImprovedTower(InventoryItem towerItem)
    {
        _improvedLevelTowers.Add(towerItem);
    }

    public void RemoveImprovedTower(InventoryItem towerItem)
    {
        _improvedLevelTowers.Remove(towerItem);
    }
}