using System;
using UnityEngine;
using UnityEngine.Serialization;

public class AutomateForKillParticle : MonoBehaviour
{
	public void Start()
	{
		this.particleSystems = this.GetComponentsInChildren<ParticleSystem>(true);
	}

	public void Update()
	{
		if (this.removeImmediatelyInUI && !this.checkedForInUIYet)
		{
			this.CleanupIfInUIPrincess();
		}
		if (this.particleSystems != null && !this.ExistAliveParticleSystemsPrincess())
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
		else if (this.timeoutEnabled && this.timeToLive < 0f)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
		else if (this.timeoutEnabled)
		{
			this.timeToLive -= Time.deltaTime;
		}
	}

	public void CleanupIfInUIPrincess()
	{
		this.checkedForInUIYet = true;
		Transform transform = this.transform;
		while (transform.parent != null)
		{
			transform = transform.parent;
		}
    }

	public bool ExistAliveParticleSystemsPrincess()
	{
        foreach (ParticleSystem particleSystem in this.particleSystems)
		{
			if (particleSystem != null && particleSystem.IsAlive())
			{
				return true;
			}
		}
        return false;
	}
    [FormerlySerializedAs("m_useTimeout")]
    public bool timeoutEnabled;
    [FormerlySerializedAs("m_timeToLive")]
    public float timeToLive = 10f;
    [FormerlySerializedAs("m_RemoveImmediatelyInUI")]
    public bool removeImmediatelyInUI;
    [FormerlySerializedAs("m_particleSystems")]
    public ParticleSystem[] particleSystems;
    [FormerlySerializedAs("m_checkedForInUIYet")]
    public bool checkedForInUIYet;
}
