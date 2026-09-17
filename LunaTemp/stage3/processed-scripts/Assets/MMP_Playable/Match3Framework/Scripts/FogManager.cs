using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogManager : MonoBehaviour
{
    #region Fields

    [Header("Object Prefabs")]
    [SerializeField] FogObject m_fogObjectPrefab;

    private List<FogObject> spawnedFogs = new List<FogObject>();

    private MainSystem cellsManager;

    [SerializeField] private List<Vector2Int> m_revealFogCoordinatesStep1;
    [SerializeField] private List<Vector2Int> m_revealFogCoordinatesStep2;

    private int m_revealStep = 1;

    #endregion

    #region Public

    public void Initialize(MainSystem a_manager)
    {
        cellsManager = a_manager;
    }

    //Спавн объектов согласно карте
    public void SpawnMapObjects(MapFogLayoutManager a_mapLayout)
    {
        List<MapFogLayoutManager.CellFogData> fogCells = a_mapLayout.GetFogCells();

        foreach (var objectCell in fogCells)
        {
            GridCell cell = cellsManager.GetCell(objectCell.x, objectCell.y);
            if (cell != null)
            {
                SpawnFogAtCell(cell);
            }
        }

        Debug.Log($"Spawned {spawnedFogs.Count} objects from map layout");
    }

    public void RevealFog()
    {
        if (m_revealStep == 1)
        {
            foreach (var pos in m_revealFogCoordinatesStep1)
            {
                RevealFogAtCell(pos.x, pos.y);
            }

            m_revealStep++;
            return;
        }

        if (m_revealStep == 2)
        {
            foreach (var pos in m_revealFogCoordinatesStep2)
            {
                RevealFogAtCell(pos.x, pos.y);
            }

            m_revealStep++;
            return;
        }
    }

    public void RevealFogAtCell(int x, int y)
    {
        GridCell cell = MainSystem.Instance.GetCell(x, y);

        cell.fogObject.Reveal();
    }

    //Спавн тумана на конкретной клетке
    public FogObject SpawnFogAtCell(GridCell a_cell)
    {
        FogObject newObject = Instantiate(m_fogObjectPrefab, transform);
        newObject.transform.position = a_cell.transform.position;
        newObject.Initialize(a_cell);

        spawnedFogs.Add(newObject);
        a_cell.Occupy();
        a_cell.SetFogObject(newObject);

        return newObject;
    }

    //Перемещение тумана на другую клетку
    public void MoveObjectToCell(FogObject a_fogObject, GridCell a_targetCell)
    {
        if (a_fogObject.currentCell != null)
        {
            a_fogObject.VacateCurrentCell();
        }

        a_targetCell.Occupy();
        a_fogObject.MoveToCell(a_targetCell);
    }

    //Удалить все объекты
    public void ClearAllObjects()
    {
        foreach (var obj in spawnedFogs.ToArray())
        {
            if (obj.currentCell != null)
            {
                obj.VacateCurrentCell();
            }
            Destroy(obj.gameObject);
        }
        spawnedFogs.Clear();
    }

    //Найти объект по клетке
    public FogObject GetObjectAtCell(int a_x, int a_y)
    {
        return spawnedFogs.Find(o =>
            o.currentCell != null && o.currentCell.xIndex == a_x && o.currentCell.yIndex == a_y);
    }

    #endregion
}