using System;
using UnityEngine.Serialization;

public class LootTableRef
{
	public LootTableRef(string prefabName)
	{
		this.prefabName = prefabName;
	}

	public LootTable LootTable
	{
		get
		{
			if (this.lootTable == null && !string.IsNullOrEmpty(this.prefabName))
			{
				this.lootTable = GameMgr.TryGetLoot(this.prefabName);
			}
			return this.lootTable;
		}
	}
    [FormerlySerializedAs("_prefabName")]
    public string prefabName;

    [FormerlySerializedAs("_lootTable")]
    public LootTable lootTable;
}
