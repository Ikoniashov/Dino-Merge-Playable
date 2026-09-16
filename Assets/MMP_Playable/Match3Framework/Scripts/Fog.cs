using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Renderer))]
public class FogObject : MonoBehaviour
{
    #region Fields

    [Header("Fog Visual Settings")]
    [SerializeField] private float m_revealDuration = 1.0f;
    [SerializeField] private float m_hideDuration = 0.5f;

    [Header("Visual Effects")]
    [SerializeField] private ParticleSystem m_revealParticles;
    [SerializeField] private ParticleSystem m_hideParticles;
    [SerializeField] private AudioClip m_revealSound;
    [SerializeField] private AudioClip m_hideSound;
    [SerializeField] private SpriteRenderer m_fogRenderer;

    [Header("Animation Settings")]
    [SerializeField] private float m_moveDuration = 0.3f;

    //События
    public System.Action<FogObject> e_onFogRevealed;
    public System.Action<FogObject> e_onFogHidden;
    public System.Action<FogObject> e_onObjectMoved;

    private bool m_canBeRevealed = true;

    private FogState m_currentState = FogState.Hidden;
    private GridCell m_currentCell;

    public GridCell currentCell => m_currentCell;

    //Анимационные параметры
    private float m_initialAlpha;
    
    #endregion

    #region UnityEvents
    private void Awake()
    {
        m_initialAlpha = m_fogRenderer.color.a;
        SetInitialState();
    }

    //Отладочная визуализация
    private void OnDrawGizmos()
    {
        if (m_currentCell != null)
        {
            Gizmos.color = GetFogGizmoColor();
            Gizmos.DrawWireCube(transform.position, new Vector3(0.8f, 0.8f, 0.05f));
        }
    }

    #endregion

    #region Public

    public enum FogState
    {
        Hidden,         //Полностью скрыт
        Revealing,      //В процессе открытия
        Revealed,       //Полностью открыт
        Hiding          //В процессе скрытия
    }

    //Инициализация тумана для конкретной клетки
    public void Initialize(GridCell a_cell)
    {
        m_currentCell = a_cell;

        //Позиционируем туман над клеткой
        transform.position = a_cell.transform.position + Vector3.back * 0.1f;
        name = $"Fog_{a_cell.xIndex}_{a_cell.yIndex}";

        e_onFogHidden?.Invoke(this);
        Debug.Log($"Fog hidden at [{m_currentCell.xIndex}, {m_currentCell.yIndex}]");
    }

    //Перемещение на другую клетку
    public void MoveToCell(GridCell a_newCell)
    {
        GridCell oldCell = m_currentCell;
        m_currentCell = a_newCell;

        transform.DOMove(a_newCell.transform.position, m_moveDuration);

        e_onObjectMoved?.Invoke(this);
    }

    public void VacateCurrentCell()
    {
        if (m_currentCell != null)
        {
            m_currentCell.Vacate();
        }
    }

    public void Reveal()
    {
        if (!m_canBeRevealed || m_currentState == FogState.Revealed) return;

        RevealAnimation();
    }

    //Начать скрытие тумана
    public void Hide()
    {
        if (m_currentState == FogState.Hidden) return;

        HideAnimation();
    }

    #endregion

    #region Private

    //Установка начального состояния
    private void SetInitialState()
    {
        m_currentState = FogState.Hidden;
        m_fogRenderer.enabled = true;

        //Устанавливаем полную непрозрачность
        Color color = m_fogRenderer.color;
        color.a = m_initialAlpha;
        m_fogRenderer.color = color;
    }

    //Начать открытие тумана
    //Анимация открытия тумана
    private void RevealAnimation()
    {
        m_currentState = FogState.Revealing;

        //Визуальные эффекты начала открытия
        OnRevealStart();

        Color startColor = m_fogRenderer.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        m_fogRenderer.DOColor(endColor, m_revealDuration).OnComplete(() =>
        {
            //Завершение открытия
            m_currentState = FogState.Revealed;
            OnRevealComplete();
            m_fogRenderer.enabled = false;
        });
    }

    //Анимация скрытия тумана
    private void HideAnimation()
    {
        m_currentState = FogState.Hiding;

        //Активируем рендерер 
        m_fogRenderer.enabled = true;

        //Визуальные эффекты начала скрытия
        OnHideStart();

        Color startColor = m_fogRenderer.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, m_initialAlpha);

        m_fogRenderer.DOColor(endColor, m_hideDuration).OnComplete(() =>
        {
            //Завершение скрытия
            m_currentState = FogState.Hidden;
            OnHideComplete();
            m_fogRenderer.enabled = false;
        });
    }

    //Действия при начале открытия
    private void OnRevealStart()
    {
        //Воспроизводим звук
        if (m_revealSound != null)
            AudioSource.PlayClipAtPoint(m_revealSound, transform.position);

        //Запускаем частицы
        if (m_revealParticles != null)
            m_revealParticles.Play();

        Debug.Log($"Fog revealing at [{m_currentCell.xIndex}, {m_currentCell.yIndex}]");
    }

    //Действия при завершении открытия
    private void OnRevealComplete()
    {
        e_onFogRevealed?.Invoke(this);
        Debug.Log($"Fog revealed at [{m_currentCell.xIndex}, {m_currentCell.yIndex}]");
    }

    //Действия при начале скрытия
    private void OnHideStart()
    {
        //Воспроизводим звук
        if (m_hideSound != null)
            AudioSource.PlayClipAtPoint(m_hideSound, transform.position);

        //Запускаем частицы
        if (m_hideParticles != null)
            m_hideParticles.Play();

        Debug.Log($"Fog hiding at [{m_currentCell.xIndex}, {m_currentCell.yIndex}]");
    }

    //Действия при завершении скрытия
    private void OnHideComplete()
    {
        e_onFogHidden?.Invoke(this);
        Debug.Log($"Fog hidden at [{m_currentCell.xIndex}, {m_currentCell.yIndex}]");
    }

    private Color GetFogGizmoColor()
    {
        switch (m_currentState)
        {
            case FogState.Hidden: return Color.gray;
            case FogState.Revealing: return Color.yellow;
            case FogState.Revealed: return Color.green;
            case FogState.Hiding: return Color.red;
            default: return Color.white;
        }
    }

    #endregion
}