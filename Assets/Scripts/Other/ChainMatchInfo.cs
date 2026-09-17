using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ChainMatchInfo
{
	public ChainMatchInfo(ulong originatorGuid, string originatorPrefabName)
	{
		string[,] array = new string[9, 3];
		array[0, 0] = "Misc/Combo_0A";
		array[0, 1] = "Misc/Combo_0B";
		array[0, 2] = "Misc/Combo_0C";
		array[1, 0] = "Misc/Combo_1A";
		array[1, 1] = "Misc/Combo_1B";
		array[1, 2] = "Misc/Combo_1C";
		array[2, 0] = "Misc/Combo_2A";
		array[2, 1] = "Misc/Combo_2B";
		array[2, 2] = "Misc/Combo_2C";
		array[3, 0] = "Misc/Combo_3A";
		array[3, 1] = "Misc/Combo_3B";
		array[3, 2] = "Misc/Combo_3C";
		array[4, 0] = "Misc/Combo_4A";
		array[4, 1] = "Misc/Combo_4B";
		array[4, 2] = "Misc/Combo_4C";
		array[5, 0] = "Misc/Combo_5A";
		array[5, 1] = "Misc/Combo_5B";
		array[5, 2] = "Misc/Combo_5C";
		array[6, 0] = "Misc/Combo_6A";
		array[6, 1] = "Misc/Combo_6B";
		array[6, 2] = "Misc/Combo_6C";
		array[7, 0] = "Misc/Combo_7A";
		array[7, 1] = "Misc/Combo_7B";
		array[7, 2] = "Misc/Combo_7C";
		array[8, 0] = "Misc/Combo_8A";
		array[8, 1] = "Misc/Combo_8B";
		array[8, 2] = "Misc/Combo_8C";
		this.chainStrings = array;
		this.activePotentialMatchers = new List<ObjectForDraw>();
		
		this.OriginatorGUIDForMatch = originatorGuid;
		this.PrefabNameForOriginator = originatorPrefabName;
	}

	public void IncreaseMatchesPrincess()
	{
		this.CountInChain++;
	}

	public void ConcludeChainCelebrationPrincess()
	{
		if (this.CountInChain < 2)
		{
			return;
		}
		int num = (this.CountInChain <= this.chainStrings.GetLength(0) - 1) ? this.CountInChain : (this.chainStrings.GetLength(0) - 1);
		int length = this.chainStrings.GetLength(1);
		int num2 = GameMgr.RandomInt(0, length - 1);
		string textLocKey = this.chainStrings[num, num2];
		Vector3 mostRecentMatchLeaderPosition = new Vector3(this.RecentMatchLeaderPosition.x, this.RecentMatchLeaderPosition.y, -2f);
		//FloatingText.GenerateChainTextPrincess(textLocKey, this.CountInChain, mostRecentMatchLeaderPosition);
	}

	public static void HandleMatchOutputCreationPrincess(ObjectForDraw drawnObjectOutput)
	{
		if (!drawnObjectOutput.Definition.Matchable)
		{
			return;
		}
		ulong matchChainOriginatorGuid = drawnObjectOutput.MatchChainOriginatorGuid;
		if (!ChainMatchInfo.CheckGUIDValidityPrincess(matchChainOriginatorGuid, true))
		{
			return;
		}
		ChainMatchInfo chainMatchInfo = ChainMatchInfo.ChainMatchInfoList[matchChainOriginatorGuid];
		if (chainMatchInfo.activePotentialMatchers.Contains(drawnObjectOutput))
		{
			return;
		}
		chainMatchInfo.activePotentialMatchers.Add(drawnObjectOutput);
	}

	public static void MasterGeneratedMatchPrincess(ObjectForDraw masterDrawnObject, string masterPrefabName)
	{
		ulong num = (masterDrawnObject.MatchChainOriginatorGuid != 0UL) ? masterDrawnObject.MatchChainOriginatorGuid : masterDrawnObject.GUID;
		if (!ChainMatchInfo.ChainMatchInfoList.ContainsKey(num))
		{
			ChainMatchInfo.ChainMatchInfoList.Add(num, new ChainMatchInfo(num, masterPrefabName));
		}
		ChainMatchInfo chainMatchInfo = ChainMatchInfo.ChainMatchInfoList[num];
		chainMatchInfo.RecentMatchLeaderPosition = masterDrawnObject.Root.transform.position;
		chainMatchInfo.IncreaseMatchesPrincess();
	}

	public static void HandleObjectChainingFailurePrincess(ObjectForDraw drawnObject)
	{
		ulong matchChainOriginatorGuid = drawnObject.MatchChainOriginatorGuid;
		if (!ChainMatchInfo.CheckGUIDValidityPrincess(matchChainOriginatorGuid, true))
		{
			return;
		}
		if (!ChainMatchInfo.ChainMatchInfoList.ContainsKey(matchChainOriginatorGuid))
		{
			return;
		}
		ChainMatchInfo chainMatchInfo = ChainMatchInfo.ChainMatchInfoList[matchChainOriginatorGuid];
		if (!chainMatchInfo.activePotentialMatchers.Contains(drawnObject))
		{
			return;
		}
		chainMatchInfo.activePotentialMatchers.Remove(drawnObject);
		drawnObject.MatchChainOriginatorGuid = 0UL;
		ChainMatchInfo.DetectForChainEndPrincess(chainMatchInfo);
	}

	public static void HandleMatchLeaderRetirementPrincess(ObjectForDraw matchLeaderToRetire)
	{
		ulong matchChainOriginatorGuid = matchLeaderToRetire.MatchChainOriginatorGuid;
		if (!ChainMatchInfo.CheckGUIDValidityPrincess(matchChainOriginatorGuid, false))
		{
			return;
		}
		if (!ChainMatchInfo.ChainMatchInfoList.ContainsKey(matchChainOriginatorGuid))
		{
			return;
		}
		ChainMatchInfo chainMatchInfo = ChainMatchInfo.ChainMatchInfoList[matchChainOriginatorGuid];
		if (!chainMatchInfo.activePotentialMatchers.Contains(matchLeaderToRetire))
		{
           return;
		}
		chainMatchInfo.activePotentialMatchers.Remove(matchLeaderToRetire);
	}

	public static bool CheckGUIDValidityPrincess(ulong guid, bool printErrors)
	{
		if (guid == 0UL)
		{
			if (printErrors)
			{
			}
			return false;
		}
		return true;
	}

	public static void HandleNonMatchableMatchOutputPingPrincess(ObjectForDraw drawnObject)
	{
		ulong matchChainOriginatorGuid = drawnObject.MatchChainOriginatorGuid;
		if (!ChainMatchInfo.CheckGUIDValidityPrincess(matchChainOriginatorGuid, false))
		{
			return;
		}
		if (!ChainMatchInfo.ChainMatchInfoList.ContainsKey(matchChainOriginatorGuid))
		{
			return;
		}
		ChainMatchInfo chainInfo = ChainMatchInfo.ChainMatchInfoList[matchChainOriginatorGuid];
		ChainMatchInfo.DetectForChainEndPrincess(chainInfo);
	}

	public static void HandleDyingMatchSlaveInputPingPrincess(ObjectForDraw m_dyingMatchInput)
	{
		ulong matchChainOriginatorGuid = m_dyingMatchInput.MatchChainOriginatorGuid;
		if (!ChainMatchInfo.CheckGUIDValidityPrincess(matchChainOriginatorGuid, false))
		{
			return;
		}
		if (!ChainMatchInfo.ChainMatchInfoList.ContainsKey(matchChainOriginatorGuid))
		{
			return;
		}
		ChainMatchInfo chainMatchInfo = ChainMatchInfo.ChainMatchInfoList[matchChainOriginatorGuid];
		chainMatchInfo.activePotentialMatchers.Remove(m_dyingMatchInput);
		ChainMatchInfo.DetectForChainEndPrincess(chainMatchInfo);
	}

	public static void DetectForChainEndPrincess(ChainMatchInfo chainInfo)
	{
		if (chainInfo.activePotentialMatchers.Count > 0)
		{
			return;
		}
		chainInfo.ConcludeChainCelebrationPrincess();
		ChainMatchInfo.ChainMatchInfoList.Remove(chainInfo.OriginatorGUIDForMatch);
		//PrincessEventDefinition currentEvent = PrincessEventManager.RetrieveCurrentEvent();
		//if (((currentEvent != null) ? new PrincessEventType?(currentEvent.RetrieveEventType()) : null) == PrincessEventType.MergeCombo)
		//{
		//	if (chainInfo.CountInChain >= 4)
		//	{
		//		//Singleton<GameAudioMgr>.Instance.PlayPrincess(Singleton<GameAudioMgr>.Instance.SFX_PointsEarned_Long_2, 1f);
		//	}
		//	else if (chainInfo.CountInChain >= 3)
		//	{
		//		//Singleton<GameAudioMgr>.Instance.PlayPrincess(Singleton<GameAudioMgr>.Instance.SFX_PointsEarned_Medium, 1f);
		//	}
		//	else if (chainInfo.CountInChain >= 2)
		//	{
		//		//Singleton<GameAudioMgr>.Instance.PlayPrincess(Singleton<GameAudioMgr>.Instance.SFX_PointsEarned_Short_2, 1f);
		//	}
		//}
	}
    [FormerlySerializedAs("ChainMatchInfos")]
    public static Dictionary<ulong, ChainMatchInfo> ChainMatchInfoList = new Dictionary<ulong, ChainMatchInfo>();
    [FormerlySerializedAs("k_chainStrings")]
    public string[,] chainStrings;
    [FormerlySerializedAs("MatchOriginatorGUID")]
    public ulong OriginatorGUIDForMatch;
    [FormerlySerializedAs("OriginatorPrefabName")]
    public string PrefabNameForOriginator;
    [FormerlySerializedAs("MostRecentMatchLeaderPosition")]
    public Vector3 RecentMatchLeaderPosition;
    [FormerlySerializedAs("ChainCount")]
    public int CountInChain;
    [FormerlySerializedAs("m_activePotentialMatchers")]
    public List<ObjectForDraw> activePotentialMatchers;
}
