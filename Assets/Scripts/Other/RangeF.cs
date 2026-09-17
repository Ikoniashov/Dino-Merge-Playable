using System;
using UnityEngine;
using UnityEngine.Serialization;

public class RangeF
{
	public RangeF(float min, float max)
	{
		this.Min = min;
		this.Max = max;
	}

	public float Span
	{
		get
		{
			return Mathf.Abs(this.Max - this.Min);
		}
	}

	public float Midpoint
	{
		get
		{
			return this.Min + (this.Max - this.Min) / 2f;
		}
	}

	public float Random()
	{
		return GameMgr.Random(this.Min, this.Max);
	}

	public float GetValueAtPercentOfRange(float percent)
	{
		return (this.Max - this.Min) * percent + this.Min;
	}

	public float GetPercentOfRangeAtValue(float value)
	{
		return (value - this.Min) / this.Span;
	}

	public void ClampMinAt(float clamp)
	{
		if (this.Min < clamp)
		{
			this.Min = clamp;
		}
	}

	public bool Contains(float f)
	{
		return f >= this.Min && f <= this.Max;
	}

	public float ClampF(float f)
	{
		if (f < this.Min)
		{
			return this.Min;
		}
		if (f > this.Max)
		{
			return this.Max;
		}
		return f;
	}

	public override string ToString()
	{
		return string.Concat(new object[]
		{
			"RangeF: (",
			this.Min,
			", ",
			this.Max,
			")"
		});
	}

    [FormerlySerializedAs("Min")]
    public float Min;

    [FormerlySerializedAs("Max")]
    public float Max;
}
