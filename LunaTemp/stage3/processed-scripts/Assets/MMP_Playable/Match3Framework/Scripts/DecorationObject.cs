using UnityEngine;

public class DecorationObject : MonoBehaviour
{
    [Header("Object Properties")]
    [SerializeField] private string m_objectType = "Apple";
    public string objectType => m_objectType;

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


    public void Initialize(GridCell a_startCell)
    {
        m_currentCell = a_startCell;
        transform.position = a_startCell.transform.position;
        name = $"{m_objectType}_{a_startCell.xIndex}_{a_startCell.yIndex}";
    }
}