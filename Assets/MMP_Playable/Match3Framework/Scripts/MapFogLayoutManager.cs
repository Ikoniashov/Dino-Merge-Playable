using System.Collections.Generic;
using UnityEngine;

public class MapFogLayoutManager : MonoBehaviour
{
    #region Fields

    [Header("Map Configuration")]
    [SerializeField] private MapFogLayout m_mapLayout = new MapFogLayout();

    #endregion

    [System.Serializable]
    public class MapFogLayout
    {
        [SerializeField] private List<CellFogData> m_cellData = new List<CellFogData>();

        public void SetCellData(int a_x, int a_y, bool a_hasFog, string a_objectType = "")
        {
            CellFogData data = m_cellData.Find(d => d.x == a_x && d.y == a_y);
            if (data == null)
            {
                data = new CellFogData { x = a_x, y = a_y };
                m_cellData.Add(data);
            }
        }

        public List<CellFogData> GetAllFogCells()
        {
            return m_cellData;
        }

        public void Clear()
        {
            m_cellData.Clear();
        }
    }

    [System.Serializable]
    public class CellFogData
    {
        public int x;
        public int y;
    }

    #region Public

    //Добавить туман на клетку
    public void AddFogToCell(int a_x, int a_y)
    {
        m_mapLayout.SetCellData(a_x, a_y, true);
    }

    //Убрать туман с клетки
    public void RemoveFogFromCell(int a_x, int a_y)
    {
        m_mapLayout.SetCellData(a_x, a_y, false);
    }
    
    //Очистить всю карту
    public void ClearMap()
    {
        m_mapLayout.Clear();
    }

    //Получить данные карты для сохранения
    public string GetMapData()
    {
        return JsonUtility.ToJson(m_mapLayout);
    }

    //Получить все клетки с туманом
    public List<CellFogData> GetFogCells()
    {
        return m_mapLayout.GetAllFogCells();
    }

    #endregion
}