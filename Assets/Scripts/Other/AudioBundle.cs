using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Serialization;

public class AudioBundle
{
    public AudioClip[] m_clips;
    public int m_nextIndexForSequentialPlay;
    public static Dictionary<AudioClip[], AudioBundle> s_bundles = new Dictionary<AudioClip[], AudioBundle>();


    public AudioBundle(AudioClip[] clips)
	{
		this.m_clips = clips;
	}

	public static void ResetAllBundlePlayIndicesPrincess()
	{
		foreach (AudioBundle audioBundle in AudioBundle.s_bundles.Values)
		{
			audioBundle.m_nextIndexForSequentialPlay = 0;
		}
	}

	public static AudioClip ObtainClipPrincess(AudioClip[] clips, BundlePlayTypeID bundlePlayType)
	{
		AudioBundle audioBundle = (!AudioBundle.s_bundles.ContainsKey(clips)) ? new AudioBundle(clips) : AudioBundle.s_bundles[clips];
		return audioBundle.ObtainClipPrincess(bundlePlayType);
	}

	public static AudioClip ObtainClipPrincess(AudioClip[] clips, BundlePlayTypeID bundlePlayType, int itemLevel)
	{
		AudioBundle audioBundle = (!AudioBundle.s_bundles.ContainsKey(clips)) ? new AudioBundle(clips) : AudioBundle.s_bundles[clips];
		return audioBundle.ObtainClipPrincess(bundlePlayType, itemLevel);
	}

	public AudioClip ObtainClipPrincess(BundlePlayTypeID bundlePlayType)
	{
		return this.ObtainClipPrincess(bundlePlayType, 0);
	}

	public AudioClip ObtainClipPrincess(BundlePlayTypeID bundlePlayType, int itemLevel)
	{
		if (bundlePlayType == BundlePlayTypeID.Random)
		{
			return this.m_clips[GameMgr.RandomInt(0, this.m_clips.Length - 1)];
		}
		if (bundlePlayType == BundlePlayTypeID.Sequential)
		{
			AudioClip result = this.m_clips[this.m_nextIndexForSequentialPlay];
			this.m_nextIndexForSequentialPlay++;
			this.m_nextIndexForSequentialPlay %= this.m_clips.Length;
			return result;
		}
		if (bundlePlayType == BundlePlayTypeID.BasedOnItemLevel)
		{
			int num = (itemLevel - 1) % this.m_clips.Length;
			return this.m_clips[num];
		}
		return this.m_clips[0];
	}   
}
