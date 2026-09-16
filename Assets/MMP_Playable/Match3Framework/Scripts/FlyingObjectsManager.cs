using System.Collections.Generic;
using UnityEngine;

internal class FlyingObjectsManager : MonoBehaviour
{
    #region Fields

    [SerializeField] private FlyableMergeObject m_flyingPrincess1LevelPrefab;
    [SerializeField] private int flyingPrincess1LevelCount = 2;

    [SerializeField] private FlyableMergeObject m_flyingPrincess2LevelPrefab;
    [SerializeField] private int flyingPrincess2LevelCount = 2;

    private List<FlyableMergeObject> m_flyableObjects = new List<FlyableMergeObject>();

    public List<FlyableMergeObject> flyableObjects => m_flyableObjects;

    #endregion

    #region Public

    public void CreateFlyingPrincess(List<Transform> a_pointsToFlying)
    {
        InstantiatePrincess(a_pointsToFlying);
    }

    public void AddPrincessToFlyableObjects(FlyableMergeObject flyable)
    {
        if (!m_flyableObjects.Contains(flyable))
            m_flyableObjects.Add(flyable);
    }

    public void ActivateAllPrincess()
    {
        foreach (var flyingPrincess in m_flyableObjects)
        {
            flyingPrincess.SetPrincessReadyToMerge();
        }
    }

    #endregion

    #region Private 
    private void InstantiatePrincess(List<Transform> a_pointsToFlying)
    {
        for (int i = 0; i < flyingPrincess1LevelCount; ++i)
        {
            var flyingPrincess = Instantiate(m_flyingPrincess1LevelPrefab, transform);
            flyingPrincess.Initialize(a_pointsToFlying);

            m_flyableObjects.Add(flyingPrincess);
        }

        for (int i = 0; i < flyingPrincess2LevelCount; ++i)
        {
            var flyingPrincess = Instantiate(m_flyingPrincess2LevelPrefab, transform);
            flyingPrincess.Initialize(a_pointsToFlying);

            m_flyableObjects.Add(flyingPrincess);
        }
    }

    #endregion
}