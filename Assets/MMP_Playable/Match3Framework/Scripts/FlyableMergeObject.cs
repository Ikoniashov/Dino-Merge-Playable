using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyableMergeObject : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject m_indicatorObject;
    public GameObject indicatorObject => m_indicatorObject;

    [Header("Pull Settings")]
    [SerializeField] private float m_pullDelta = 0.3f;
    [SerializeField] private float m_pullTime = 0.3f;

    [Header("Object Properties")]
    [SerializeField] private string m_objectType = "Apple";
    public string objectType => m_objectType;

    [SerializeField] private float m_moveSpeed = 3f;
    [SerializeField] private float m_delayBetweenMoves = 0.3f;

    [SerializeField] private int m_mergeThreshold = 3;
    public int mergeTreshold => m_mergeThreshold;

    [SerializeField] private BoxCollider2D m_boxCollider2D;

    [SerializeField] private int m_level = 1;
    public int level => m_level;

    [SerializeField] private bool m_canBeMerged = true;

    private List<Transform> m_pointsToFlying = new List<Transform>();

    private Transform m_startedPosition;
    private Transform m_currentTarget;
    private Tween m_moveTween;

    public System.Action<FlyableMergeObject> e_onObjectSelected;
    public System.Action<FlyableMergeObject> e_onObjectMoved;
    public System.Action<FlyableMergeObject> e_onObjectDestroyed;

    [Header("Merge Settings")]
    [SerializeField] private string m_nextLevelType = "";
    [SerializeField] private int m_nextObjectCountToSpawn = 3;

    private bool m_isAllowedToDrag = true;
    public bool isAllowedToDrag
    {
        get
        {
            return m_isAllowedToDrag;
        }
        set
        {
            m_isAllowedToDrag = value;
        }
    }

    private float m_startedScale;
    private bool m_isPulling = false;
    private Transform m_pullTarget;
    private Tween m_pullTween;

    #endregion

    #region UnityEvents

    private void Start()
    {
        m_startedScale = transform.localScale.x;
    }

    private void Update()
    {
        if (m_isPulling && m_pullTarget != null)
        {
            Vector3 targetPos = m_pullTarget.position;
            Vector3 direction = (targetPos - transform.position).normalized;
            Vector3 desiredPos = m_pullTarget.position - direction * m_pullDelta;

            StopCurrentTween();
            m_pullTween = transform.DOMove(desiredPos, m_pullTime).SetEase(Ease.OutSine);
        }
    }

    private void OnDestroy()
    {
        StopFlying();
    }

    #endregion

    #region Public

    public void DestroyWithAnimation()
    {
        StartCoroutine(DestroyAnimation());
    }

    public int GetSpawnCountForMerge(int a_mergedCount)
    {
        // если недостаточно объектов для мерджа — ничего не спавним
        if (a_mergedCount + 1 < m_mergeThreshold)
            return 0;

        // если 5 и больше — 2 новых объекта
        if (a_mergedCount + 1 >= 5)
            return 2;

        // если 3 или 4 — 1 новый объект
        return m_nextObjectCountToSpawn > 0 ? m_nextObjectCountToSpawn : 1;
    }

    public void SetLevel(int a_newLevel, string a_newType = "")
    {
        m_level = a_newLevel;
        if (!string.IsNullOrEmpty(a_newType))
        {
            m_objectType = a_newType;
        }
    }

    public void Initialize(List<Transform> a_points)
    {
        m_pointsToFlying = a_points;

        // Случайная стартовая позиция
        m_startedPosition = m_pointsToFlying[UnityEngine.Random.Range(0, m_pointsToFlying.Count)];
        transform.position = m_startedPosition.position;

        MoveToNextPoint();
    }

    public void StartPulling(Transform a_target)
    {
        m_isPulling = true;
        m_pullTarget = a_target;
        StopCurrentTween();
    }

    public void StopPulling()
    {
        if (!m_isPulling) return;
        m_isPulling = false;
        m_pullTarget = null;
        StopCurrentTween();

        MoveToNextPoint();
    }

    public void PlaySelectAnimation()
    {
        transform.DOScale(m_startedScale * 1.1f, 0.2f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            transform.DOScale(m_startedScale, 0.2f).SetEase(Ease.OutBack);
        });
    }

    public void FlyTo(Vector3 a_targetPos)
    {
        m_isPulling = false;
        m_pullTarget = null;
        StopCurrentTween();
        transform.DOMove(a_targetPos, 0.3f).SetEase(Ease.InOutBack);
    }

    public string GetMergedType()
    {
        if (!string.IsNullOrEmpty(m_nextLevelType))
            return m_nextLevelType;
        return $"{m_objectType}_Level{m_level + 1}";
    }

    public bool CanMergeWith(FlyableMergeObject a_other)
    {
        if (a_other == null) return false;

        // Общие проверки
        if (!m_canBeMerged || !a_other.m_canBeMerged) return false;
        if (m_level != a_other.m_level) return false;

        // Обычное совпадение типов
        return m_objectType == a_other.m_objectType;
    }

    public void OnSelectObject()
    {
        e_onObjectSelected?.Invoke(this);
    }

    public void SetPrincessReadyToMerge()
    {
        m_boxCollider2D.enabled = true;
    }

    public void InitializeFromPosition(Vector3 a_startPosition, List<Transform> a_points)
    {
        m_pointsToFlying = a_points;

        transform.position = a_startPosition;

        MoveToNextPoint();
    }

    public void MoveToNextPoint()
    {
        // Выбираем новую точку (отличную от текущей)
        Transform nextPoint;
        do
        {
            nextPoint = m_pointsToFlying[UnityEngine.Random.Range(0, m_pointsToFlying.Count)];
        }
        while (nextPoint == m_currentTarget || nextPoint == m_startedPosition);

        m_currentTarget = nextPoint;

        // Расстояние до цели и длительность твина
        float distance = Vector3.Distance(transform.position, m_currentTarget.position);
        float duration = distance / m_moveSpeed;

        // Отменяем предыдущий твин, если он еще идет
        m_moveTween?.Kill();

        // Создаем новый твин перемещения
        m_moveTween = transform.DOMove(m_currentTarget.position, duration)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                // После достижения цели — немного ждем и летим дальше
                DOVirtual.DelayedCall(m_delayBetweenMoves, MoveToNextPoint);
            });
    }

    public void StopFlying()
    {
        m_moveTween?.Kill();
        m_moveTween = null;
    }

    public void ContinueFlying()
    {
        MoveToNextPoint();
    }

    #endregion

    #region Private

    private IEnumerator DestroyAnimation()
    {
        float elapsed = 0f;
        Vector3 originalScale = transform.localScale;

        while (elapsed < 0.2f)
        {
            elapsed += Time.deltaTime;
            transform.localScale = originalScale * (1f - elapsed / 0.2f);
            yield return null;
        }

        e_onObjectDestroyed?.Invoke(this);

        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    private void StopCurrentTween()
    {
        if (m_pullTween != null && m_pullTween.IsActive())
        {
            m_pullTween.Kill();
        }
        m_pullTween = null;
    }

    #endregion
}