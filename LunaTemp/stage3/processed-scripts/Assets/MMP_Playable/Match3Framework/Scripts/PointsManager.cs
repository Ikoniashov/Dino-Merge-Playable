using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    #region Fields

    public static PointsManager Instance { get; private set; }

    [SerializeField] private int m_pointsCount = 10;
    [SerializeField] private FlyingObjectsManager m_flyingObjectManager;

    private List<Transform> m_pointsToFlying = new List<Transform>();

    public List<Transform> pointsToFlying => m_pointsToFlying;

    private MainSystem m_mainSystem;

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

    public void CreatePoints(List<GridCell> a_allCells)
    {
        Debug.Log("Inside CreatePoints");

        for (int i = 0; i < m_pointsCount; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, a_allCells.Count);
            GridCell randomCell = a_allCells[randomIndex];

            if (m_pointsToFlying.Contains(randomCell.transform))
                continue;

            m_pointsToFlying.Add(randomCell.transform);
        }

        m_flyingObjectManager.CreateFlyingPrincess(m_pointsToFlying);

        Debug.Log("End CreatePoints");
    }

    #endregion
}
