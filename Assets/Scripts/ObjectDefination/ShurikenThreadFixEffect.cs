using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class ShurikenThreadFixEffect : MonoBehaviour
{
	public void OnEnable()
	{
		this.systemEntities = this.GetComponentsInChildren<ParticleSystem>();
		foreach (ParticleSystem particleSystem in this.systemEntities)
		{
			var _temp_val_221 = particleSystem.emission; _temp_val_221.enabled = false;
		}
		this.StartCoroutine("WaitFrame");
	}

	public IEnumerator WaitFrame()
	{
		yield return new WaitForSeconds(0.04f);
		foreach (ParticleSystem particleSystem in this.systemEntities)
		{
			var _temp_val_221 = particleSystem.emission; _temp_val_221.enabled = true;
			particleSystem.Play(true);
		}
		yield break;
	}
    [FormerlySerializedAs("systems")]
    public ParticleSystem[] systemEntities;
}
