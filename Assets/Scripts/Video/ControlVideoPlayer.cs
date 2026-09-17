using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ControlVideoPlayer : MonoBehaviour {

    [SerializeField] private VideoPlayer m_videoPlayer;
    #region UnityEvent

    void Awake() {
        m_videoPlayer.Play();
        m_videoPlayer.loopPointReached += OnVideoEnded;
    }

    #endregion

    private void OnVideoEnded(VideoPlayer eventHandler) {
        m_videoPlayer.loopPointReached -= OnVideoEnded;
        gameObject.SetActive(false);
    }
}
