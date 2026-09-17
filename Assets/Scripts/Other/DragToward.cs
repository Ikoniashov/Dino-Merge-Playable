using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class DragToward : MonoBehaviour
{
	public bool MomentumActive
	{
		[CompilerGenerated]
		get
		{
			return this.momentumActivated;
		}
	}

	public void Start()
	{
		this.m_drawnObject = this.GetComponent<ObjectForDraw>();
		if (this.m_drawnObject == null)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	public void Update()
	{
		if (this.MomentumActive)
		{
			this.remainingVelocity *= this.remainingDragTime.PercentLeft * 0.9f;
			this.Displace(this.remainingVelocity);
			this.remainingDragTime.Update(Time.deltaTime);
			if (this.remainingVelocity.magnitude <= 0.0025f)
			{
				this.EnableMomentumEffectPrincess(false);
			}
		}
	}

	public void OnDrag(Vector2 dragDelta)
	{
		this.EnableMomentumEffectPrincess(false);
		this.displacementHistory.Enqueue(dragDelta);
		if (this.displacementHistory.Count > 3)
		{
			this.displacementHistory.Dequeue();
		}
    }

	public void DragReleased()
	{
        this.EnableMomentumEffectPrincess(true);
		this.remainingDragTime.Reset();
		this.remainingVelocity = Vector3.zero;
		foreach (Vector2 v in this.displacementHistory)
		{
			Vector3 b = v;
			this.remainingVelocity += b;
		}
		if (this.displacementHistory.Count > 0)
		{
			this.remainingVelocity /= (float)this.displacementHistory.Count;
		}
    }

	public void Displace(Vector2 moveBy)
	{
        float x = this.m_drawnObject.X + moveBy.x;
		float y = this.m_drawnObject.Y + moveBy.y;
		if (!this.m_drawnObject.Definition.CanDropFarOutOfBounds && GridCellsMgr.Instance.WithinWideWorldSpaceBoundsPrincess(new Vector3(x, y, this.m_drawnObject.Z)))
		{
			this.EnableMomentumEffectPrincess(false);
			this.displacementHistory.Clear();
			return;
		}
		this.m_drawnObject.DefineRootPositionPrincess(x, y);
    }

	public void EnableMomentumEffectPrincess(bool value)
	{
        this.momentumActivated = value;
		//if (PrincessMergeElfConfig.UPDATE_OPTIMISATION_ENABLED)
		//{
		//	this.enabled = value;
		//}
    }
    [FormerlySerializedAs("m_residualDragTime")]
    public Timer remainingDragTime = new Timer(2f);
    [FormerlySerializedAs("k_residualVelocityDieoff")]
    public const float residualVelocityDieoff = 0.9f;
    [FormerlySerializedAs("m_dragDisplacementHistory")]
    public Queue<Vector2> displacementHistory = new Queue<Vector2>();
    [FormerlySerializedAs("k_dragDisplacementHistorySize")]
    public const int displacementHistorySize = 3;
    [FormerlySerializedAs("m_residualVelocity")]
    public Vector3 remainingVelocity;
    [FormerlySerializedAs("k_residualVelocityMagnitudeTolerance")]
    public const float velocityMagnitudeTolerance = 0.0025f;
    [FormerlySerializedAs("m_drawnObject")]
    public ObjectForDraw m_drawnObject;
    [FormerlySerializedAs("_momentumActive")]
    public bool momentumActivated;
}
