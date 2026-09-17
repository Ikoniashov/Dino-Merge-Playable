using System;
using UnityEngine;

public class GameCompanionForShadow : MonoBehaviour
{
	public void Start()
	{
	}

	public void DisableShadowPrincess()
	{
		this.gameObject.SetActive(false);
	}

	public void EnableShadowPrincess()
	{
		this.gameObject.SetActive(true);
	}
}
