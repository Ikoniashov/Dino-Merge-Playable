using System;
using UnityEngine.Serialization;
using UnityEngine;

public class Timer
{
    public float timeLeft;
    public float originalTime;
    public RangeF timeRange;


    public float PercentElapsed
    {
        get
        {
            return (this.originalTime - this.timeLeft) / this.originalTime;
        }
    }

    public bool Done
    {
        get
        {
            return this.timeLeft <= 0f;
        }
    }

    public float PercentLeft
    {
        get
        {
            return this.timeLeft / this.originalTime;
        }
    }

    public bool Going
    {
        get
        {
            return this.timeLeft > 0f;
        }
    }

    public Timer() : this(1f)
    {

    }

    public Timer(float min, float max) : this(new RangeF(min, max))
    {

    }

    public Timer(RangeF lifeRange)
    {
        this.timeRange = lifeRange;
        this.timeLeft = lifeRange.Random();
        this.originalTime = this.timeLeft;
    }

    public Timer(float seconds)
    {
        this.timeLeft = seconds;
        this.originalTime = seconds;
    }

    public void Set(float newLifetime)
    {
        this.timeLeft = newLifetime;
        this.originalTime = this.timeLeft;
    }

    public void Set(RangeF newLifetimeRange)
    {
        this.timeLeft = newLifetimeRange.Random();
        this.originalTime = this.timeLeft;
    }

    public void Reset()
    {
        if (this.timeRange != null)
        {
            this.timeLeft = this.timeRange.Random();
            this.originalTime = this.timeLeft;
        }
        else
        {
            this.timeLeft = this.originalTime;
        }
    }

    public void TimeTravelTo(float updatedTime)
    {
        this.timeLeft = updatedTime;
    }


    public void Update(float deltaTime)
    {
        this.timeLeft -= deltaTime;
    }
}
