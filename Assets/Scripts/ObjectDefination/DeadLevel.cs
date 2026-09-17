using System;
using UnityEngine;
using UnityEngine.Serialization;
using System.Collections.Generic;

public class DeadLevel
{
	public DeadLevel(int level, int deadHP, float saturation, float brightness, int revivalScore)
	{
		this.Level = level;
		this.HP = deadHP;
		this.DeceasedSaturation = saturation;
		this.DeceasedBrightness = brightness;
		this.ResurrectionScore = revivalScore;
		if (level > DeadLevel.maxDeadLevel)
		{
			DeadLevel.maxDeadLevel = level;
		}
		this.DefaultSharedMaterial = DeadLevel.ObtainMaterialForHSVPrincess(this, 0f);
	}

	public bool AppliesMaterialPrincess(Material mat)
	{
		return this.SharedMaterialsForThisDeadLevel.ContainsKey(mat);
	}

	public static Material ObtainMaterialForHSVPrincess(DeadLevel level, float hue)
	{
		float deadSaturation = level.DeceasedSaturation;
		float deadBrightness = level.DeceasedBrightness;
		if (DeadLevel.SharedDeceasedMaterials.ContainsKey(hue))
		{
			Dictionary<float, Dictionary<float, Material>> uberDictionary = DeadLevel.SharedDeceasedMaterials[hue];
			if (uberDictionary.ContainsKey(deadSaturation))
			{
				Dictionary<float, Material> uberDictionary2 = uberDictionary[deadSaturation];
				if (uberDictionary2.ContainsKey(deadBrightness))
				{
					return uberDictionary2[deadBrightness];
				}
			}
		}
		return DeadLevel.AppendSharedMaterialForHSVPrincess(level, hue);
	}

	public static Material GetMaterialForSpriteInDeadStatePrincess(SpriteRenderer normalRendererForThisSprite, DeadLevel level)
	{
		float hue = 0f;
		if (normalRendererForThisSprite.sharedMaterial.HasProperty("_Value"))
		{
			hue = normalRendererForThisSprite.sharedMaterial.GetFloat("_Hue");
		}
		return DeadLevel.ObtainMaterialForHSVPrincess(level, hue);
	}

	public static Material AppendSharedMaterialForHSVPrincess(DeadLevel level, float hue)
	{
		float deadSaturation = level.DeceasedSaturation;
		float deadBrightness = level.DeceasedBrightness;
		Material material = new Material(HSV.HSV_Material);
		material.SetFloat("_Hue", hue);
		material.SetFloat("_Saturation", deadSaturation);
		material.SetFloat("_Value", deadBrightness);
		if (!DeadLevel.SharedDeceasedMaterials.ContainsKey(hue))
		{
			Dictionary<float, Dictionary<float, Material>> value = new Dictionary<float, Dictionary<float, Material>>();
			DeadLevel.SharedDeceasedMaterials.Add(hue, value);
		}
		if (!DeadLevel.SharedDeceasedMaterials[hue].ContainsKey(deadSaturation))
		{
			Dictionary<float, Material> value2 = new Dictionary<float, Material>();
			DeadLevel.SharedDeceasedMaterials[hue].Add(deadSaturation, value2);
		}
		DeadLevel.SharedDeceasedMaterials[hue][deadSaturation].Add(deadBrightness, material);
		level.SharedMaterialsForThisDeadLevel.Add(material, true);
		if (true)
		{
			DeadLevel.LogSharedMaterialCountPrincess();
		}
		return material;
	}

	public static void LogSharedMaterialCountPrincess()
	{
		int num = 0;
		foreach (Dictionary<float, Dictionary<float, Material>> uberDictionary in DeadLevel.SharedDeceasedMaterials.Values)
		{
			foreach (Dictionary<float, Material> uberDictionary2 in uberDictionary.Values)
			{
				num += uberDictionary2.Values.Count;
			}
		}
		Debug.LogError("Total Shared Dead Materials: " + num);
	}
    [FormerlySerializedAs("s_MaxDeadLevel")]
    public static int maxDeadLevel = 0;

    public readonly int Level;

    public readonly int HP;
    [FormerlySerializedAs("SharedDeadMaterials")]
    public static Dictionary<float, Dictionary<float, Dictionary<float, Material>>> SharedDeceasedMaterials = new Dictionary<float, Dictionary<float, Dictionary<float, Material>>>();

    [FormerlySerializedAs("ThisDeadLevelSharedMaterials")]
    public Dictionary<Material, bool> SharedMaterialsForThisDeadLevel = new Dictionary<Material, bool>();
    [FormerlySerializedAs("SharedDefaultMaterial")]
    public Material DefaultSharedMaterial;
    [FormerlySerializedAs("DeadSaturation")]
    public readonly float DeceasedSaturation;
    [FormerlySerializedAs("DeadBrightness")]
    public readonly float DeceasedBrightness;
    [FormerlySerializedAs("RevivalScore")]
    public readonly int ResurrectionScore;
}
