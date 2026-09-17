using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

public class ChanceBagPair<T>
{
    public ChanceBagPair(T item, float weight)
    {
        this.Item = item;
        this.Weight = weight;
    }

    public T Item;

    public float Weight;
}


public class ChanceBag<T>
{
	public ChanceBag(T item1, float weight1)
	{
		this.Add(item1, weight1);
	}

	public ChanceBag(T item1, float weight1, T item2, float weight2)
	{
		this.Add(item1, weight1);
		this.Add(item2, weight2);
	}

	public ChanceBag(T item1, float weight1, T item2, float weight2, T item3, float weight3)
	{
		this.Add(item1, weight1);
		this.Add(item2, weight2);
		this.Add(item3, weight3);
	}

	public ChanceBag(T item1, float weight1, T item2, float weight2, T item3, float weight3, T item4, float weight4)
	{
		this.Add(item1, weight1);
		this.Add(item2, weight2);
		this.Add(item3, weight3);
		this.Add(item4, weight4);
	}

	public ChanceBag(T item1, float weight1, T item2, float weight2, T item3, float weight3, T item4, float weight4, T item5, float weight5)
	{
		this.Add(item1, weight1);
		this.Add(item2, weight2);
		this.Add(item3, weight3);
		this.Add(item4, weight4);
		this.Add(item5, weight5);
	}

	public ChanceBag(params ChanceBagPair<T>[] pairs)
	{
		foreach (ChanceBagPair<T> chanceBagPair in pairs)
		{
			this.Add(chanceBagPair.Item, chanceBagPair.Weight);
		}
	}

	public int Count
	{
		get
		{
			return this.collectionItems.Count;
		}
	}

	public bool HasElements
	{
		get
		{
			return this.collectionItems.Count > 0;
		}
	}

	public void Add(T item, float weight)
	{
		this.collectionItems.Add(new ChanceBagPair<T>(item, weight));
		this.totalMass += weight;
	}

	public void Remove(ChanceBagPair<T> pair)
	{
		this.collectionItems.Remove(pair);
		this.totalMass -= pair.Weight;
	}

	public T Random()
	{
		ChanceBagPair<T> chanceBagPair = this.RandomPair();
		if (chanceBagPair == null)
		{
			return default(T);
		}
		return chanceBagPair.Item;
	}

	public ChanceBagPair<T> RandomPair()
	{
		float num = GameMgr.Random(0f, this.totalMass);
		float num2 = 0f;
		foreach (ChanceBagPair<T> chanceBagPair in this.collectionItems)
		{
			num2 += chanceBagPair.Weight;
			if (num <= num2)
			{
				return chanceBagPair;
			}
		}
		return null;
	}
    [FormerlySerializedAs("m_items")]
    public List<ChanceBagPair<T>> collectionItems = new List<ChanceBagPair<T>>();
    [FormerlySerializedAs("m_totalWeight")]
    public float totalMass;
}
