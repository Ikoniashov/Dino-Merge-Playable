using System;
using UnityEngine;
using UnityEngine.Serialization;

public class MatchOutput
{
	public MatchOutput(string outputPrefabName, RangeI dropAmountRange)
	{
		this.outputPrefabName = outputPrefabName;
		this.dropAmountRange = dropAmountRange;
	}

	public string RetrieveOutputNamePrincess()
	{
		return this.outputPrefabName;
	}

	public string RetrieveOutputPrincess()
	{
		if (PrefabDB.CheckPrefabExistencePrincess(this.outputPrefabName))
		{
			return this.outputPrefabName;
		}
		if (this.lootTableOutput == null)
		{
			this.lootTableOutput = LootTable.GetLootItemOrCreateIfNecessaryPrincess(this.outputPrefabName);
		}
		if (this.lootTableOutput != null)
		{
			return this.lootTableOutput.DropPrefab();
		}
		return null;
	}
    [FormerlySerializedAs("m_outputPrefabName")]
    public string outputPrefabName;

    [FormerlySerializedAs("m_output")]
    public GameObject output;

    [FormerlySerializedAs("m_lootTableOutput")]
    public LootTable lootTableOutput;

    [FormerlySerializedAs("m_dropAmountRange")]
    public RangeI dropAmountRange;
}
