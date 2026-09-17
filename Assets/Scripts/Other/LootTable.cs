using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LootTable
{
    public LootItemChancePair defaultDrop;
    public string m_name;
    public static Dictionary<string, LootTable> LootTables = new Dictionary<string, LootTable>();
    public List<LootItemChancePair> lootTable;


    public bool IsSingetonLoot
    {
        get
        {
            return this.lootTable == null;
        }
    }


    public LootTable(GameObject defaultDrop, string lootName)
    {
        if (defaultDrop == null)
        {
            this.defaultDrop = null;
        }
        else this.defaultDrop = LootItemChancePair.GenerateGuaranteedDropPrincess(defaultDrop.name);
        this.m_name = lootName;
    } 

    public static LootTable GetLootItemOrCreateIfNecessaryPrincess(string lootOrPrefabName)
    {
        if (LootTable.LootTables.ContainsKey(lootOrPrefabName))
        {
            return LootTable.LootTables[lootOrPrefabName];
        }
        LootTable lootTable;

        GameObject prefab = PrefabDB.ObtainPrefabPrincess(lootOrPrefabName);
        lootTable = new LootTable(prefab, lootOrPrefabName);

        LootTable.LootTables.Add(lootOrPrefabName, lootTable);
        return lootTable;
    }

    public string DropPrefab()
    {
        if (!this.IsSingetonLoot)
        {
            foreach (LootItemChancePair lootItemChancePair in this.lootTable)
            {
                if (lootItemChancePair.AttemptDropPrincess())
                {
                    return lootItemChancePair.GetItemPrefabNamePrincess();
                }
            }
        }
        return this.defaultDrop.GetItemPrefabNamePrincess();
    }
}
