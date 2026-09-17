using System.Collections.Generic;
using UnityEngine;

public class MapObjectLayoutManager : MonoBehaviour
{
    #region Fields

    [Header("Map Configuration")]
    [SerializeField] private MapObjectLayout m_mapLayout = new MapObjectLayout();

    #endregion

    [System.Serializable]
    public class MapObjectLayout
    {
        [SerializeField] private List<CellObjectData> m_cellData = new List<CellObjectData>();

        public void SetCellData(int a_x, int a_y, string a_objectType = "")
        {
            CellObjectData data = m_cellData.Find(d => d.x == a_x && d.y == a_y);
            if (data == null)
            {
                data = new CellObjectData { x = a_x, y = a_y };
                m_cellData.Add(data);
            }

            data.objectType = a_objectType;
        }

        public string GetCellObjectType(int a_x, int a_y)
        {
            CellObjectData data = m_cellData.Find(d => d.x == a_x && d.y == a_y);
            return data?.objectType ?? "";
        }

        public List<CellObjectData> GetAllObjectCells()
        {
            return m_cellData.FindAll(d => !string.IsNullOrEmpty(d.objectType));
        }

        public void Clear()
        {
            m_cellData.Clear();
        }
    }

    [System.Serializable]
    public class CellObjectData
    {
        public int x;
        public int y;
        public string objectType = "";
    }

    #region Public

    //Добавить объект на клетку
    public void AddObjectToCell(int a_x, int a_y, string a_objectType)
    {
        m_mapLayout.SetCellData(a_x, a_y, a_objectType);
    }

    //Убрать объект с клетки
    public void RemoveObjectFromCell(int a_x, int a_y)
    {
        m_mapLayout.SetCellData(a_x, a_y, "");
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

    //Получить все клетки с объектами
    public List<CellObjectData> GetObjectCells()
    {
        return m_mapLayout.GetAllObjectCells();
    }

    #endregion
}