using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    #region Fields

    public static AudioSystem Instance { get; private set; }

    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource soundFXAudioSource1;
    [SerializeField] private AudioSource soundFXAudioSource2;

    [SerializeField] private AudioClip m_mergeSoundClip;
    [SerializeField] private AudioClip m_pairMarryClip;
    [SerializeField] private AudioClip m_fogDissolveClip;
    [SerializeField] private AudioClip m_bubbleClip;
    [SerializeField] private AudioClip m_starSoundClip;

    #endregion

    #region UnityEvents

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    #endregion

    #region Public

    public void PlayMergeSound()
    {
        PlaySound(m_mergeSoundClip);
    }

    public void PlayMarrySound()
    {
        PlaySound(m_pairMarryClip);
    }

    public void PlayFogDissolveSound()
    {
        PlaySound(m_fogDissolveClip);
    }

    public void PlayOpenEggBasketSound()
    {
        PlaySound(m_starSoundClip);
    }

    public void PlayClickSound()
    {
        PlaySound(m_bubbleClip);
    }

    #endregion

    #region Private

    private void PlaySound(AudioClip clip)
    {
        AudioSource freeSource = GetFreeAudioSource();
        if (freeSource != null)
        {
            freeSource.PlayOneShot(clip);
        }
        else
        {
            soundFXAudioSource1.PlayOneShot(clip);
        }
    }

    private AudioSource GetFreeAudioSource()
    {
        if (!soundFXAudioSource1.isPlaying)
        {
            return soundFXAudioSource1;
        }
        if (!soundFXAudioSource2.isPlaying)
        {
            return soundFXAudioSource2;
        }
        return null;
    }

    #endregion
}