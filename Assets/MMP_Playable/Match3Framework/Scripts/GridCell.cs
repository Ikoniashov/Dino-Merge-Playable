using UnityEngine;

public class GridCell : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject m_leftWall;
    [SerializeField] private GameObject m_rightWall;
    [SerializeField] private GameObject m_topWall;
    [SerializeField] private GameObject m_bottomWall;

    [SerializeField] private GameObject m_downSide_left;
    [SerializeField] private GameObject m_downSide_down;

    private GridCell m_leftNeighbor;
    private GridCell m_rightNeighbor;
    private GridCell m_topNeighbor;
    private GridCell m_bottomNeighbor;

    private int m_xIndex;
    private int m_yIndex;
    public int xIndex => m_xIndex;
    public int yIndex => m_yIndex;

    public GridCell LeftNeighbor
    {
        get => m_leftNeighbor;
        set => m_leftNeighbor = value;
    }

    public GridCell RightNeighbor
    {
        get => m_rightNeighbor;
        set => m_rightNeighbor = value;
    }
    public GridCell TopNeighbor
    {
        get => m_topNeighbor;
        set => m_topNeighbor = value;
    }
    public GridCell BottomNeighbor
    {
        get => m_bottomNeighbor;
        set => m_bottomNeighbor = value;
    }

    private FogObject m_fogObject;
    public FogObject fogObject => m_fogObject;

    private DragObject m_objectInCell;
    public DragObject ObjectInCell => m_objectInCell;

    private DecorationObject m_decorationObjectInCell;
    public DecorationObject decorationInCell => m_decorationObjectInCell;

    private bool m_isOccupied = false;
    public bool IsOccupied => m_isOccupied;

    private bool m_isFogged = false;

    private MainSystem m_gridManager;

    public bool isEmpty => !m_isOccupied;
    public bool isFogged => m_isFogged;

    #endregion

    #region UnityEvents

    private void OnDestroy()
    {
        //Отписываемся от событий при уничтожении
        if (m_fogObject != null)
        {
            m_fogObject.e_onFogRevealed -= OnFogRevealed;
            m_fogObject.e_onFogHidden -= OnFogHidden;
        }
    }

    //Отладочная информация в редакторе
    private void OnDrawGizmos()
    {
        // Рисуем рамку вокруг клетки
        Gizmos.color = m_isOccupied ? Color.red : Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(0.9f, 0.9f, 0.1f));

        //Показываем координаты клетки
#if UNITY_EDITOR
        UnityEditor.Handles.Label(transform.position + Vector3.up * 0.5f, $"[{m_xIndex},{m_yIndex}]");
#endif
    }

    #endregion

    #region Public

    //Инициализация клетки
    public void Initialize(MainSystem a_manager, int a_x, int a_y)
    {
        m_gridManager = a_manager;
        m_xIndex = a_x;
        m_yIndex = a_y;

        float z = transform.position.z;

        Vector2 worldPos = MainSystem.GridToWorldCoordinates(a_x + 0.5f, a_y + 0.5f);
        transform.position = new Vector3(worldPos.x, worldPos.y, z);
        name = $"Cell_{a_x}_{a_y}";
    }

    public void HideCellContents()
    {
        if (m_objectInCell == null && !m_isFogged) return;

        m_objectInCell.gameObject.FadeGroup(0f, 1f);
        Debug.Log("Hide Cell Content");
    }

    public void SetFogObject(FogObject a_fog)
    {
        m_fogObject = a_fog;

        m_isFogged = true;

        if (m_objectInCell != null)
            m_objectInCell.canBeMerged = false;

        m_fogObject.e_onFogRevealed += OnFogRevealed;
        m_fogObject.e_onFogHidden += OnFogHidden;
    }

    public void Occupy(DragObject a_matchObject)
    {
        m_objectInCell = a_matchObject;

        if (m_isFogged && m_fogObject != null)
            m_objectInCell.canBeMerged = false;

        m_isOccupied = true;
    }

    public void Occupy(DecorationObject a_matchObject)
    {
        m_decorationObjectInCell = a_matchObject;
        m_isOccupied = true;
    }

    public void Vacate()
    {
        m_objectInCell = null;
        m_isOccupied = false;
    }

    public void SetObjectOnCell(DragObject a_matchObj)
    {
        m_objectInCell = a_matchObj;
        /*matchObject.OnRevealed += OnFogRevealed;
        matchObject.OnFogHidden += OnFogHidden;*/
    }

    //Инициализация компонентов клетки
    public void InitializeCellComponents()
    {
        //Здесь может быть инициализация стен, декораций и т.д.

        m_leftWall.SetActive(m_leftNeighbor == null);
        m_rightWall.SetActive(m_rightNeighbor == null);
        m_topWall.SetActive(m_topNeighbor == null);
        m_bottomWall.SetActive(m_bottomNeighbor == null);

        m_downSide_left.SetActive(m_leftNeighbor == null);
        m_downSide_down.SetActive(m_bottomNeighbor == null);

        Debug.Log($"Cell [{m_xIndex}, {m_yIndex}] initialized with neighbors");
    }

    //Центр клетки в мировых координатах
    public Vector2 Center
    {
        get
        {
            Vector2 worldPos = MainSystem.GridToWorldCoordinates(m_xIndex + 0.5f, m_yIndex + 0.5f);
            return worldPos;
        }
    }

    //Захват клетки объектом
    public void Occupy()
    {
        m_isOccupied = true;
    }

    #endregion

    #region Private

    private void OnFogRevealed(FogObject a_fog)
    {
        m_isFogged = false;

        if (m_objectInCell != null)
            m_objectInCell.canBeMerged = true;

        m_fogObject = null;

        if (m_objectInCell == null && m_decorationObjectInCell == null)
            m_isOccupied = false;

        ShowCellContents();
    }

    //Обработка скрытия тумана
    private void OnFogHidden(FogObject a_fog)
    {
        m_isFogged = true;

        if (m_objectInCell != null)
            m_objectInCell.canBeMerged = false;

        HideCellContents();
    }

    private void ShowCellContents()
    {
        if (m_objectInCell == null) return;

        m_objectInCell.gameObject.FadeGroup(1f, 1f);
        Debug.Log("Show Cell Content");
    }

    #endregion
}