using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour
{
    #region Fields

    public static DragManager Instance { get; private set; }

    [SerializeField] private float m_snapDistance = 0.8f;
    [SerializeField] private HighlightedZone m_highlightedZone;
    [SerializeField] private PointsManager m_pointsManager;
    [SerializeField] private ParticleSystem m_mergeEffectParticleSystem;
    [SerializeField] private ObjectManager m_objectManager;
    [SerializeField] private TutorialHand m_tutorialHand;
    [SerializeField] private FlyingObjectsManager m_flyingObjectsManager;
    [SerializeField] private FogManager m_fogManager;
    [SerializeField] private GameObject m_mergeText;
    [SerializeField] private DinoSelectionManager m_dinoSelectionManager;

    private DragObject m_currentDraggedObject;
    private GridCell m_startCell;
    private Vector3 m_dragOffset;

    private bool m_isDragging = false;
    public bool IsDragging => m_isDragging;

    private GridCell m_lastHoveredCell; // Последняя клетка, над которой был объект
    private GridCell m_previousHoveredCell; // Предыдущая клетка, над которой был объект
    private List<DragObject> m_potentialMergeGroup = new List<DragObject>();

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

    public void StartDrag(DragObject a_draggingObject, Vector3 a_touchPosition)
    {
        if (m_isDragging) return;

        m_currentDraggedObject = a_draggingObject;
        m_startCell = a_draggingObject.currentCell;
        m_isDragging = true;
        m_lastHoveredCell = m_startCell;
        m_previousHoveredCell = m_startCell;

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
        TutorialHand.Instance.StopCoroutine();

        if (m_isDragging) return;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(a_touchPosition);
        worldPos.z = 0;

        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

        if (hit.collider != null)
        {
            DragObject dragObject = hit.collider.GetComponent<DragObject>();
            if (dragObject != null && dragObject.isAllowedToDrag)
            {
                StartDrag(dragObject, a_touchPosition);
                dragObject.e_onObjectSelected?.Invoke(dragObject);
                dragObject.PlaySelectAnimation();
                dragObject.OnSelectObject();
            }
            else if (dragObject != null && !dragObject.isAllowedToDrag)
            {
                if (dragObject.objectType == "eggbasket" && dragObject.eggBasket != null)
                {
                    dragObject.eggBasket.ActivateBasket();
                }
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
        m_potentialMergeGroup = null;
        GridCell hovered = m_lastHoveredCell;
        if (hovered == null) return;

        int threshold = m_currentDraggedObject.mergeThreshold;

        // === ПРЯМОЙ МЕРДЖ: только при threshold == 2 и isMergeOnPlace ===
        if (threshold == 2 && m_currentDraggedObject.isMergeOnPlace && hovered.IsOccupied)
        {
            DragObject target = hovered.ObjectInCell;
            if (m_currentDraggedObject.CanMergeWith(target))
            {
                // Запоминаем только target — pulling НЕ запускаем
                m_potentialMergeGroup = new List<DragObject> { target };
                return;
            }
        }

        // === ГРУППОВОЙ МЕРДЖ: обычная логика (для threshold > 2 или !isMergeOnPlace) ===
        if (hovered.IsOccupied)
        {
            DragObject target = hovered.ObjectInCell;
            if (m_currentDraggedObject.CanMergeWith(target))
            {
                List<DragObject> group = FindMergeGroupVirtual(target, hovered);
                int totalCount = ContainsObject(group, m_currentDraggedObject) ? group.Count : group.Count + 1;
                if (totalCount >= threshold && !m_currentDraggedObject.isMergeOnPlace)
                {
                    m_potentialMergeGroup = group;
                    StartPullingGroup(m_potentialMergeGroup);
                    return;
                }
            }
        }

        foreach (var neighborCell in MainSystem.Instance.GetAllAdjacentCells(hovered))
        {
            if (!neighborCell.IsOccupied) continue;
            DragObject target = neighborCell.ObjectInCell;
            if (!m_currentDraggedObject.CanMergeWith(target)) continue;

            List<DragObject> group = FindMergeGroupVirtual(target, hovered);
            int totalCount = ContainsObject(group, m_currentDraggedObject) ? group.Count : group.Count + 1;
            if (totalCount >= threshold && !m_currentDraggedObject.isMergeOnPlace)
            {
                m_potentialMergeGroup = group;
                StartPullingGroup(m_potentialMergeGroup);
                return;
            }
        }
    }

    private void StartPullingGroup(List<DragObject> a_group)
    {
        if (a_group == null || a_group.Count == 0) return;
        foreach (var obj in a_group)
        {
            obj.StartPulling(m_currentDraggedObject.transform);
        }
    }

    private void StopPullingCurrentGroup()
    {
        if (m_potentialMergeGroup == null || m_potentialMergeGroup.Count == 0) return;
        foreach (var obj in m_potentialMergeGroup)
        {
            obj.StopPulling();
        }
        m_potentialMergeGroup = null;
    }

    private GridCell FindHoveredCell()
    {
        if (m_currentDraggedObject == null || m_currentDraggedObject.indicatorObject == null)
            return null;

        Vector3 indicatorPos = m_currentDraggedObject.indicatorObject.transform.position;
        GridCell nearestCell = null;
        float nearestSqr = float.MaxValue;

        // найдём ближайшую клетку (без учёта snapDistance)
        foreach (var cell in MainSystem.Instance.allCells)
        {
            if (cell == null) continue;
            float sqr = (indicatorPos - cell.transform.position).sqrMagnitude;
            if (sqr < nearestSqr)
            {
                nearestSqr = sqr;
                nearestCell = cell;
            }
        }

        // если ближайшая клетка дальше, чем snapDistance — считаем, что ховера нет
        float snapSqr = m_snapDistance * m_snapDistance;
        if (nearestCell != null && nearestSqr <= snapSqr)
        {
            return nearestCell;
        }

        // нет клетки в радиусе
        return null;
    }

    private void EndDrag()
    {
        if (m_objectManager.spawnedObjects.Count >= 2)
        {
            TutorialHand.Instance.ActivateTutorialAfterPlayerInactivity();
        }

        if (!m_isDragging || m_currentDraggedObject == null) return;

        StopPullingCurrentGroup();
        m_highlightedZone.gameObject.SetActive(false);

        if (m_lastHoveredCell != null && m_lastHoveredCell != m_startCell)
        {
            bool didDirectMerge = TryMoveToCell(m_lastHoveredCell);

            // Если это isMergeOnPlace и мердж уже произошёл — не проверяем группу
            if (!didDirectMerge &&
                (!m_currentDraggedObject.isMergeOnPlace || m_currentDraggedObject.mergeThreshold > 2) &&
                m_currentDraggedObject.currentCell == m_lastHoveredCell)
            {
                List<DragObject> fullGroup = FindMergeGroup(m_currentDraggedObject);
                if (fullGroup.Count + 1 >= m_currentDraggedObject.mergeThreshold && !m_currentDraggedObject.TryGetComponent(out FlyableMergeObject flyableMergeObj))
                {
                    MergeGroup(fullGroup, m_lastHoveredCell);
                }
            }
        }
        else
        {
            ReturnToPreviousCell();
        }

        m_currentDraggedObject = null;
        m_isDragging = false;
        m_lastHoveredCell = null;
        Debug.Log("Drag ended");
    }

    //Возвращает подмножество ровно threshold объектов для мерджа:
    //всегда включает dragged (если он есть в group/передан), 
    //и дополняет ближайшими по дистанции к mergeCell объектами.
    private List<DragObject> GetMergeSubset(List<DragObject> a_fullGroup, GridCell a_mergeCell, int a_threshold, DragObject a_dragged)
    {
        List<DragObject> subset = new List<DragObject>();
        if (a_dragged == null)
        {
            // без dragged — просто берем ближайшие threshold объектов
            var ordered = new List<DragObject>(a_fullGroup);
            ordered.Sort((a, b) =>
            {
                float da = Vector3.SqrMagnitude(a.currentCell.transform.position - a_mergeCell.transform.position);
                float db = Vector3.SqrMagnitude(b.currentCell.transform.position - a_mergeCell.transform.position);
                return da.CompareTo(db);
            });
            for (int i = 0; i < Mathf.Min(a_threshold, ordered.Count); i++) subset.Add(ordered[i]);
            return subset;
        }

        // гарантируем, что dragged присутствует в результирующем списке первым
        subset.Add(a_dragged);

        // собираем кандидатов — все кроме dragged
        List<DragObject> candidates = new List<DragObject>();
        foreach (var o in a_fullGroup)
            if (o != a_dragged) candidates.Add(o);

        // сортируем кандидатов по расстоянию до mergeCell
        candidates.Sort((a, b) =>
        {
            float da = Vector3.SqrMagnitude(a.currentCell.transform.position - a_mergeCell.transform.position);
            float db = Vector3.SqrMagnitude(b.currentCell.transform.position - a_mergeCell.transform.position);
            return da.CompareTo(db);
        });

        int need = a_threshold - subset.Count;
        for (int i = 0; i < candidates.Count && need > 0; i++, need--)
            subset.Add(candidates[i]);

        return subset;
    }

    private bool TryMoveToCell(GridCell a_targetCell)
    {
        if (a_targetCell.IsOccupied)
        {
            return CheckForMerge(a_targetCell); // теперь поддерживает isMergeOnPlace
        }
        else
        {
            MoveObjectToCell(a_targetCell);
            return false;
        }
    }

    private void MoveObjectToCell(GridCell a_newCell)
    {
        if (a_newCell.IsOccupied && a_newCell.ObjectInCell != m_currentDraggedObject)
        {
            ReturnToPreviousCell();
            return;
        }

        if (m_currentDraggedObject.currentCell != null)
            m_currentDraggedObject.VacateCurrentCell();

        a_newCell.Occupy(m_currentDraggedObject);
        m_currentDraggedObject.currentCell = a_newCell;

        SnapToCell(a_newCell);

        m_currentDraggedObject.OnMoved();

        Debug.Log($"Object moved to cell [{a_newCell.xIndex}, {a_newCell.yIndex}]");
    }

    private void SnapToCell(GridCell cell)
    {
        m_currentDraggedObject.transform.position = cell.transform.position;
        m_highlightedZone.transform.position = m_currentDraggedObject.transform.position;
    }

    private bool CheckForMerge(GridCell a_targetCell)
    {
        DragObject targetObject = a_targetCell.ObjectInCell;
        if (targetObject == null || !m_currentDraggedObject.CanMergeWith(targetObject))
        {
            ReturnToPreviousCell();
            return false;
        }

        // === ПРЯМОЙ МЕРДЖ: threshold == 2 + isMergeOnPlace ===
        if (m_currentDraggedObject.mergeThreshold == 2 && m_currentDraggedObject.isMergeOnPlace)
        {
            List<DragObject> subsetFirst = new List<DragObject> { m_currentDraggedObject, targetObject };
            MergeGroup(subsetFirst, a_targetCell);
            return true;
        }

        // === ГРУППОВОЙ МЕРДЖ ===
        List<DragObject> fullGroup = FindMergeGroup(targetObject);
        if (!ContainsObject(fullGroup, m_currentDraggedObject))
            fullGroup.Add(m_currentDraggedObject);

        fullGroup = Distinct(fullGroup);

        int mergeThreshold = m_currentDraggedObject.mergeThreshold;
        if (fullGroup.Count < mergeThreshold)
        {
            ReturnToPreviousCell();
            return false;
        }

        List<DragObject> subset = GetMergeSubset(fullGroup, a_targetCell, mergeThreshold, m_currentDraggedObject);
        MergeGroup(subset, a_targetCell);
        return true;
    }

    private void MergeGroup(List<DragObject> a_subset, GridCell a_mergeCell)
    {
        if (a_subset == null || a_subset.Count == 0) return;

        Vector3 mergePos = a_mergeCell.transform.position;
        DragObject dragged = m_currentDraggedObject;
        StopPullingCurrentGroup();

        // Если dragged не в subset — добавляем (на случай) — но по логике dragged должен быть там
        if (!ContainsObject(a_subset, dragged))
        {
            // если dragged не в subset, то берем subset[0] как базовый
            dragged = a_subset[0];
        }

        foreach (var obj in a_subset)
        {
            if (obj == dragged)
            {
                dragged.transform.position = mergePos;
            }
            else
            {
                obj.FlyTo(mergePos);
            }
        }

        string newType = dragged.GetMergedType();
        int newLevel = dragged.level + 1;
        StartCoroutine(MergeGroupWithDelay(a_subset, a_mergeCell, newType, newLevel));
    }

    private IEnumerator MergeGroupWithDelay(List<DragObject> a_subset, GridCell a_cell, string a_newType, int a_newLevel)
    {
        m_mergeEffectParticleSystem.transform.position = a_cell.transform.position;
        m_mergeEffectParticleSystem.Play();

        // Берём базовый объект (тот, который мы тянули) — попытка найти в subset
        DragObject baseObj = m_currentDraggedObject;
        if (!ContainsObject(a_subset, baseObj))
        {
            // Если dragged вдруг не в subset — используем первый из subset
            baseObj = a_subset[0];
        }

        Vector3 chestPosition = Vector3.zero;

        foreach (var obj in a_subset)
            if (obj.isMergeOnPlace && obj.objectType == "chest")
                chestPosition = obj.transform.position;

        int mergedCount = a_subset.Count;
        int spawnCount = baseObj.GetSpawnCountForMerge(mergedCount);

        // Уничтожаем только объекты из subset
        foreach (var obj in a_subset)
        {
            if (obj != null)
                obj.DestroyWithAnimation();
        }

        m_currentDraggedObject.OnMoved();
        m_currentDraggedObject.DestroyWithAnimation();

        // Снимаем занятие клеток у subset
        foreach (var obj in a_subset)
        {
            if (obj != null && obj.currentCell != null)
            {
                obj.VacateCurrentCell();
            }
        }

        if (a_subset[0].objectType == "key")
        {
            m_tutorialHand.StopTutorialHandAnimation();
            m_mergeText.SetActive(true);
        }

        if (a_subset[0].isMergeThisObjectRevealFog)
        {
            AudioSystem.Instance.PlayFogDissolveSound();
            m_fogManager.RevealFog();
        }

        TutorialHand.Instance.StopTutorialHandAnimation();

        yield return new WaitForSeconds(0.4f);

        AudioSystem.Instance.PlayMergeSound();

        yield return new WaitForSeconds(0.8f);

        // Спавним основной новый объект на месте мерджа
        DragObject dragObjectNew = null;
        FlyableMergeObject flyableMergeNew = null;

        if (a_newType != "princessflying1lvl")
            dragObjectNew = m_objectManager.SpawnObject(a_newType, a_cell, a_newLevel);
        else
            flyableMergeNew = m_objectManager.SpawnObject(a_newType, a_newLevel, baseObj.transform.position);

        if (m_objectManager.spawnedObjects.Count >= 2)
        {
            TutorialHand.Instance.ActivateTutorialAfterPlayerInactivity();
        }

        if (flyableMergeNew != null && chestPosition != Vector3.zero)
        {
            flyableMergeNew.InitializeFromPosition(chestPosition, m_pointsManager.pointsToFlying);
            flyableMergeNew.SetPrincessReadyToMerge();
            m_flyingObjectsManager.AddPrincessToFlyableObjects(flyableMergeNew);
            m_flyingObjectsManager.ActivateAllPrincess();
        }

        if (dragObjectNew.objectType == "princess3lvlfirst"
            || dragObjectNew.objectType == "princess3lvlsecond"
            || dragObjectNew.objectType == "princess3lvlthird"
            || dragObjectNew.objectType == "princess3lvlfourth"
            || dragObjectNew.objectType == "princess3lvlfiveth") //Только для концовки плеебла
        {
            yield return new WaitForSeconds(0.5f);

            m_dinoSelectionManager.ShowRewardCardFinal();
        }
    }

    private List<DragObject> FindMergeGroupVirtual(DragObject a_start, GridCell a_virtualCell)
    {
        var group = FindMergeGroup(a_start);
        // добавляем соседей, которые находятся рядом с virtualCell
        foreach (var neighborCell in MainSystem.Instance.GetAllAdjacentCells(a_virtualCell))
        {
            if (!neighborCell.IsOccupied)
                continue;

            DragObject neighbor = neighborCell.ObjectInCell;

            if (neighbor == m_currentDraggedObject)
                continue;

            if (neighbor != null && a_start.CanMergeWith(neighbor) && !ContainsObject(group, neighbor))
                group.Add(neighbor);
        }
        return group;
    }

    private List<DragObject> FindMergeGroup(DragObject a_start)
    {
        List<DragObject> group = new List<DragObject>();
        Queue<DragObject> queue = new Queue<DragObject>();
        List<DragObject> visited = new List<DragObject>();

        queue.Enqueue(a_start);
        visited.Add(a_start);

        while (queue.Count > 0)
        {
            DragObject current = queue.Dequeue();

            if (current != m_currentDraggedObject)
                group.Add(current);

            foreach (var neighborCell in MainSystem.Instance.GetAllAdjacentCells(current.currentCell))
            {
                DragObject neighbor = neighborCell.ObjectInCell;

                if (neighbor == null || neighbor == m_currentDraggedObject)
                    continue;

                if (!ContainsObject(visited, neighbor) && a_start.CanMergeWith(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        return group;
    }

    // Luna Bridge: List<T>.Contains и HashSet<T> идут через EqualityComparer<T>.Default
    // и на UnityEngine.Object транспилируются некорректно при выключенном Compiler V2.
    private static bool ContainsObject(List<DragObject> a_list, DragObject a_item)
    {
        for (int i = 0; i < a_list.Count; i++)
        {
            if (ReferenceEquals(a_list[i], a_item))
                return true;
        }
        return false;
    }

    private static List<DragObject> Distinct(List<DragObject> a_list)
    {
        List<DragObject> result = new List<DragObject>();
        for (int i = 0; i < a_list.Count; i++)
        {
            if (!ContainsObject(result, a_list[i]))
                result.Add(a_list[i]);
        }
        return result;
    }

    private void ReturnToPreviousCell()
    {
        GridCell safeCell = m_previousHoveredCell;

        if (m_lastHoveredCell != null && !m_lastHoveredCell.IsOccupied)
            safeCell = m_lastHoveredCell;
        else if (m_previousHoveredCell == null || m_previousHoveredCell.IsOccupied)
            safeCell = m_startCell; // возвращаем на старт, если всё занято

        MoveObjectToCell(safeCell);

        Debug.Log("Object returned to cell");
    }

    #endregion
}
