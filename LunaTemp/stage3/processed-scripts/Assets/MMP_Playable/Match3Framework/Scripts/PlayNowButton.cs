using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayNowButton : MonoBehaviour
{
    #region Fields

    [Header("Animation Settings")]
    [SerializeField] private float m_scaleUpFactor = 1.1f;
    [SerializeField] private float m_scaleDuration = 0.5f;
    [SerializeField] private Ease m_easeType = Ease.InOutQuad;

    [SerializeField] private Button m_goToStoreButton;

    private Vector3 m_originalScale;
    private Sequence m_pulseSequence;

    #endregion

    #region UnityEvents

    private void OnEnable()
    {
        m_goToStoreButton.onClick.AddListener(GoToStore);
    }

    void Start()
    {
        m_originalScale = transform.localScale;
        CreatePulseAnimation();
    }

    void OnDisable()
    {
        m_goToStoreButton.onClick.RemoveAllListeners();
    }

    private void OnDestroy()
    {
        if (m_pulseSequence != null)
            m_pulseSequence.Kill();
    }

    #endregion

    #region Private

    private void GoToStore()
    {
        PlayableCta.OpenStore();
    }

    private void CreatePulseAnimation()
    {
        m_pulseSequence = DOTween.Sequence();

        m_pulseSequence.Append(transform.DOScale(m_originalScale * m_scaleUpFactor, m_scaleDuration)
            .SetEase(m_easeType));

        m_pulseSequence.Append(transform.DOScale(m_originalScale, m_scaleDuration)
            .SetEase(m_easeType));

        m_pulseSequence.SetLoops(-1);
    }

    #endregion
}