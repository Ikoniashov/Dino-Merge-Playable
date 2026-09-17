using System;
using System.Collections.Generic;
using UnityEngine;

public enum GridGenerationMode
{
    Rectangle,
    CustomShape
}

public class MainSystem : MonoBehaviour
{
    #region Fields
    public static MainSystem Instance { get; private set; }

    [Header("Grid Isometric Settings")]
    [SerializeField] private int m_widthInCells = 13;
    [SerializeField] private int m_heightInCells = 5;
    [SerializeField] private GridGenerationMode m_gridMode;
    [SerializeField] private CustomGridShape m_customShape;

    [Header("Cell Prefabs")]
    [SerializeField] private GridCell m_lightPrefab;
    [SerializeField] private GridCell m_darkPrefab;

    [Header("Subsystems")]
    [SerializeField] private FogManager m_fogManager;
    [SerializeField] private MapObjectLayoutManager m_mapObjectLayoutManager;
    [SerializeField] private MapFogLayoutManager m_mapFogLayoutManager;
    [SerializeField] private ObjectManager m_objectManager;
    [SerializeField] private PointsManager m_pointsManager;

    // Основной массив клеток
    private GridCell[][] m_cells;
    private List<GridCell> m_allCells = new List<GridCell>();

    // Коэффициенты для преобразования координат
    private static readonly float A = 1.925f;
    private static readonly float B = -0.78f; 
    private static readonly float C = 0.42f; 
    private static readonly float D = 0.98f; 
    private static readonly float AD_minus_BC = A * D - B * C;

    // Публичные свойства для доступа из других классов
    public int totalCells => m_allCells.Count;
    public List<GridCell> allCells => m_allCells;

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
        CreateGrid();
        //InitializeSubsystems();

        // Инициализируем менеджер тумана
        m_fogManager.Initialize(this);

        //Спавним туман
        m_fogManager.SpawnMapObjects(m_mapFogLayoutManager);
    }

    #endregion

    #region Public

    public void CreateGridObjects()
    {
        // Инициализируем менеджер объектов
        m_objectManager.Initialize(this);

        // Спавним объекты из карты, если есть менеджер карты
        m_objectManager.SpawnMapObjects(m_mapObjectLayoutManager);
    }

    //Основной метод создания сетки клеток
    public void CreateGrid()
    {
        if (m_gridMode == GridGenerationMode.Rectangle)
            CreateRectangleGrid();
        else
            CreateCustomShapeGrid();

        EstablishCellConnections();
    }

    public List<GridCell> GetNeighborCells(GridCell a_cell)
    {
        List<GridCell> neighbors = new List<GridCell>();

        foreach (var c in m_allCells)
        {
            int dx = Mathf.Abs(c.xIndex - a_cell.xIndex);
            int dy = Mathf.Abs(c.yIndex - a_cell.yIndex);
            if ((dx == 1 && dy == 0) || (dx == 0 && dy == 1))
                neighbors.Add(c);
        }

        return neighbors;
    }

    public List<GridCell> GetAllAdjacentCells(GridCell a_cell)
    {
        List<GridCell> neighbors = new List<GridCell>();

        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                if (dx == 0 && dy == 0) continue;

                int nx = a_cell.xIndex + dx;
                int ny = a_cell.yIndex + dy;

                GridCell neighbor = GetCellAtPosition(nx, ny);
                if (neighbor != null)
                    neighbors.Add(neighbor);
            }
        }

        return neighbors;
    }

    public GridCell GetCellAtPosition(int a_x, int a_y)
    {
        foreach (var cell in allCells)
        {
            if (cell.xIndex == a_x && cell.yIndex == a_y)
                return cell;
        }
        return null; // если нет такой клетки
    }

    public void SpawnCell(int a_xCellIndex, int a_yCellIndex)
    {
        bool isDark = (a_xCellIndex + a_yCellIndex) % 2 == 0;
        GridCell prefabToUse = isDark ? m_darkPrefab : m_lightPrefab;
        GridCell cellInstance = Instantiate(prefabToUse, transform);

        Vector2 worldPos = GridToWorldCoordinates(a_xCellIndex, a_yCellIndex);
        Vector3 position = new Vector3(worldPos.x, worldPos.y, 0);

        // Чем больше Y — тем "ниже" клетка → должна быть НАД другими
        // Добавляем небольшой вклад от X, чтобы при одинаковом Y — правые были выше
        float zDepth = -(a_yCellIndex/30f + a_xCellIndex/40f);
        position.z = -zDepth;

        cellInstance.gameObject.transform.position = position;

        cellInstance.Initialize(this, a_xCellIndex, a_yCellIndex);

        if (a_xCellIndex >= m_widthInCells || a_yCellIndex >= m_heightInCells)
        {
            ExpandGridArray(a_xCellIndex + 1, a_yCellIndex + 1);
        }

        m_cells[a_xCellIndex][a_yCellIndex] = cellInstance;
        m_allCells.Add(cellInstance);
    }

    //Получение клетки по координатам сетки
    public GridCell GetCell(int a_x, int a_y)
    {
        if (a_x >= 0 && a_x < m_widthInCells && a_y >= 0 && a_y < m_heightInCells)
        {
            return m_cells[a_x][a_y];
        }
        return null;
    }

    //Преобразование мировых координат в координаты сетки
    public static Vector2 WorldToGridCoordinates([Bridge.Ref] Vector2 a_worldCoords)
    {
        float x = (MainSystem.D * a_worldCoords.x - MainSystem.B * a_worldCoords.y) / MainSystem.AD_minus_BC;
        float y = (MainSystem.A * a_worldCoords.y - MainSystem.C * a_worldCoords.x) / MainSystem.AD_minus_BC;
        return new Vector2(x, y);
    }

    //Преобразование координат сетки в мировые координаты
    public static Vector2 GridToWorldCoordinates(float a_gridX, float a_gridY)
    {
        float x = MainSystem.A * a_gridX + MainSystem.B * a_gridY;
        float y = MainSystem.C * a_gridX + MainSystem.D * a_gridY;
        return new Vector2(x, y);
    }

    //Получение всех соседних клеток
    public List<GridCell> GetNeighbors(GridCell a_cell)
    {
        List<GridCell> neighbors = new List<GridCell>();

        if (a_cell.LeftNeighbor != null) neighbors.Add(a_cell.LeftNeighbor);
        if (a_cell.RightNeighbor != null) neighbors.Add(a_cell.RightNeighbor);
        if (a_cell.TopNeighbor != null) neighbors.Add(a_cell.TopNeighbor);
        if (a_cell.BottomNeighbor != null) neighbors.Add(a_cell.BottomNeighbor);

        return neighbors;
    }

    public List<GridCell> GetNearestEmptyCells(GridCell a_startCell, int a_count)
    {
        List<GridCell> result = new List<GridCell>();
        if (a_startCell == null) return result;

        int radius = 1;
        while (result.Count < a_count && radius < 10) // радиус поиска до 10 клеток
        {
            foreach (var cell in allCells)
            {
                if (cell == null || !cell.isEmpty) continue;

                float dist = Vector3.Distance(cell.transform.position, a_startCell.transform.position);
                if (dist <= radius)
                {
                    result.Add(cell);
                    if (result.Count >= a_count)
                        return result;
                }
            }
            radius++;
        }

        return result;
    }

    #endregion

    #region Private

    //Инициализация всех подсистем
    private void InitializeSubsystems()
    {
        // Инициализируем менеджер тумана
        m_fogManager.Initialize(this);

        // Инициализируем менеджер объектов
        m_objectManager.Initialize(this);

        //Спавним туман
        m_fogManager.SpawnMapObjects(m_mapFogLayoutManager);

        // Спавним объекты из карты, если есть менеджер карты
        m_objectManager.SpawnMapObjects(m_mapObjectLayoutManager);

        Debug.Log("InitializeSubsystems");

        m_pointsManager.CreatePoints(allCells);

        Debug.Log("After initialize m_pointsManager");
    }

    private void InitializeCellArray()
    {
        m_cells = new GridCell[m_widthInCells][];
        for (int i = 0; i < m_widthInCells; i++)
        {
            m_cells[i] = new GridCell[m_heightInCells];
        }
        m_allCells.Clear();
    }

    private void CreateRectangleGrid()
    {
        InitializeCellArray();

        for (int x = 0; x < m_widthInCells; x++)
        {
            for (int y = 0; y < m_heightInCells; y++)
            {
                SpawnCell(x, y);
            }
        }
    }

    private void CreateCustomShapeGrid()
    {
        InitializeCellArray();

        if (m_customShape == null || m_customShape.cells == null || m_customShape.cells.Count == 0)
        {
            Debug.LogError("Custom grid shape is empty!");
            return;
        }

        int maxX = 0, maxY = 0;
        foreach (var pos in m_customShape.cells)
        {
            if (pos.x > maxX) maxX = pos.x;
            if (pos.y > maxY) maxY = pos.y;
        }

        m_widthInCells = maxX + 1;
        m_heightInCells = maxY + 1;

        // Инициализируем зубчатый массив
        m_cells = new GridCell[m_widthInCells][];
        for (int i = 0; i < m_widthInCells; i++)
            m_cells[i] = new GridCell[m_heightInCells];

        m_allCells.Clear();

        foreach (var pos in m_customShape.cells)
        {
            SpawnCell(pos.x, pos.y); // SpawnCell присваивает m_cells[x][y] и добавляет в m_allCells
        }
    }

    private void ExpandGridArray(int a_newWidth, int a_newHeight)
    {
        GridCell[][] newCells = new GridCell[a_newWidth][];

        for (int i = 0; i < m_cells.Length; i++)
        {
            newCells[i] = new GridCell[a_newHeight];
            Array.Copy(m_cells[i], newCells[i], m_cells[i].Length);
        }

        for (int i = m_cells.Length; i < a_newWidth; i++)
        {
            newCells[i] = new GridCell[a_newHeight];
        }

        m_cells = newCells;
        m_widthInCells = a_newWidth;
        m_heightInCells = a_newHeight;
    }

    private void EstablishCellConnections()
    {
        for (int x = 0; x < m_widthInCells; x++)
        {
            for (int y = 0; y < m_heightInCells; y++)
            {
                if (m_cells[x][y] != null)
                {
                    EstablishCellNeighbors(x, y);
                }
            }
        }
    }

    private void EstablishCellNeighbors(int a_x, int a_y)
    {
        GridCell currentCell = m_cells[a_x][a_y];

        if (a_x > 0) currentCell.LeftNeighbor = m_cells[a_x - 1][a_y];
        if (a_x < m_widthInCells - 1) currentCell.RightNeighbor = m_cells[a_x + 1][a_y];
        if (a_y > 0) currentCell.BottomNeighbor = m_cells[a_x][a_y - 1];
        if (a_y < m_heightInCells - 1) currentCell.TopNeighbor = m_cells[a_x][a_y + 1];

        currentCell.InitializeCellComponents();
    }

    #endregion
}