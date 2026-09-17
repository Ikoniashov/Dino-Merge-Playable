using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Blinkflash : MonoBehaviour
{
	public void Start()
	{
		this.renderer = this.GetComponent<SpriteRenderer>();
		if (this.renderer == null)
		{
			UnityEngine.Object.Destroy(this);
            return;
		}
		this.delayBeforeBlink = new Timer(Blinkflash.longBlinkTime);
	}

	public void AttemptFirstUnblinkPrincess()
	{
		this.updatesToFirstUnblink--;
		if (this.updatesToFirstUnblink > 0)
		{
			return;
		}
		this.firstUnblinkHappened = true;
		this.Unblink();
    }

	public void Update()
	{
        if (this.transform.parent.GetComponent<ObjectForDraw>() == null) this.gameObject.SetActive(false);
		if (!this.firstUnblinkHappened)
		{
			this.AttemptFirstUnblinkPrincess();
			return;
		}
		this.delayBeforeBlink.Update(Time.deltaTime);
		if (this.delayBeforeBlink.Going)
		{
			return;
		}
		if (this.isBlinking)
		{
			this.durationOfBlink.Update(Time.deltaTime);
			if (this.durationOfBlink.Going)
			{
				return;
			}
			this.Unblink();
		}
		else
		{
			this.Blink();
		}
	}

	public void Blink()
	{
		if (this.renderer != null)
		{
			this.renderer.enabled = true;
		}
		this.isBlinking = true;
    }

	public void Unblink()
	{
        if (this.renderer != null)
		{
			this.renderer.enabled = false;
		}
		this.durationOfBlink.Reset();
		this.delayBeforeBlink.Set(Blinkflash.blinkChances.Random());
		this.isBlinking = false;
    }
    [FormerlySerializedAs("k_blinkTimeShort")]
    public static RangeF shortBlinkTime = new RangeF(0.1f, 0.2f);
    [FormerlySerializedAs("k_blinkTimeMedium")]
    public static RangeF mediumBlinkTime = new RangeF(1f, 3f);// new RangeF(3f, 5f);
    [FormerlySerializedAs("k_blinkTimeLong")]
    public static RangeF longBlinkTime = new RangeF(4f, 6f);//new RangeF(10f, 12f);
    [FormerlySerializedAs("k_blinkChances")]
    public static ChanceBag<RangeF> blinkChances = new ChanceBag<RangeF>(Blinkflash.shortBlinkTime, 0.3f, Blinkflash.mediumBlinkTime, 0.5f, Blinkflash.longBlinkTime, 0.7f);
    [FormerlySerializedAs("m_nguiSprite")]
    //public UISprite nguiSprite;
    [FormerlySerializedAs("m_renderer")]
    public SpriteRenderer renderer;
    [FormerlySerializedAs("m_blinkDelay")]
    public Timer delayBeforeBlink;
    [FormerlySerializedAs("m_blinkDuration")]
    public Timer durationOfBlink = new Timer(0.2f);
    [FormerlySerializedAs("m_blinking")]
    public bool isBlinking;
    [FormerlySerializedAs("m_updatesToFirstUnblink")]
    public int updatesToFirstUnblink = 3;
    [FormerlySerializedAs("m_firstUnblinkHappened")]
    public bool firstUnblinkHappened;
}
