using System;
using UnityEngine;
using UnityEngine.Serialization;

public class WatcherForShake : MonoBehaviour
{
	public void Start()
	{
		this.CapturePositionPrincess();
	}

	public void Update()
	{
		this.ShakeAmountThisFrame = new Vector2(this.gameObject.transform.localPosition.x - this.lastFramePos.x, this.gameObject.transform.localPosition.y - this.lastFramePos.y);
		this.CapturePositionPrincess();
	}

	public void CapturePositionPrincess()
	{
		this.lastFramePos = new Vector2(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y);
    }

    public Vector2 lastFramePos;
    public Vector2 ShakeAmountThisFrame = Vector2.zero;
}
