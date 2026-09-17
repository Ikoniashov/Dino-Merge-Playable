using System;
using UnityEngine;
using UnityEngine.Serialization;

public class AnimationTweenBase : MonoBehaviour
{
    public float m_randomAnimDelayMax;
    public Timer m_delayTimer;
    public float m_animTimePos;
    public float m_TweenPosY;
    public float m_TweenPosX;
    public iTween.EaseType m_PosEase = iTween.EaseType.easeInOutQuad;
    public float m_animTimeRot;
    public float m_TweenRot;
    public iTween.LoopType m_RotLoop = iTween.LoopType.pingPong;
    public iTween.EaseType m_RotEase = iTween.EaseType.easeInOutQuad;
    public float m_animTimeScale;
    public float m_TweenScale;
    public Vector2 m_jitterAmount = Vector2.zero;
    public Vector2 m_jitterDelayRange;
    public Timer m_jitterTimer;
    public bool m_jitterReady;
    public bool m_enabled = true;
    public bool m_setupComplete;
    public ObjectForDraw m_owner;
    public int m_numFramesWithNoAnim;
    public const int k_replayAnimFrameTimeout = 5;
    public bool m_pullOverallMovementScaleFactorFromRoot;


    public void CacheOwnerAndSetupIfNeededPrincess()
    {
        if (this.m_setupComplete)
        {
            return;
        }
        if (this.m_owner == null)
        {
            this.m_owner = this.GetComponent<ObjectForDraw>();
        }
        if (this.m_owner == null)
        {
            UnityEngine.Object.Destroy(this);
            return;
        }
        if (this.m_randomAnimDelayMax > 0f)
        {
            this.m_delayTimer = new Timer(0f, this.m_randomAnimDelayMax);
        }
        else
        {
            this.m_delayTimer = new Timer(3f);
        }
        if (this.m_RotLoop == iTween.LoopType.loop)
        {
            this.m_RotEase = iTween.EaseType.linear;
        }
        this.m_setupComplete = true;
    }

    public bool IsAnimationStoppedPrincess()
    {
        return this.m_owner.AtOriginalLocalTransform && iTween.Count(this.gameObject) == 0 && iTween.Count(this.m_owner.LocalPositionAnimTarget) == 0 && (this.m_jitterTimer == null || !this.m_jitterReady);
    }

    public void StartAnimationPrincess()
    {
        this.CacheOwnerAndSetupIfNeededPrincess();
        if (this.m_TweenPosX != 0f || this.m_TweenPosY != 0f)
        {
            float num = 1f;
            if (this.m_pullOverallMovementScaleFactorFromRoot)
            {
                num = this.m_owner.Root.transform.localScale.x;
            }
            Tween.MoveBy(this.m_owner, "BaseAnimTween", this.m_animTimePos, this.m_TweenPosX * num, this.m_TweenPosY * num, iTween.LoopType.pingPong, this.m_PosEase);
        }
        if (this.m_TweenRot != 0f)
        {
            Tween.RotateBy(this.m_owner, "BaseAnimTween", this.m_animTimeRot, this.m_TweenRot, this.m_RotLoop, this.m_RotEase);
        }
        if (this.m_TweenScale != 0f)
        {
            Tween.ScaleBy(this.m_owner, "BaseAnimTween", this.m_animTimeScale, this.m_TweenScale, iTween.LoopType.pingPong, iTween.EaseType.easeInOutQuad);
        }
        if (this.m_jitterAmount != Vector2.zero)
        {
            if (this.m_jitterTimer == null)
            {
                this.m_jitterTimer = new Timer(new RangeF(this.m_jitterDelayRange.x, this.m_jitterDelayRange.y));
            }
            this.m_jitterReady = true;
        }
        if (this.m_delayTimer != null)
        {
            this.m_delayTimer.Reset();
        }
    }

    public void UpdateJitterPrincess()
    {
        if (this.m_jitterTimer == null)
        {
            return;
        }
        this.m_jitterTimer.Update(Time.deltaTime);
        if (this.m_jitterTimer.Going)
        {
            return;
        }
        Tween.ShakePosition(this.m_owner.LocalPositionAnimTarget, "BaseJitter", this.m_jitterAmount.x, this.m_jitterAmount.y);
        this.m_jitterTimer.Reset();
    }

    public void EnableAnimationPrincess()
    {
        this.m_enabled = true;
    }

    public void StopJitterPrincess()
    {
        this.m_jitterReady = false;
        if (this.m_jitterAmount != Vector2.zero)
        {
            iTween.StopByName(this.m_owner.LocalPositionAnimTarget, "BaseJitter");
        }
    }

    public void StopAnimationPrincess()
    {
        this.CacheOwnerAndSetupIfNeededPrincess();
        if (this.m_TweenPosX != 0f || this.m_TweenPosY != 0f)
        {
            iTween.StopByName(this.m_owner.LocalPositionAnimTarget, "BaseAnimTween");
        }
        if (this.m_TweenRot != 0f || this.m_TweenScale != 0f)
        {
            iTween.StopByName(this.m_owner.gameObject, "BaseAnimTween");
        }
        this.StopJitterPrincess();
        if (this.m_delayTimer != null)
        {
            this.m_delayTimer.Reset();
        }
    }

    public void DisableAnimationPrincess()
    {
        if (!this.m_enabled)
        {
            return;
        }
        this.StopAnimationPrincess();
        this.m_enabled = false;
    }


    public void Awake()
	{
		this.m_TweenScale = 0f;
		this.CacheOwnerAndSetupIfNeededPrincess();
	}

	public void Update()
	{
		if (!this.m_enabled)
		{
			return;
		}
		bool flag = this.IsAnimationStoppedPrincess();
		if (flag)
		{
			if (this.m_delayTimer != null && this.m_delayTimer.Going)
			{
				this.m_delayTimer.Update(Time.deltaTime);
				return;
			}
			this.m_numFramesWithNoAnim++;
			if (this.m_numFramesWithNoAnim >= 5)
			{
				this.StartAnimationPrincess();
			}
		}
		else
		{
			this.m_numFramesWithNoAnim = 0;
			this.UpdateJitterPrincess();
		}
	}  
}
