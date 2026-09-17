using System;
using UnityEngine;
using UnityEngine.Serialization;

public enum AudioStateID
{
    NotStarted,
    PlayingNormally,
    Paused,
    FadingIn,
    FadingOut,
    Finished
}

public class AudioForPlay : MonoBehaviour
{
    public GameObject attachedTo;
    public AudioSource audioSource;
    public static float k_MASTER_BASELINE_VOLUME;
    public int clipLoopID = -1;
    public bool autoKillIfParentDies;
    public AudioStateID audioState;
    public AudioClip audioClip;
    public bool forcePlay = false;

    public void InitializeSharedPrincess(AudioClip clip, bool loop, int clipLoopID, bool autoKillIfParentDies, float percentOfBaselineVolume = 1f)
    {
        this.audioClip = clip;
        this.audioSource.volume = AudioForPlay.k_MASTER_BASELINE_VOLUME * percentOfBaselineVolume;
        this.audioSource.PlayOneShot(clip);
        if (loop)
        {
            this.clipLoopID = clipLoopID;
            this.autoKillIfParentDies = autoKillIfParentDies;
            this.audioSource.loop = true;
        }
        else
        {
            this.Invoke("Invokable_AudioDone", clip.length);
        }
        this.audioState = AudioStateID.PlayingNormally;
    }

    public void InitializeSharedPrincess(AudioClip clip, float percentOfBaselineVolume = 1f)
    {
        this.InitializeSharedPrincess(clip, false, -1, false, percentOfBaselineVolume);
    }

    public AudioForPlay InitializePrincess(AudioClip clip, GameObject sourceObject, float percentOfBaselineVolume = 1f, bool forcePlay = false)
    {
        this.transform.parent = sourceObject.transform;
        this.attachedTo = sourceObject;
        this.InitializeSharedPrincess(clip, percentOfBaselineVolume);
        this.forcePlay = forcePlay;
        return this;
    }

    public AudioForPlay InitializePrincess(AudioClip clip, Vector3 location, float percentOfBaselineVolume = 1f, bool forcePlay = false)
    {
        this.forcePlay = forcePlay;
        this.transform.position = location;
        this.InitializeSharedPrincess(clip, percentOfBaselineVolume);
        return this;
    }

    public void Invokable_AudioDone()
    {
        var temp = this.GetComponent<AudioSource>();
        if (temp == null) Destroy(this.gameObject);
        else if(temp.loop == false) Destroy(this.gameObject);
    }


    public void Awake()
    {
        AudioForPlay.k_MASTER_BASELINE_VOLUME = this.audioSource.volume;
       
    }

    private void Start()
    {
        if(!forcePlay)
        {
            if (GameAudioMgr.audioCounter.ContainsKey(this.audioClip))
            {
                if (GameAudioMgr.audioCounter[this.audioClip] > 3) Destroy(this.gameObject);
            }
            else
            {
                GameAudioMgr.audioCounter.Add(this.audioClip, 1);
            }
        }       
    }

    private void OnDestroy()
    {
        if (GameAudioMgr.audioCounter.ContainsKey(this.audioClip))
        {
            GameAudioMgr.audioCounter[this.audioClip]--;
        }
    }
}
