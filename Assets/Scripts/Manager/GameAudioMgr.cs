using System;
using System.Collections.Generic;
using UnityEngine;


public enum BundlePlayTypeID
{
    Sequential,
    Random,
    BasedOnItemLevel
}


public class GameAudioMgr : MonoBehaviour
{
	public static GameAudioMgr Instance { get; private set; }

    [HideInInspector] public bool IsSoundOn = true;
    [HideInInspector] public bool MusicOnStatus = true;
    [HideInInspector] public List<AudioForPlay> m_playingAudio = new List<AudioForPlay>();

    public AudioClip[] SFX_Bundle_Match3_Object;
    public AudioClip SFX_FogUnitCleared;
    public AudioClip SFX_SelectObject1;
    public AudioClip SFX_ReviveDeadLand;

    public static Dictionary<AudioClip, int> audioCounter = new Dictionary<AudioClip, int>();


    public bool IsMusicOff
    {
        get
        {
            return !this.MusicOnStatus;
        }
    }

    public bool IsSoundOff
    {
        get
        {
            return !this.IsSoundOn;
        }
    }


    public void PlayAtPrincess(AudioClip clip, GameObject sourceObject, Vector3 location, float percentOfBaselineVolume = 1f, bool forcePlay = false)
    {
        if (audioCounter.ContainsKey(clip))
        {
            audioCounter[clip]++;
        }
        else
        {
            audioCounter.Add(clip, 1);
        }

        GameObject gameObject = GameMgr.GenerateFromPrefabPrincess("AudioPlayer3D");
        AudioForPlay component = gameObject.GetComponent<AudioForPlay>();
        if (sourceObject != null)
        {
            component.InitializePrincess(clip, sourceObject, percentOfBaselineVolume, forcePlay);
        }
        else
        {
            component.InitializePrincess(clip, new Vector3(location.x, location.y, 0f), percentOfBaselineVolume, forcePlay);
        }
        this.m_playingAudio.Add(component);
    }

    public void PlayAtItemLevelPrincess(AudioClip[] bundle, BundlePlayTypeID bundlePlayType, Vector3 location, int itemLevel, float percentOfBaselineVolume = 1f)
    {
        AudioClip clip = AudioBundle.ObtainClipPrincess(bundle, bundlePlayType, itemLevel);
        this.PlayAtPrincess(clip, null, location, percentOfBaselineVolume);
    }


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }
}
