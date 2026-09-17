using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlyingDragManager : MonoBehaviour
{
    #region Fields

    public static FlyingDragManager Instance;

    [SerializeField] private float m_snapDistance = 0.8f;
    [SerializeField] private float mergeRadius = 2f;
    [SerializeField] private float pullSpeed = 3f;
    [SerializeField] private HighlightedZone m_highlightedZone;
    [SerializeField] private FlyingObjectsManager m_flyingObjectsManager;
    [SerializeField] private ParticleSystem m_mergeEffectParticleSystem;
    [SerializeField] private PointsManager m_pointsManager;

    private FlyableMergeObject m_currentDraggedObject;
    private List<FlyableMergeObject> m_potentialMergeGroup = new List<FlyableMergeObject>();
    private List<FlyableMergeObject> m_nearestMergeGroup = new List<FlyableMergeObject>();

    private float m_distanceToOtherFlyable;

    private GridCell m_lastHoveredCell; // Последняя клетка, над которой был объект
    private GridCell m_previousHoveredCell; // Предыдущая клетка, над которой был объект

    private Vector3 m_dragOffset;

    private bool m_isDragging = false;
    public bool IsDragging => m_isDragging;

    #endregion

    #region UnityEvents

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        HandleInput();

        if (m_isDragging && m_currentDraggedObject != null)
            HandleDrag();
    }

    #endregion

    #region Public

    public void StartDrag(FlyableMergeObject a_draggingObject, Vector3 a_touchPosition)
    {
        if (m_isDragging) return;

        a_draggingObject.StopFlying();

        m_currentDraggedObject = a_draggingObject;
        m_isDragging = true;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(a_touchPosition);
        worldPosition.z = 0;
        m_dragOffset = m_currentDraggedObject.transform.position - worldPosition;

        m_highlightedZone.gameObject.SetActive(true);
        m_highlightedZone.transform.position = m_currentDraggedObject.transform.position;
    }

    #endregion

    #region Private

    private void HandleInput()
    {
        if (!Application.isMobilePlatform)
        {
            if (Input.GetMouseButtonDown(0))
            {
                TryStartDrag(Input.mousePosition);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                EndDrag();
            }
        }
        else if (Application.isMobilePlatform && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    TryStartDrag(touch.position);
                    break;

                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    EndDrag();
                    break;
            }
        }
    }

    private void TryStartDrag(Vector3 a_touchPosition)
    {
        if (m_isDragging) return;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(a_touchPosition);
        worldPos.z = 0;

        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

        if (hit.collider != null)
        {
            FlyableMergeObject dragObject = hit.collider.GetComponent<FlyableMergeObject>();
            if (dragObject != null && dragObject.isAllowedToDrag)
            {
                StartDrag(dragObject, a_touchPosition);
                dragObject.e_onObjectSelected?.Invoke(dragObject);
                dragObject.PlaySelectAnimation();
                dragObject.OnSelectObject();
            }
        }
    }

    private void HandleDrag()
    {
        Vector3 touchPosition = Input.mousePosition;

        if (Application.isMobilePlatform && Input.touchCount > 0)
            touchPosition = Input.GetTouch(0).position;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
        worldPosition.z = 0;

        m_currentDraggedObject.indicatorObject.transform.position = worldPosition + m_dragOffset;

        TrackHoveredCell();
    }

    private void TrackHoveredCell()
    {
        GridCell hoveredCell = FindHoveredCell();
        if (hoveredCell != m_lastHoveredCell)
        {
            m_previousHoveredCell = m_lastHoveredCell;
            m_lastHoveredCell = hoveredCell;

            if (m_lastHoveredCell != null)
            {
                // Позиционируем индикатор
                Vector3 targetPos = m_lastHoveredCell.transform.position;
                m_currentDraggedObject.indicatorObject.transform.position = targetPos;
                m_highlightedZone.transform.position = targetPos;

                m_currentDraggedObject.transform.position = targetPos;

                Debug.Log($"Hovering over cell [{m_lastHoveredCell.xIndex}, {m_lastHoveredCell.yIndex}]");
            }

            UpdatePotentialMergeGroup();
        }
    }

    private void UpdatePotentialMergeGroup()
    {
        StopPullingCurrentGroup();
        m_potentialMergeGroup.Clear();
        m_nearestMergeGroup.Clear();
        GridCell hovered = m_lastHoveredCell;
        if (hovered == null) return;

        int threshold = m_currentDraggedObject.mergeTreshold;

        foreach (var flyable in m_flyingObjectsManager.flyableObjects)
        {
            if (flyable == m_currentDraggedObject)
                continue;

            m_distanceToOtherFlyable = Vector3.Distance(m_currentDraggedObject.transform.position, flyable.transform.position);

            if (m_distanceToOtherFlyable <= mergeRadius)
            {
                if (m_currentDraggedObject.CanMergeWith(flyable))
                    m_potentialMergeGroup.Add(flyable);
            }
        }

        if (m_potentialMergeGroup == null || m_potentialMergeGroup.Count == 0) return;

        if (m_potentialMergeGroup.Count + 1 >= threshold)
        {
            m_nearestMergeGroup = m_potentialMergeGroup
                .OrderBy(f => Vector3.Distance(f.transform.position, m_currentDraggedObject.transform.position))
                .Take(threshold)
                .ToList();

            StartPullingGroup(m_nearestMergeGroup);
        }
    }

    private void StartPullingGroup(List<FlyableMergeObject> a_group)
    {
        if (a_group == null || a_group.Count == 0) return;
        foreach (var obj in a_group)
        {
            obj.StopFlying();
            obj.StartPulling(m_currentDraggedObject.transform);
        }
    }

    private void StopPullingCurrentGroup()
    {
        if (m_nearestMergeGroup == null || m_nearestMergeGroup.Count == 0) return;
        foreach (var obj in m_nearestMergeGroup)
        {
            obj.StopPulling();
        }

        m_potentialMergeGroup.Clear();
        m_nearestMergeGroup.Clear();
    }

    private GridCell FindHoveredCell()
    {
        GridCell nearestCell = null;
        float nearestDistance = float.MaxValue;

        foreach (var cell in MainSystem.Instance.allCells)
        {
            float distance = Vector3.Distance(m_currentDraggedObject.indicatorObject.transform.position, cell.transform.position);

            if (distance < m_snapDistance && distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestCell = cell;
            }
        }

        return nearestCell;
    }

    private void EndDrag()
    {
        if (!m_isDragging || m_currentDraggedObject == null) return;

        bool isMerged = CheckForMerge();

        if (!isMerged)
            m_currentDraggedObject.MoveToNextPoint();

        m_highlightedZone.gameObject.SetActive(false);


        StopPullingCurrentGroup();

        m_currentDraggedObject = null;
        m_isDragging = false;
        m_lastHoveredCell = null;
        Debug.Log("Drag ended");
    }

    private bool CheckForMerge()
    {
        if (m_nearestMergeGroup == null) return false;

        int threshold = m_currentDraggedObject.mergeTreshold;
        int totalCount = m_nearestMergeGroup.Count;

        if (totalCount + 1 >= threshold)
        {
            MergeGroup();

            return true;
        }
        else
        {
            m_potentialMergeGroup.Clear();
            m_nearestMergeGroup.Clear();

            return false;
        }
    }

    private void MergeGroup()
    {
        if (m_nearestMergeGroup.Count == 0) return;

        Vector3 mergePos = m_currentDraggedObject.transform.position;

        List<FlyableMergeObject> mergeObjects = new List<FlyableMergeObject>(m_nearestMergeGroup);

        StopPullingCurrentGroup();

        foreach (var obj in mergeObjects)
        {
            obj.FlyTo(mergePos);
        }

        string newType = m_currentDraggedObject.GetMergedType();
        int newLevel = m_currentDraggedObject.level + 1;

        StartCoroutine(MergeGroupWithDelay(mergeObjects, newType, newLevel));
    }

    private IEnumerator MergeGroupWithDelay(List<FlyableMergeObject> a_subset, string a_newType, int a_newLevel)
    {
        m_mergeEffectParticleSystem.transform.position = m_currentDraggedObject.transform.position;
        m_mergeEffectParticleSystem.Play();

        int mergedCount = a_subset.Count;
        int spawnCount = m_currentDraggedObject.GetSpawnCountForMerge(mergedCount);

        // Уничтожаем только объекты из subset
        foreach (var obj in a_subset)
        {
            if (obj != null)
                obj.DestroyWithAnimation();
        }

        Vector3 spawnPosition = m_currentDraggedObject.transform.position;
        m_currentDraggedObject.DestroyWithAnimation();
        m_currentDraggedObject = null;

        yield return new WaitForSeconds(0.4f);

        AudioSystem.Instance.PlayMergeSound();

        yield return new WaitForSeconds(0.8f);

        // Спавним основной новый объект на месте мерджа

        FlyableMergeObject flyableMergeNew = ObjectManager.Instance.SpawnObject(a_newType, a_newLevel, spawnPosition);

        if (flyableMergeNew != null)
        {
            flyableMergeNew.InitializeFromPosition(spawnPosition, m_pointsManager.pointsToFlying);
            flyableMergeNew.SetPrincessReadyToMerge();
            m_flyingObjectsManager.AddPrincessToFlyableObjects(flyableMergeNew);
            m_flyingObjectsManager.ActivateAllPrincess();

            if (flyableMergeNew.objectType == "princessflying3lvl") //Только для концовки плеебла
            {
                yield return new WaitForSeconds(1f);

                PlayableCta.FinishAndOpenStore();
            }

        }
    }
    #endregion
}