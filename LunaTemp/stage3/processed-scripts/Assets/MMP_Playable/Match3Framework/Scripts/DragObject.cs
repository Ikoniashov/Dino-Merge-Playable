using DG.Tweening;
using System.Collections;
using System.Linq;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    #region Fields

    private ObjectManager m_objectManager;
    public ObjectManager objectManager => m_objectManager;

    [SerializeField] private EggBasket m_eggBasket;
    public EggBasket eggBasket => m_eggBasket;

    [SerializeField] private GameObject m_indicatorObject;
    public GameObject indicatorObject => m_indicatorObject;

    [Header("Object Properties")]
    [SerializeField] private string m_objectType = "Apple";
    public string objectType => m_objectType;

    [SerializeField] private int m_level = 1;
    public int level => m_level;

    [SerializeField] private bool m_canBeMerged = true;

    public bool canBeMerged
    {
        get => m_canBeMerged;
        set => m_canBeMerged = value;
    }

    [SerializeField] private int m_mergeValue = 1;
    [SerializeField] private int m_mergeThreshold = 3;
    public int mergeThreshold => m_mergeThreshold;

    [SerializeField] private bool m_canBeDragged = true;

    [Header("Visual Settings")]
    [SerializeField] private Collider2D m_objectCollider;

    [Header("Merge Settings")]
    [SerializeField] private string m_nextLevelType = "";
    [SerializeField] private int m_nextObjectCountToSpawn = 3; //Количество экземпляров для мерджа

    [Header("Animation Settings")]
    [SerializeField] private float m_moveDuration = 0.3f;

    [Header("Pull Settings")]
    [SerializeField] private float m_pullDelta = 0.3f;
    [SerializeField] private float m_pullTime = 0.3f;

    [Header("Levitation Settings")]
    [SerializeField] private SpriteRenderer m_spriteRenderer;
    [SerializeField] private float m_height = 0.5f;      // Насколько высоко поднимается
    [SerializeField] private float m_duration = 2f;       // Полный цикл (вверх + вниз)
    [SerializeField] private Ease m_easeType = Ease.InOutSine; // Плавная синусоида
    [SerializeField] private int m_loops = -1;            // -1 = бесконечно
    [SerializeField] private LoopType m_loopType = LoopType.Yoyo;
    [SerializeField] private bool m_isDragObjectBouncingInAir = false;

    [SerializeField] private bool m_isMergeOnPlace = false;
    public bool isMergeOnPlace => m_isMergeOnPlace;

    [SerializeField] private bool m_isMergeThisObjectRevealFog = false;
    public bool isMergeThisObjectRevealFog => m_isMergeThisObjectRevealFog;

    private Sequence m_levitationSequence;

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

    private GridCell m_currentCell;
    public GridCell currentCell
    {
        get
        {
            return m_currentCell;
        }
        set
        {
            m_currentCell = value;
        }
    }

    public System.Action<DragObject> e_onObjectSelected;
    public System.Action<DragObject> e_onObjectMoved;
    public System.Action<DragObject> e_onObjectDestroyed;

    private float m_startedScale;
    private bool m_isPulling = false;
    private Transform m_pullTarget;
    private Tween m_pullTween;

    #endregion

    #region UnityEvents

    private void Start()
    {
        m_startedScale = transform.localScale.x;

        m_isAllowedToDrag = m_canBeDragged;
    }

    private void Update()
    {
        if (m_isPulling && m_pullTarget != null && m_currentCell != null)
        {
            Vector3 cellPos = m_currentCell.transform.position;
            Vector3 targetPos = m_pullTarget.position;
            Vector3 direction = (targetPos - cellPos).normalized;
            Vector3 desiredPos = m_pullTarget.position - direction * m_pullDelta;

            StopCurrentTween();
            m_pullTween = transform.DOMove(desiredPos, m_pullTime).SetEase(Ease.OutSine);
        }
    }

    private void OnDisable()
    {
        m_levitationSequence?.Kill();
    }

    private void OnDestroy()
    {
        e_onObjectSelected = null;
        e_onObjectMoved = null;
        e_onObjectDestroyed = null;
    }

    private void OnDrawGizmos()
    {
        if (m_currentCell != null)
        {
            Gizmos.color = m_canBeMerged ? Color.green : Color.red;
            Gizmos.DrawWireSphere(transform.position, 0.3f);

#if UNITY_EDITOR
            UnityEditor.Handles.Label(transform.position + Vector3.up * 0.5f, $"{m_objectType}\nL{m_level}");
#endif
        }
    }

    #endregion

    #region Public

    public void Initialize(GridCell a_startCell, ObjectManager a_objectManager, bool a_isMergeOfThisObjectRevealFog = false)
    {
        m_currentCell = a_startCell;
        m_isMergeThisObjectRevealFog = a_isMergeOfThisObjectRevealFog;

        transform.position = a_startCell.transform.position;
        name = $"{m_objectType}_{a_startCell.xIndex}_{a_startCell.yIndex}";

        m_objectManager = a_objectManager;

        if (m_currentCell.isFogged)
            m_currentCell.HideCellContents();

        if (m_isDragObjectBouncingInAir)
            StartLevitation();
    }

    public void StartLevitation()
    {
        if (!m_isAllowedToDrag || m_spriteRenderer == null) return;

        m_levitationSequence?.Kill();

        // Сохраняем исходную локальную позицию спрайта
        Vector3 originalLocalPos = m_spriteRenderer.transform.localPosition;

        m_levitationSequence = DOTween.Sequence()
            .Append(
                m_spriteRenderer.transform
                    .DOLocalMoveY(originalLocalPos.y + m_height, m_duration / 2)
                    .SetEase(m_easeType)
            )
            .Append(
                m_spriteRenderer.transform
                    .DOLocalMoveY(originalLocalPos.y, m_duration / 2)
                    .SetEase(m_easeType)
            )
            .SetLoops(m_loops, m_loopType)
            .Play();
    }

    public void StartPulling(Transform a_target)
    {
        if (m_currentCell == null) return;
        m_isPulling = true;
        m_pullTarget = a_target;
        StopCurrentTween();
    }

    public int GetSpawnCountForMerge(int a_mergedCount)
    {
        // если недостаточно объектов для мерджа — ничего не спавним
        if (a_mergedCount < m_mergeThreshold)
            return 0;

        // если 5 и больше — 2 новых объекта
        if (a_mergedCount >= 5)
            return 2;

        // если 3 или 4 — 1 новый объект
        return m_nextObjectCountToSpawn > 0 ? m_nextObjectCountToSpawn : 1;
    }

    public void StopPulling()
    {
        if (!m_isPulling) return;
        m_isPulling = false;
        m_pullTarget = null;
        StopCurrentTween();

        if (m_currentCell != null)
        {
            transform.DOMove(m_currentCell.transform.position, 0.2f).SetEase(Ease.OutBack);
        }
    }

    public void FlyTo([Bridge.Ref] Vector3 a_targetPos)
    {
        m_isPulling = false;
        m_pullTarget = null;
        StopCurrentTween();
        transform.DOMove(a_targetPos, 0.3f).SetEase(Ease.InOutBack);
    }

    public void OnMoved()
    {
        e_onObjectMoved?.Invoke(this);
    }

    public bool CanMergeWith(DragObject a_other)
    {
        if (a_other == null) return false;

        // Общие проверки
        if (!m_canBeMerged || !a_other.m_canBeMerged) return false;
        if (m_level != a_other.m_level) return false;

        // Проверяем особые пары (ключ-замок и т.п.)
        if (IsSpecialMergeWith(a_other))
            return true;

        // Обычное совпадение типов
        return m_objectType == a_other.m_objectType;
    }

    public string GetMergedType()
    {
        if (!string.IsNullOrEmpty(m_nextLevelType))
            return m_nextLevelType;
        return $"{m_objectType}_Level{m_level + 1}";
    }

    public void SetLevel(int a_newLevel, string a_newType = "")
    {
        m_level = a_newLevel;
        if (!string.IsNullOrEmpty(a_newType))
        {
            m_objectType = a_newType;
        }
    }

    public void PlaySelectAnimation()
    {
        transform.DOScale(m_startedScale * 1.1f, 0.2f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            transform.DOScale(m_startedScale, 0.2f).SetEase(Ease.OutBack);
        });
    }

    public void OnSelectObject()
    {
        e_onObjectSelected?.Invoke(this);
    }

    public void DestroyWithAnimation()
    {
        StartCoroutine(DestroyAnimation());
    }

    public bool IsNeighborWith(DragObject a_other)
    {
        if (m_currentCell == null || a_other.m_currentCell == null) return false;

        int deltaX = Mathf.Abs(m_currentCell.xIndex - a_other.m_currentCell.xIndex);
        int deltaY = Mathf.Abs(m_currentCell.yIndex - a_other.m_currentCell.yIndex);

        return deltaX <= 1 && deltaY <= 1 && (deltaX != 0 || deltaY != 0);
    }

    public int GetDistanceTo(DragObject a_other)
    {
        if (m_currentCell == null || a_other.m_currentCell == null) return int.MaxValue;

        return Mathf.Abs(m_currentCell.xIndex - a_other.m_currentCell.xIndex) +
               Mathf.Abs(m_currentCell.yIndex - a_other.m_currentCell.yIndex);
    }

    public void VacateCurrentCell()
    {
        if (m_currentCell != null)
        {
            m_currentCell.Vacate();
        }
    }

    #endregion

    #region Private

    private void StopCurrentTween()
    {
        if (m_pullTween != null && m_pullTween.IsActive())
        {
            m_pullTween.Kill();
        }
        m_pullTween = null;
    }

    private bool IsSpecialMergeWith(DragObject a_other)
    {
        // Особые пары можно легко расширять
        switch (m_objectType)
        {
            case "chest":
                return a_other.m_objectType == "key";

            case "key":
                return a_other.m_objectType == "chest";

            default:
                return false;
        }
    }

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

        VacateCurrentCell();

        gameObject.SetActive(false);
        m_objectManager.spawnedObjects.Remove(this);
    }

    #endregion
}