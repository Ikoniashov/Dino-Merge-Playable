using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TutorialHandPointer : MonoBehaviour
{
    #region Fields

    [SerializeField] private Image m_spriteHand;

    [SerializeField] private Color m_startedColor;
    [SerializeField] private Color m_alphaColor;

    private Sequence m_handSequence;
    private bool m_isNeedToShowTutorial = true;

    #endregion

    #region UnityEvents
    private async void Start()
    {
        await Task.Delay(2000);

        if (m_isNeedToShowTutorial)
            StartTutorialPointAnimation();
    }

    #endregion

    #region Public 

    public void StartTutorialPointAnimation()
    {
        transform.localScale = Vector3.one;
        m_spriteHand.color = m_alphaColor; // Прозрачная изначально

        m_spriteHand.gameObject.SetActive(true);

        m_handSequence = DOTween.Sequence();

        m_handSequence.Append(m_spriteHand.DOFade(1f, 0.5f).SetEase(Ease.OutQuad))
                      .OnComplete(() =>
                      {
                          StartDoubleTapLoop();
                      })
                      .Play();
    }

    public void StopTutorialHandAnimation()
    {
        if (m_handSequence != null)
        {
            m_handSequence.Kill();
            m_handSequence = null;
        }

        m_isNeedToShowTutorial = false;

        m_spriteHand.DOFade(0f, 0.1f).OnComplete(() =>
        {
            m_spriteHand.gameObject.SetActive(false);
        });
    }

    #endregion

    #region Private

    private void StartDoubleTapLoop()
    {
        // Отдельная последовательность только для двойного тапа
        var tapSequence = DOTween.Sequence();

        // Первый тап
        tapSequence.Append(transform.DOScale(0.9f, 0.15f).SetEase(Ease.InOutSine))
                   .Append(transform.DOScale(1f, 0.15f).SetEase(Ease.InOutSine))
                   .AppendInterval(0.1f)
                   // Второй тап
                   .Append(transform.DOScale(0.9f, 0.15f).SetEase(Ease.InOutSine))
                   .Append(transform.DOScale(1f, 0.15f).SetEase(Ease.InOutSine))
                   .AppendInterval(0.5f)
                   .SetLoops(-1, LoopType.Restart);

        // Сохраняем ссылку, чтобы можно было убить при необходимости
        m_handSequence = tapSequence;
        m_handSequence.Play();
    }

    #endregion
}