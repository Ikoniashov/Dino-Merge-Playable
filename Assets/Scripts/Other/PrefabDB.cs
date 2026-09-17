using System;
using System.Collections.Generic;
using UnityEngine;

public static class PrefabDB
{
    public static Dictionary<string, GameObject> NameToPrefabMap = new Dictionary<string, GameObject>();
    public static Dictionary<string, GameObject> NameToPrefabInPoolMap = new Dictionary<string, GameObject>();

    public static GameObject ObtainPrefabPrincess(string prefabName)
    {
        GameObject gameObject;
        if (PrefabDB.NameToPrefabMap.TryGetValue(prefabName, out gameObject) && gameObject != null)
        {
            return gameObject;
        }
        if (PrefabDB.NameToPrefabInPoolMap.TryGetValue(prefabName, out gameObject) && gameObject != null)
        {
            return gameObject;
        }

        gameObject = GameMgr.Instance.LoadResource<GameObject>(prefabName, true);

        if (gameObject is null)
        {
            gameObject = Resources.Load<GameObject>(prefabName);
        }
        if (gameObject != null)
        {
            PrefabDB.NameToPrefabMap[prefabName] = gameObject;
        }
        return gameObject;
    }

    public static bool CheckPrefabExistencePrincess(string prefabName)
    {
        if (PrefabDB.NameToPrefabMap.ContainsKey(prefabName))
        {
            return true;
        }
        GameObject x = GameMgr.Instance.LoadResource<GameObject>(prefabName) ?? Resources.Load<GameObject>(prefabName);
        return x != null;
    }
}
