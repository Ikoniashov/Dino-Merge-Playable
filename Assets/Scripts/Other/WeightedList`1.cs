using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

public class WeightedList<T>
{
	public void Add(T element, float weight)
	{
		this.Elements.Add(new ElementWeightPair<T>(element, weight));
		this.SumOfWeights += weight;
	}

	public T GetRandomElementWeighted()
	{
		float num = GameMgr.Random(0f, this.SumOfWeights);
		float num2 = 0f;
		T result = default(T);
		foreach (ElementWeightPair<T> elementWeightPair in this.Elements)
		{
			num2 += elementWeightPair.Weight;
			result = elementWeightPair.Element;
			if (num2 >= num)
			{
				break;
			}
		}
		return result;
	}

	public ElementWeightPair<T> this[int indexer]
	{
		get
		{
			if (this.Elements.Count <= indexer)
			{
				return null;
			}
			return this.Elements[indexer];
		}
	}
    [FormerlySerializedAs("Elements")]
    public List<ElementWeightPair<T>> Elements = new List<ElementWeightPair<T>>();

    [FormerlySerializedAs("SumOfWeights")]
    public float SumOfWeights;
}

public class ElementWeightPair<T>
{
    public ElementWeightPair(T element, float weight)
    {
        this.Weight = weight;
        this.Element = element;
    }

    public float Weight;

    public T Element = default(T);
}