using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHand : MonoBehaviour
{
    private enum TutorialState
    {
        Inactive,
        PointingBasket,
        Waiting,
        Hinting,
        Holding
    }

    #region Fields

    public static TutorialHand Instance { get; private set; }

    [SerializeField] private SpriteRenderer m_spriteRenderer;
    [SerializeField] private ObjectManager m_objectManager;
    [SerializeField] private float m_firstHintDelay = 1.5f;
    [SerializeField] private float m_playerInactivityForTutorial = 4f;
    [SerializeField] private float m_escalatedInactivity = 2f;
    [SerializeField] private float m_dragDuration = 0.8f;
    [SerializeField] private float m_screenMargin = 0.08f;

    private TutorialState m_state = TutorialState.Inactive;
    private bool m_isStarted;

    private DragObject m_hintSource;
    private Vector3 m_hintStartPosition;
    private Vector3 m_hintTargetPosition;
    private int m_hintsShown;

    private float m_waitElapsed;
    private Coroutine m_waitRoutine;
    private Sequence m_handSequence;

    private readonly List<DragObject> m_mergeables = new List<DragObject>();
    private readonly List<DragObject> m_cluster = new List<DragObject>();

    #endregion

    #region UnityEvents

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        SetHandAlpha(0f);
    }

    private void OnDestroy()
    {
        KillSequence();
        StopWaiting();
    }

    #endregion

    #region Public

    public void BeginTutorial()
    {
        if (m_isStarted)
            return;

        m_isStarted = true;

        if (FindEggBasket() != null)
        {
            ShowNextStep();
            return;
        }

        ScheduleHint();
    }

    public void NotifyBasketOpened()
    {
        ScheduleHint();
    }

    public void NotifyPlayerInput()
    {
        m_waitElapsed = 0f;
    }

    public void NotifyObjectGrabbed(DragObject a_grabbedObject)
    {
        m_waitElapsed = 0f;

        if (m_state == TutorialState.Hinting && IsSameObject(a_grabbedObject, m_hintSource))
        {
            m_state = TutorialState.Holding;
            PlayHoldAnimation(m_hintTargetPosition);
            return;
        }

        HideHand();

        m_state = TutorialState.Waiting;
    }

    public void ScheduleHint()
    {
        HideHand();

        m_state = TutorialState.Waiting;

        StopWaiting();

        m_waitRoutine = StartCoroutine(WaitForInactivity(GetNextHintDelay()));
    }

    public void StopTutorialHandAnimation()
    {
        HideHand();
        StopWaiting();

        m_state = TutorialState.Inactive;
    }

    #endregion

    #region Private

    private IEnumerator WaitForInactivity(float a_delay)
    {
        m_waitElapsed = 0f;

        while (m_waitElapsed < a_delay)
        {
            m_waitElapsed += Time.deltaTime;
            yield return null;
        }

        m_waitRoutine = null;

        ShowNextStep();
    }

    private void ShowNextStep()
    {
        DragObject basket = FindEggBasket();

        if (basket != null)
        {
            m_state = TutorialState.PointingBasket;
            PlayTapAnimation(basket.transform.position);
            return;
        }

        if (!TryFindHint())
        {
            ScheduleHint();
            return;
        }

        m_state = TutorialState.Hinting;

        PlayDragAnimation(m_hintStartPosition, m_hintTargetPosition, m_hintsShown > 1);

        m_hintsShown++;
    }

    private float GetNextHintDelay()
    {
        if (m_hintsShown == 0)
            return m_firstHintDelay;

        if (m_hintsShown == 1)
            return m_playerInactivityForTutorial;

        return m_escalatedInactivity;
    }

    private bool TryFindHint()
    {
        m_hintSource = null;

        List<DragObject> objects = m_objectManager.spawnedObjects;

        DragObject mergeSource = null;
        Vector3 mergeTarget = Vector3.zero;
        float mergeDistance = float.MaxValue;

        DragObject gatherSource = null;
        Vector3 gatherTarget = Vector3.zero;
        float gatherDistance = float.MaxValue;

        for (int i = 0; i < objects.Count; i++)
        {
            DragObject source = objects[i];

            if (!IsUsableObject(source) || !source.isAllowedToDrag)
                continue;

            CollectMergeables(source, objects);

            if (m_mergeables.Count + 1 < source.mergeThreshold)
                continue;

            Vector3 sourcePosition = source.currentCell.transform.position;

            if (source.mergeThreshold <= 2 && source.isMergeOnPlace)
            {
                DragObject partner = GetNearest(source, m_mergeables);

                if (partner == null)
                    continue;

                Vector3 partnerPosition = partner.currentCell.transform.position;
                float partnerDistance = (sourcePosition - partnerPosition).sqrMagnitude;

                if (partnerDistance < mergeDistance)
                {
                    mergeDistance = partnerDistance;
                    mergeSource = source;
                    mergeTarget = partnerPosition;
                }

                continue;
            }

            for (int j = 0; j < m_mergeables.Count; j++)
            {
                BuildCluster(m_mergeables[j]);

                if (m_cluster.Count + 1 >= source.mergeThreshold)
                {
                    DragObject dropTarget = GetNearest(source, m_cluster);

                    if (dropTarget == null)
                        continue;

                    Vector3 dropPosition = dropTarget.currentCell.transform.position;
                    float dropDistance = (sourcePosition - dropPosition).sqrMagnitude;

                    if (dropDistance < mergeDistance)
                    {
                        mergeDistance = dropDistance;
                        mergeSource = source;
                        mergeTarget = dropPosition;
                    }

                    continue;
                }

                if (IsNeighborOfCluster(source, m_cluster))
                    continue;

                GridCell freeCell = FindFreeNeighborCell(m_cluster, source);

                if (freeCell == null)
                    continue;

                Vector3 gatherPosition = freeCell.transform.position;
                float gatherCandidateDistance = (sourcePosition - gatherPosition).sqrMagnitude;

                if (gatherCandidateDistance < gatherDistance)
                {
                    gatherDistance = gatherCandidateDistance;
                    gatherSource = source;
                    gatherTarget = gatherPosition;
                }
            }
        }

        if (mergeSource != null)
        {
            m_hintSource = mergeSource;
            m_hintTargetPosition = mergeTarget;
        }
        else if (gatherSource != null)
        {
            m_hintSource = gatherSource;
            m_hintTargetPosition = gatherTarget;
        }
        else
        {
            return false;
        }

        m_hintStartPosition = m_hintSource.currentCell.transform.position;

        return true;
    }

    private void CollectMergeables(DragObject a_source, List<DragObject> a_objects)
    {
        m_mergeables.Clear();

        for (int i = 0; i < a_objects.Count; i++)
        {
            DragObject candidate = a_objects[i];

            if (IsSameObject(candidate, a_source) || !IsUsableObject(candidate))
                continue;

            if (a_source.CanMergeWith(candidate))
                m_mergeables.Add(candidate);
        }
    }

    private void BuildCluster(DragObject a_seed)
    {
        m_cluster.Clear();
        m_cluster.Add(a_seed);

        for (int head = 0; head < m_cluster.Count; head++)
        {
            DragObject current = m_cluster[head];

            for (int i = 0; i < m_mergeables.Count; i++)
            {
                DragObject candidate = m_mergeables[i];

                if (Contains(m_cluster, candidate))
                    continue;

                if (current.IsNeighborWith(candidate))
                    m_cluster.Add(candidate);
            }
        }
    }

    private bool IsNeighborOfCluster(DragObject a_source, List<DragObject> a_cluster)
    {
        for (int i = 0; i < a_cluster.Count; i++)
        {
            if (a_source.IsNeighborWith(a_cluster[i]))
                return true;
        }

        return false;
    }

    private GridCell FindFreeNeighborCell(List<DragObject> a_cluster, DragObject a_source)
    {
        GridCell foggedFallback = null;

        for (int i = 0; i < a_cluster.Count; i++)
        {
            GridCell cell = a_cluster[i].currentCell;

            if (cell == null)
                continue;

            GridCell[] neighbors = new[]
            {
                cell.RightNeighbor,
                cell.LeftNeighbor,
                cell.TopNeighbor,
                cell.BottomNeighbor
            };

            for (int j = 0; j < neighbors.Length; j++)
            {
                GridCell neighbor = neighbors[j];

                if (neighbor == null || neighbor.IsOccupied)
                    continue;

                if (neighbor == a_source.currentCell)
                    continue;

                if (!IsOnScreen(neighbor.transform.position))
                    continue;

                if (neighbor.isFogged)
                {
                    if (foggedFallback == null)
                        foggedFallback = neighbor;

                    continue;
                }

                return neighbor;
            }
        }

        return foggedFallback;
    }

    private DragObject GetNearest(DragObject a_source, List<DragObject> a_candidates)
    {
        DragObject nearest = null;
        float nearestDistance = float.MaxValue;

        Vector3 sourcePosition = a_source.currentCell.transform.position;

        for (int i = 0; i < a_candidates.Count; i++)
        {
            float distance = (sourcePosition - a_candidates[i].currentCell.transform.position).sqrMagnitude;

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearest = a_candidates[i];
            }
        }

        return nearest;
    }

    private DragObject FindEggBasket()
    {
        List<DragObject> objects = m_objectManager.spawnedObjects;

        for (int i = 0; i < objects.Count; i++)
        {
            DragObject candidate = objects[i];

            if (candidate == null || !candidate.gameObject.activeSelf)
                continue;

            if (candidate.eggBasket != null && IsOnScreen(candidate.transform.position))
                return candidate;
        }

        return null;
    }

    private bool IsUsableObject(DragObject a_object)
    {
        return a_object != null
            && a_object.gameObject.activeSelf
            && a_object.canBeMerged
            && a_object.currentCell != null
            && a_object.eggBasket == null
            && IsOnScreen(a_object.currentCell.transform.position);
    }

    private bool IsOnScreen([Bridge.Ref] Vector3 a_worldPosition)
    {
        Camera camera = Camera.main;

        if (camera == null)
            return true;

        Vector3 viewportPoint = camera.WorldToViewportPoint(a_worldPosition);

        return viewportPoint.z > 0f
            && viewportPoint.x >= m_screenMargin
            && viewportPoint.x <= 1f - m_screenMargin
            && viewportPoint.y >= m_screenMargin
            && viewportPoint.y <= 1f - m_screenMargin;
    }

    private void PlayTapAnimation([Bridge.Ref] Vector3 a_position)
    {
        KillSequence();

        transform.position = a_position;
        transform.localScale = Vector3.one;
        gameObject.SetActive(true);
        SetHandAlpha(0f);

        m_handSequence = DOTween.Sequence();

        m_handSequence.Append(m_spriteRenderer.DOFade(1f, 0.4f))
                      .Append(transform.DOScale(0.9f, 0.15f).SetEase(Ease.InOutSine))
                      .Append(transform.DOScale(1f, 0.15f).SetEase(Ease.InOutSine))
                      .AppendInterval(0.1f)
                      .Append(transform.DOScale(0.9f, 0.15f).SetEase(Ease.InOutSine))
                      .Append(transform.DOScale(1f, 0.15f).SetEase(Ease.InOutSine))
                      .AppendInterval(0.7f)
                      .Append(m_spriteRenderer.DOFade(0f, 0.4f))
                      .AppendInterval(0.3f)
                      .SetLoops(-1, LoopType.Restart)
                      .Play();
    }

    private void PlayDragAnimation([Bridge.Ref] Vector3 a_from, [Bridge.Ref] Vector3 a_to, bool a_escalated)
    {
        KillSequence();

        transform.position = a_from;
        transform.localScale = Vector3.one;
        gameObject.SetActive(true);
        SetHandAlpha(0f);

        float moveDuration = a_escalated ? m_dragDuration * 0.7f : m_dragDuration;
        float tailInterval = a_escalated ? 0.15f : 0.4f;

        m_handSequence = DOTween.Sequence();

        m_handSequence.Append(m_spriteRenderer.DOFade(1f, 0.35f))
                      .Append(transform.DOScale(0.85f, 0.15f).SetEase(Ease.OutSine))
                      .Append(transform.DOMove(a_to, moveDuration).SetEase(Ease.InOutSine))
                      .Append(transform.DOScale(1f, 0.15f).SetEase(Ease.OutBack))
                      .AppendInterval(0.2f)
                      .Append(m_spriteRenderer.DOFade(0f, 0.3f))
                      .AppendCallback(() => transform.position = a_from)
                      .AppendInterval(tailInterval)
                      .SetLoops(-1, LoopType.Restart)
                      .Play();
    }

    private void PlayHoldAnimation([Bridge.Ref] Vector3 a_position)
    {
        KillSequence();

        transform.position = a_position;
        transform.localScale = Vector3.one;
        gameObject.SetActive(true);

        m_handSequence = DOTween.Sequence();

        m_handSequence.Append(m_spriteRenderer.DOFade(1f, 0.2f))
                      .Append(transform.DOScale(0.85f, 0.4f).SetEase(Ease.InOutSine))
                      .Append(transform.DOScale(1f, 0.4f).SetEase(Ease.InOutSine))
                      .SetLoops(-1, LoopType.Restart)
                      .Play();
    }

    private void HideHand()
    {
        KillSequence();

        if (m_spriteRenderer != null)
            m_spriteRenderer.DOFade(0f, 0.2f);
    }

    private void SetHandAlpha(float a_alpha)
    {
        if (m_spriteRenderer == null)
            return;

        Color color = Color.white;
        color.a = a_alpha;

        m_spriteRenderer.color = color;
    }

    private void KillSequence()
    {
        if (m_handSequence != null)
        {
            m_handSequence.Kill();
            m_handSequence = null;
        }

        transform.DOKill();

        if (m_spriteRenderer != null)
            m_spriteRenderer.DOKill();
    }

    private void StopWaiting()
    {
        if (m_waitRoutine != null)
        {
            StopCoroutine(m_waitRoutine);
            m_waitRoutine = null;
        }
    }

    private static bool IsSameObject(DragObject a_first, DragObject a_second)
    {
        return ReferenceEquals(a_first, a_second);
    }

    private static bool Contains(List<DragObject> a_list, DragObject a_item)
    {
        for (int i = 0; i < a_list.Count; i++)
        {
            if (ReferenceEquals(a_list[i], a_item))
                return true;
        }

        return false;
    }

    #endregion
}
