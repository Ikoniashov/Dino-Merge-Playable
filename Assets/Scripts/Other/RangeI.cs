using System;
using UnityEngine.Serialization;

public class RangeI
{
	public RangeI(int min, int max)
	{
		this.Min = min;
		this.Max = max;
	}

	public float Midpoint
	{
		get
		{
			return (float)this.Min + ((float)this.Max - (float)this.Min) / 2f;
		}
	}

	public int GetValueAtPercentOfRange(float percent)
	{
		float num = (float)(this.Max - this.Min);
		int num2 = (int)(num * percent);
		return num2 + this.Min;
	}

	public bool Contains(int val)
	{
		return val >= this.Min && val < this.Max;
	}

	public int Random()
	{
		return GameMgr.RandomInt(this.Min, this.Max);
	}

	public override string ToString()
	{
		return string.Concat(new object[]
		{
			"RangeI: [",
			this.Min,
			", ",
			this.Max,
			"]"
		});
	}

	public string ToReadableString()
	{
		return (this.Min != this.Max) ? (this.Min + "-" + this.Max) : this.Min.ToString();
	}
    [FormerlySerializedAs("Min")]
    public int Min;

    [FormerlySerializedAs("Max")]
    public int Max;
}
