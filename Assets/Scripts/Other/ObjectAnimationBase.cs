using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectAnimationBase : MonoBehaviour
{
	public void Start()
	{
		this.CacheOwnerAndDoSetupIfNeeded();
	}

	public void CacheOwnerAndDoSetupIfNeeded()
	{
		if (this.setupComplete)
		{
			return;
		}
		if (this.randomAnimationDelayMax > 0f)
		{
			this.delayTimer = new Timer(0f, this.randomAnimationDelayMax);
		}
		if (this.rotationLoop == iTween.LoopType.loop)
		{
			this.rotationEase = iTween.EaseType.linear;
		}
		this.setupComplete = true;
    }

	public void Update()
	{
		this.CacheOwnerAndDoSetupIfNeeded();
		if (!this.m_enabled)
		{
			return;
		}
		if (this.delayTimer != null && this.delayTimer.Going)
		{
			this.delayTimer.Update(Time.deltaTime);
			return;
		}
		if (!this.animationPlaying)
		{
			this.StartAnim();
		}
	}

	public void StartAnim()
	{
        this.animationPlaying = true;
		this.CacheOwnerAndDoSetupIfNeeded();
		if (this.tweenPositionX != 0f || this.tweenPositionY != 0f)
		{
			float num = 1f;
			if (this.pullOverallMovementScaleFactorFromRoot)
			{
				num = this.gameObject.transform.localScale.x;
			}
			Tween.MoveBy(this.gameObject, "BaseAnimTween", this.animationTimePosition, this.tweenPositionX * num, this.tweenPositionY * num, iTween.LoopType.pingPong, this.positionEase);
		}
		if (this.tweenRotation != 0f)
		{
			Tween.RotateBy(this.gameObject, "BaseAnimTween", this.animationTimeRotation, this.tweenRotation, this.rotationLoop, this.rotationEase);
		}
		if (this.tweenScale != 0f)
		{
			Tween.ScaleBy(this.gameObject, "BaseAnimTween", this.animationTimeScale, this.tweenScale, iTween.LoopType.pingPong, iTween.EaseType.easeInOutQuad);
		}
		if (this.delayTimer != null)
		{
			this.delayTimer.Reset();
		}
    }

	public void StopAnim()
	{
        this.animationPlaying = false;
		this.CacheOwnerAndDoSetupIfNeeded();
		if (this.tweenPositionX != 0f || this.tweenPositionY != 0f)
		{
			iTween.StopByName(this.gameObject, "BaseAnimTween");
		}
		if (this.tweenRotation != 0f || this.tweenScale != 0f)
		{
			iTween.StopByName(this.gameObject, "BaseAnimTween");
		}
		if (this.delayTimer != null)
		{
			this.delayTimer.Reset();
		}
    }

	public void EnableAnim()
	{
        this.m_enabled = true;
    }

	public void DisableAnim()
	{
        if (!this.m_enabled)
		{
			return;
		}
		this.StopAnim();
		this.m_enabled = false;
    }
    [FormerlySerializedAs("m_randomAnimDelayMax")]
    public float randomAnimationDelayMax;

    [FormerlySerializedAs("m_delayTimer")]
    public Timer delayTimer;

    [FormerlySerializedAs("m_animTimePos")]
    public float animationTimePosition;

    [FormerlySerializedAs("m_TweenPosY")]
    public float tweenPositionY;

    [FormerlySerializedAs("m_TweenPosX")]
    public float tweenPositionX;

    [FormerlySerializedAs("m_PosEase")]
    public iTween.EaseType positionEase = iTween.EaseType.easeInOutQuad;

    public iTween.LoopType posLoop = iTween.LoopType.pingPong;

    [FormerlySerializedAs("m_animTimeRot")]
    public float animationTimeRotation;

    [FormerlySerializedAs("m_TweenRot")]
    public float tweenRotation;

    [FormerlySerializedAs("m_RotLoop")]
    public iTween.LoopType rotationLoop = iTween.LoopType.pingPong;

    [FormerlySerializedAs("m_RotEase")]
    public iTween.EaseType rotationEase = iTween.EaseType.easeInOutQuad;

    [FormerlySerializedAs("m_animTimeScale")]
    public float animationTimeScale;

    [FormerlySerializedAs("m_TweenScale")]
    public float tweenScale;

    [FormerlySerializedAs("m_enabled")]
    public bool m_enabled = true;

    [FormerlySerializedAs("m_animationPlaying")]
    public bool animationPlaying;

    [FormerlySerializedAs("m_setupComplete")]
    public bool setupComplete;

    [FormerlySerializedAs("m_pullOverallMovementScaleFactorFromRoot")]
    public bool pullOverallMovementScaleFactorFromRoot;
}
