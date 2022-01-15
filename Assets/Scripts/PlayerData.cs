using System.Collections.Generic;
using Inventory;
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
    
    public int StoreDiscount { get; set; }
    
    public List<TowerItem> StandardTowerLevel { get; private set; }
    public List<TowerItem> ImprovedLevelTowers { get; private set; }

    public List<Item> ReagentsLevel => _reagentsLevel;
    public List<ScriptsMenu.Map.Level> PassedLevel => _passedLevel;
    public List<TalentNode> ActivatedTalentNodes => _activatedTalentNodesNodes;

    [SerializeField]
    private int _reagentShopSize = 2;
    [SerializeField]
    private int _improvedTowersSize = 2;
    [SerializeField]
    private int _inventorySize = 4;
    
    [SerializeField]
    private List<TowerItem> _standardTowerLevel = new List<TowerItem>();
    [SerializeField]
    private List<TowerItem> _improvedLevelTowers = new List<TowerItem>();
    [SerializeField]
    private List<Item> _reagentsLevel = new List<Item>();

    private readonly List<ScriptsMenu.Map.Level> _passedLevel = new List<ScriptsMenu.Map.Level>();
    private readonly List<TalentNode> _activatedTalentNodesNodes = new List<TalentNode>();

    public void AddPassedLevel(ScriptsMenu.Map.Level passedLevel)
    {
        _passedLevel.Add(passedLevel);
    }

    public void AddActivatedNode(TalentNode talentNode)
    {
        _activatedTalentNodesNodes.Add(talentNode);
    }

    public void ClearActivatedNode()
    {
        _activatedTalentNodesNodes.Clear();
    }
    
    public void SetTowersForTheLevel()
    {
        StandardTowerLevel = new List<TowerItem>(_standardTowerLevel);
        ImprovedLevelTowers = new List<TowerItem>(_improvedLevelTowers);
    }
}