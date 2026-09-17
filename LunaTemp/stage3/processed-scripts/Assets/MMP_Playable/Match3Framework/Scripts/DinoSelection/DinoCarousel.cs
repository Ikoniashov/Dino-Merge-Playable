using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DinoCarousel : MonoBehaviour
{
    #region Fields

    [SerializeField] private List<Image> m_entitiesSprites;
    [SerializeField] private float m_animationDuration = 0.4f;
    [SerializeField] private float m_slideDistance = 100f; // Пиксели сдвига
    [SerializeField] private Ease m_easeType = Ease.OutQuad;

    [SerializeField] private Vector2 m_startedSpritePosition;
    [SerializeField] private Color m_startedColor;

    [SerializeField] private Image m_frameImage;
    [SerializeField] private Image m_mirrorImage;

    [SerializeField] private Image m_gameObjectLeftArrow;
    [SerializeField] private Image m_gameObjectRightArrow;

    private Sequence m_animationSequence;
    private int m_currentIndex = 0;

    #endregion

    #region UnityEvents

    private void Start()
    {
        // Инициализация: все невидимые, кроме текущего
        ResetAllSprites();

        if (m_entitiesSprites.Count > 0)
            m_entitiesSprites[0].gameObject.SetActive(true);
    }

    #endregion

    #region Public

    public int GetCurrentIndex()
    {
        return m_currentIndex;
    }

    public void HideSelectionChrome()
    {
        m_frameImage.DOFade(0f, 0.5f).OnComplete(() => m_frameImage.gameObject.SetActive(false));
        m_mirrorImage.DOFade(0f, 0.5f).OnComplete(() => m_mirrorImage.gameObject.SetActive(false));

        m_gameObjectLeftArrow.DOFade(0f, 0.5f).OnComplete(() => m_gameObjectLeftArrow.gameObject.SetActive(false));
        m_gameObjectRightArrow.DOFade(0f, 0.5f).OnComplete(() => m_gameObjectRightArrow.gameObject.SetActive(false));
    }

    public void ChangeToRight()
    {
        int previousIndex = m_currentIndex;
        m_currentIndex = (m_currentIndex == m_entitiesSprites.Count - 1) ? 0 : m_currentIndex + 1;
        AnimateTransition(previousIndex, m_currentIndex, true); // true = вправо
    }

    public void ChangeToLeft()
    {
        int previousIndex = m_currentIndex;
        m_currentIndex = (m_currentIndex == 0) ? m_entitiesSprites.Count - 1 : m_currentIndex - 1;
        AnimateTransition(previousIndex, m_currentIndex, false); // false = влево
    }

    #endregion

    #region Private

    private void AnimateTransition(int a_fromIndex, int a_toIndex, bool a_isRight)
    {
        AudioSystem.Instance.PlayClickSound();

        // Убиваем предыдущую анимацию
        m_animationSequence?.Kill();

        Image fromSprite = m_entitiesSprites[a_fromIndex];
        Image toSprite = m_entitiesSprites[a_toIndex];

        // Подготовка: новый спрайт — справа/слева и прозрачный
        PrepareSprite(toSprite, a_isRight ? 1 : -1);
        PrepareSprite(fromSprite, 0); // текущий — на месте

        // Активируем новый
        toSprite.gameObject.SetActive(true);

        // ВАЖНО: Отключаем старый спрайт СРАЗУ, но после начала анимации
        // Это безопасно, потому что новый уже активен и анимируется
        fromSprite.gameObject.SetActive(false);

        // Сброс позиции старого (на всякий случай, если он снова появится)
        fromSprite.rectTransform.anchoredPosition = m_startedSpritePosition;
        fromSprite.color = new Color(fromSprite.color.r, fromSprite.color.g, fromSprite.color.b, 0f);

        m_animationSequence = DOTween.Sequence();

        float fromExitX = a_isRight ? -m_slideDistance : m_slideDistance;
        float toEnterX = a_isRight ? m_slideDistance : -m_slideDistance;

        // Анимация ухода старого (хотя он уже невидим, но позиция нужна для From)
        m_animationSequence.Join(fromSprite.rectTransform
            .DOAnchorPosX(fromExitX, m_animationDuration)
            .SetEase(m_easeType));

        m_animationSequence.Join(fromSprite
            .DOFade(0f, m_animationDuration)
            .SetEase(m_easeType));

        // Анимация входа нового
        m_animationSequence.Join(toSprite.rectTransform
            .DOAnchorPosX(0, m_animationDuration)
            .From(new Vector2(toEnterX, m_startedSpritePosition.y))
            .SetEase(m_easeType));

        m_animationSequence.Join(toSprite
            .DOFade(1f, m_animationDuration)
            .From(0f)
            .SetEase(m_easeType));

        // Теперь OnComplete только для сброса позиции нового
        m_animationSequence.OnComplete(() =>
        {
            toSprite.rectTransform.anchoredPosition = m_startedSpritePosition;
        });

        m_animationSequence.Play();
    }

    private void PrepareSprite(Image a_sprite, int a_direction)
    {
        var rt = a_sprite.rectTransform;
        rt.anchoredPosition = a_direction == 0 ? m_startedSpritePosition : new Vector2(m_slideDistance * a_direction, m_startedSpritePosition.y);
        var color = a_sprite.color;
        color.a = a_direction == 0 ? 1f : 0f;
        a_sprite.color = color;
        a_sprite.gameObject.SetActive(true);
    }

    private void ResetAllSprites()
    {
        foreach (var sprite in m_entitiesSprites)
        {
            sprite.gameObject.SetActive(false);
            sprite.color = m_startedColor;
            sprite.rectTransform.anchoredPosition = m_startedSpritePosition;
        }
    }

    #endregion
}