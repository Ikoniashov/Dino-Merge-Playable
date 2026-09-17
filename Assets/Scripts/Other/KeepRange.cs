using System;
using UnityEngine;
using UnityEngine.Serialization;

public class KeepRange : MonoBehaviour
{
    public static KeepRange Instance { get; private set; }

    public Vector3 originalScale;

    
	public void LateUpdate_KeepBgRange()
	{
		this.transform.localScale = this.originalScale * CameraControl.Instance.ZoomCounteractionScale;
	}


    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void Start()
    {
        this.originalScale = this.transform.localScale;
    }
}
