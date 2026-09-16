using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    #region Fields

    public static ObjectManager Instance { get; private set; }

    [SerializeField] private List<DragObject> m_matchObjectPrefabs;
    [SerializeField] private List<FlyableMergeObject> m_flyableObjectPrefabs;
    [SerializeField] private List<DecorationObject> m_decorationObjects;
    [SerializeField] private PointsManager m_pointsManager;

    [SerializeField] private GameObject m_tapTextTutorial;
    public GameObject tapTextTutorial => m_tapTextTutorial;

    private MainSystem m_cellsManager;
    private List<DragObject> m_spawnedObjects = new List<DragObject>();
    public List<DragObject> spawnedObjects => m_spawnedObjects;

    private List<DecorationObject> m_spawnedDecorationObjects = new List<DecorationObject>();
    public List<DecorationObject> spawnedDecorationObjects => m_spawnedDecorationObjects;

    public System.Action<DragObject> e_onObjectSpawned;
    public System.Action<DragObject> e_onObjectMoved;
    public System.Action<DragObject, DragObject> e_onObjectsMerged;

    #endregion

    #region UnityEvents

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    #endregion

    #region Public

    public void Initialize(MainSystem a_manager)
    {
        m_cellsManager = a_manager;
    }

    //Удалить все объекты
    public void ClearAllObjects()
    {
        foreach (var obj in m_spawnedObjects.ToArray())
        {
            if (obj.currentCell != null)
            {
                obj.VacateCurrentCell();
            }
            Destroy(obj.gameObject);
        }
        m_spawnedObjects.Clear();
    }

    //Найти объект по клетке
    public DragObject GetObjectAtCell(int a_x, int a_y)
    {
        return m_spawnedObjects.Find(o =>
            o.currentCell != null && o.currentCell.xIndex == a_x && o.currentCell.yIndex == a_y);
    }

    //Найти объект по типу
    public List<DragObject> GetObjectsByType(string a_objectType)
    {
        return m_spawnedObjects.FindAll(o => o.objectType == a_objectType);
    }

    //Спавн объектов согласно карте
    public void SpawnMapObjects(MapObjectLayoutManager a_mapLayout)
    {
        if (a_mapLayout == null || m_cellsManager == null) return;

        List<MapObjectLayoutManager.CellObjectData> objectCells = a_mapLayout.GetObjectCells();

        foreach (var objectCell in objectCells)
        {
            GridCell cell = m_cellsManager.GetCell(objectCell.x, objectCell.y);
            if (cell != null && !string.IsNullOrEmpty(objectCell.objectType))
            {
                SpawnStartedObject(objectCell.objectType, cell);
            }
        }

        // Первый этап туториала
        TutorialHand.Instance.ShowTapTutorialStep(spawnedObjects[0].transform.position);

        Debug.Log($"Spawned {m_spawnedObjects.Count} objects from map layout");
    }

    public DragObject SpawnStartedObject(string a_objectType, GridCell a_cell)
    {
        if (a_cell.IsOccupied)
        {
            if (!a_cell.isFogged)
            {
                Debug.LogWarning($"Cannot spawn object on occupied cell [{a_cell.xIndex}, {a_cell.yIndex}]");
                return null;
            }
        }

        DragObject prefab = m_matchObjectPrefabs.Find(op => op.objectType == a_objectType);
        if (prefab == null)
        {
            DecorationObject prefabDecoration = m_decorationObjects.Find(op => op.objectType == a_objectType);

            if (prefabDecoration == null)
                return null;

            DecorationObject newObject = Instantiate(prefabDecoration, transform);
            newObject.Initialize(a_cell);

            m_spawnedDecorationObjects.Add(newObject);

            // Занимаем клетку
            a_cell.Occupy(newObject);

            Debug.Log($"Spawned {a_objectType} at cell [{a_cell.xIndex}, {a_cell.yIndex}]");

            return null;
        }
        else
        {
            // Создаем объект
            DragObject newObject = Instantiate(prefab, transform);
            a_cell.Occupy(newObject);
            newObject.Initialize(a_cell, this, true);

            m_spawnedObjects.Add(newObject);

            // Занимаем клетку

            Debug.Log($"Spawned {a_objectType} at cell [{a_cell.xIndex}, {a_cell.yIndex}]");

            return newObject;
        }
    }

    public FlyableMergeObject SpawnObject(string a_objectType, int a_level, Vector3 a_spawnPosition)
    {
        FlyableMergeObject prefab = m_flyableObjectPrefabs.Find(op => op.objectType == a_objectType);

        if (prefab == null)
        {
            Debug.LogError($"Prefab for object type '{a_objectType}' not found!");
            return null;
        }

        // Создаем объект
        FlyableMergeObject newObject = Instantiate(prefab, a_spawnPosition, Quaternion.identity);
        newObject.transform.SetParent(transform);

        //m_spawnedFlyableMergeObjects.Add(newObject);

        newObject.Initialize(m_pointsManager.pointsToFlying);
        newObject.SetLevel(1, a_objectType);

        //ThirdTutorialStep(newObject, m_spawnedObjects.FirstOrDefault(obj => obj.objectType == "chest"));

        return newObject;
    }

    public DragObject SpawnObject(string a_objectType, GridCell a_cell, int a_level = 1)
    {
        if (a_cell.IsOccupied)
        {
            Debug.LogWarning($"Cannot spawn object on occupied cell [{a_cell.xIndex}, {a_cell.yIndex}]");
            return null;
        }

        DragObject prefab = m_matchObjectPrefabs.Find(op => op.objectType == a_objectType);
        if (prefab == null)
        {
            Debug.LogError($"Prefab for object type '{a_objectType}' not found!");
            return null;
        }

        // Создаем объект
        DragObject newObject = Instantiate(prefab, transform);

        m_spawnedObjects.Add(newObject);

        newObject.Initialize(a_cell, this, true);
        newObject.SetLevel(a_level, a_objectType);

        // Занимаем клетку
        a_cell.Occupy(newObject);

        //ThirdTutorialStep(newObject, m_spawnedObjects.FirstOrDefault(obj => obj.objectType == "chest"));

        Debug.Log($"Spawned {a_objectType} at cell [{a_cell.xIndex}, {a_cell.yIndex}]");

        return newObject;
    }

    #endregion
}