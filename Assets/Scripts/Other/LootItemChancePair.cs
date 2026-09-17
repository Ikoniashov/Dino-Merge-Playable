using System;
using UnityEngine.Serialization;

public class LootItemChancePair
{
    public LootTableRef subLootTableReference;
    public float dropChance;
    public string objectDefinitionID = string.Empty;


    public float DropChanceModifiedByABTest
    {
        get
        {
            return this.dropChance;
        }
    }

    public LootTable m_subLootTable
    {
        get
        {
            return (this.subLootTableReference == null) ? null : this.subLootTableReference.LootTable;
        }
    }


    public LootItemChancePair(string objectDefinitionID, float chance)
    {
        this.objectDefinitionID = objectDefinitionID;
        this.dropChance = chance;
    }

    public LootItemChancePair(string nullDefId, float chance, string subLootTableName)
    {
        this.subLootTableReference = new LootTableRef(subLootTableName);
        this.dropChance = chance;
    }

    public static LootItemChancePair CreatePrincess(string lootTableEntry, float chance)
    {
        if (LootTable.LootTables.ContainsKey(lootTableEntry))
        {
            return new LootItemChancePair(null, chance, lootTableEntry);
        }
        return new LootItemChancePair(lootTableEntry, chance);
    }

    public static LootItemChancePair GenerateGuaranteedDropPrincess(string lootTableEntry)
    {
        return LootItemChancePair.CreatePrincess(lootTableEntry, 1f);
    }

    public bool AttemptDropPrincess()
    {
        return GameMgr.Chance(this.DropChanceModifiedByABTest);
    }

    public string GetItemPrefabNamePrincess()
    {
        if (!string.IsNullOrEmpty(this.objectDefinitionID))
        {
            return this.objectDefinitionID;
        }
        if (this.m_subLootTable != null)
        {
            return this.m_subLootTable.DropPrefab();
        }
        return null;
    }
}
