using System;
using UnityEngine;

public enum HSVChannelID
{
    H,
    S,
    V
}

public class HSV
{
	public HSV(float hue, float saturation, float brightness)
	{
		this.H = hue;
		this.S = saturation;
		this.V = brightness;
	}

	public HSV(Vector3 hsv) : this(hsv.x, hsv.y, hsv.z)
	{
	}

	public HSV()
	{
	}

	public static Material HSV_Material
	{
		get
		{
			if (HSV.s_HSV_Material == null)
			{
				HSV.s_HSV_Material = (Resources.Load(HSV.k_HSV_MaterialName, typeof(Material)) as Material);
			}
			return HSV.s_HSV_Material;
		}
	}

	public static HSV GetLerpSnapshot(HSV start, HSV end, float lerpTimeElapsed, float totalLerpTime)
	{
		return HSV.GetLerpSnapshot(start, end, lerpTimeElapsed / totalLerpTime);
	}

	public static HSV GetLerpSnapshot(HSV start, HSV end, float percentComplete)
	{
		float hue = (end.H - start.H) * percentComplete + start.H;
		float saturation = (end.S - start.S) * percentComplete + start.S;
		float brightness = (end.V - start.V) * percentComplete + start.V;
		return new HSV(hue, saturation, brightness);
	}

	public static HSV ExtractFrom(GameObject obj, bool errorIfNotHSVMaterial = false)
	{
		SpriteRenderer[] componentsInChildren = obj.GetComponentsInChildren<SpriteRenderer>(true);
		if (componentsInChildren.Length == 0)
		{
			return null;
		}
		if (componentsInChildren[0] == null)
		{
			Debug.LogError(string.Format("HSV::ExtractFrom() has a spriteRenderer array that isn't empty, but spriteRenderers[0] is null on obj {0}.", obj.name));
			return null;
		}
		if (componentsInChildren[0].sharedMaterial == null)
		{
			Debug.LogError(string.Format("HSV::ExtractFrom() spriteRenderers[0].sharedMaterial is null on obj {0}.", obj.name));
			return null;
		}
		return HSV.ExtractFrom(componentsInChildren[0].sharedMaterial, false);
	}

	public static HSV ExtractFrom(Material material, bool errorIfNotHSVMaterial = false)
	{
		float hue = HSV.ExtractFrom(material, HSVChannelID.H, errorIfNotHSVMaterial);
		float saturation = HSV.ExtractFrom(material, HSVChannelID.S, errorIfNotHSVMaterial);
		float brightness = HSV.ExtractFrom(material, HSVChannelID.V, errorIfNotHSVMaterial);
		return new HSV(hue, saturation, brightness);
	}

	public static float ExtractFrom(Material material, HSVChannelID channel, bool errorIfNotHSVMaterial = false)
	{
		string materialPropertyName = HSV.GetMaterialPropertyName(channel);
		if (material.HasProperty(materialPropertyName))
		{
			return material.GetFloat(materialPropertyName);
		}
		if (errorIfNotHSVMaterial)
		{
			Debug.LogError(string.Concat(new object[]
			{
				"Trying to extract HSV values from an HSV material, but it's not actually an HSV material. Material: ",
				material,
				". Property: ",
				materialPropertyName,
				"."
			}));
		}
		return HSV.DefaultValue(channel);
	}

	public static float DefaultValue(HSVChannelID channel)
	{
		return (channel != HSVChannelID.H) ? 1f : 0f;
	}

	public static string GetMaterialPropertyName(HSVChannelID channel)
	{
		if (channel == HSVChannelID.H)
		{
			return "_Hue";
		}
		if (channel == HSVChannelID.S)
		{
			return "_Saturation";
		}
		return "_Value";
	}

	public void ApplyTo(Material material)
	{
		material.SetFloat("_Hue", this.H);
		material.SetFloat("_Saturation", this.S);
		material.SetFloat("_Value", this.V);
	}

	public const string k_PROPERTYNAME_HSV_HUE = "_Hue";

	public const string k_PROPERTYNAME_HSV_SATURATION = "_Saturation";

	public const string k_PROPERTYNAME_HSV_VALUE = "_Value";

	public static Material s_HSV_Material = null;

	public static string k_HSV_MaterialName = "Resource_Material_HSV";

	public const float V_WHITE = 10f;

	public const float V_BLACKOUT = -1f;

	public static HSV BrightWhite = new HSV(0f, 1f, 10f);

	public static HSV Blackout = new HSV(0f, 0f, -1f);

	public float H;

	public float S = 1f;

	public float V = 1f;
}
