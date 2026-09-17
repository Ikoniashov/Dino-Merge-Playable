using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Luna.Unity;

public enum GameStateID
{
    GameLoad,
    LoadingLevel,
    LoadingWorldMap,
    LoadingFriendCamp,
    WorldMap,
    InLevel,
    InFriendCamp,
    Error
}

public enum ObjectPlacementMoveTypeID
{
    Swoop,
    Jump
}


public enum CellProximitySearchTypeID
{
    RandomFromAll,
    PreferCloser
}

public enum CellAdjacencySearchTypeID
{
    PreferAdjacent,
    AllowAll
}

public enum PrincessGameActionTypeID
{
    None,
    Create,
    Match,
    Match5Plus,
    Activate,
    DieFromTimeout,
    HealLandCell,
    HarvestFrom,
    DropDragonOn,
    HealDeadLandWithMatch,
    MatchOnDeadLand,
    KillZomblins,
    DestroyFromNoHP,
    HaveHealedLand,
    HealAllLand,
    Have,
    Score,
    DragonPower,
    PremiumLand,
    CloudDungeon,
    PremiumLand2,
    PremiumLand3,
    Match5Groups,
    MatchCombo
}

public class GameMgr : MonoBehaviour
{
    public static GameMgr Instance { get; private set; }

    public static Dictionary<string, GameObject> NameToPrefabMap = new Dictionary<string, GameObject>();
    public static Dictionary<string, GameObject> NameToPrefabInPoolMap = new Dictionary<string, GameObject>();
    public static GameStateID GameState;
    public static int progressAllowedLock = 0;
    public static System.Random s_randomNumberGenerator = new System.Random((int)DateTime.Now.Ticks);
    public static GameMgr.ActionDelegate OnAction;
    public delegate void ActionDelegate(PrincessGameActionTypeID id, ObjectForDraw target, int actionCount);
    [HideInInspector] public static bool PlayerPaused;
    [HideInInspector] public GameObject tipFinger_0;
    public static bool showTip = false;
    [HideInInspector] public List<Fog> fogs_0 = new List<Fog>();
    [HideInInspector] public List<Fog> fogs_1 = new List<Fog>();
    [HideInInspector] public static bool _gameOver = false;
    public Button playNowBtn;

    public bool isLandScape;//是否横屏


    public static bool gameOver
    {
        get { return _gameOver; }
        set
        {
            //Time.timeScale = 0;
            
            GameMgr.Instance.OpenStore();
            GameMgr.Instance.tipFinger_0.SetActive(false);

            Analytics.LogEvent(Analytics.EventType.TutorialComplete);
            Analytics.LogEvent(Analytics.EventType.LevelWon);

            Luna.Unity.LifeCycle.GameEnded();
        }
    }

    public static GameObject GenerateFromPrefabAtPrincess(string prefabName, Vector3 position)
    {
        GameObject gameObject = GenerateFromPrefabPrincess(prefabName);
        gameObject.transform.position = position;
        return gameObject;
    }

    public static GameObject GenerateFromPrefabAtPrincess(GameObject prefab, Vector3 position)
    {
        if (prefab == null)
        {
            return null;
        }
        return UnityEngine.Object.Instantiate<GameObject>(prefab, position, prefab.transform.rotation);
    }

    public static GameObject GenerateFromPrefabPrincess(string prefabName)
    {
        GameObject prefab = ObtainPrefabPrincess(prefabName);
        return GenerateFromGameObjectPrincess(prefab);
    }

    public static GameObject GenerateFromGameObjectPrincess(GameObject go)
    {
        if (go == null)
        {
            Debug.LogError("Trying to create from a prefab that is null! Oh Noes! (Yes, you are passing in NULL to a GameGlobals::Create call)");
            return null;
        }
        return UnityEngine.Object.Instantiate<GameObject>(go, Vector3.zero, go.transform.rotation);
    }

    public static GameObject ObtainPrefabPrincess(string prefabName)
    {
        GameObject gameObject;
        if (NameToPrefabMap.TryGetValue(prefabName, out gameObject) && gameObject != null)
        {
            return gameObject;
        }
        if (NameToPrefabInPoolMap.TryGetValue(prefabName, out gameObject) && gameObject != null)
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
            NameToPrefabMap[prefabName] = gameObject;
        }
        else
        {
            Debug.LogError("Could not find a prefab to load with the name [" + prefabName + "]");
        }
        return gameObject;
    }

    public T LoadResource<T>(string resName, bool skipLog = false) where T : UnityEngine.Object
    {
        T currentAsset = Resources.Load<T>(resName);
        if (currentAsset is null)
        {
            currentAsset = Resources.Load<T>("Prefabs/" + resName);
            if (currentAsset == null)
            {
                currentAsset = Resources.Load<T>("Prefabs/Objects/" + resName);
            }
            if (currentAsset == null)
            {
                currentAsset = Resources.Load<T>("Prefabs/Princesses/" + resName);
            }
            if (currentAsset == null)
            {
                if (!skipLog) Debug.LogError("Resource not found: " + resName);
            }
                return currentAsset;
            }

            return currentAsset;
    }

    public static Vector3 Vec3(Vector2 vector)
    {
        return new Vector3(vector.x, vector.y, 0f);
    }

    public static Vector2 InfinityAndNaNCheck(Vector2 vec)
    {
        float num = vec.x;
        float num2 = vec.y;
        bool flag = false;
        if (float.IsNaN(num) || float.IsInfinity(num))
        {
            num = 0f;
            flag = true;
        }
        if (float.IsNaN(num2) || float.IsInfinity(num2))
        {
            num2 = 0f;
            flag = true;
        }
        if (flag)
        {
            vec = new Vector2(num, num2);
        }
        return vec;
    }

    public static T GetEnumValue<T>(string enumValue)
    {
        if (!typeof(T).IsEnum)
        {
            throw new NotSupportedException("You need to use this generic with an Enum type.");
        }
        T result;
        try
        {
            result = (T)((object)Enum.Parse(typeof(T), enumValue));
        }
        catch (Exception e)
        {
            result = default(T);
            Debug.LogError(e.Message);
        }
        return result;
    }

    public static float Random(float min, float max)
    {
        float num = max - min;
        return (float)GameMgr.s_randomNumberGenerator.NextDouble() * num + min;
    }

    public static int RandomInt(int min, int max)
    {
        int num = (int)GameMgr.Random((float)min, (float)max + 0.9999f);
        if (num > max)
        {
            num = max;
        }
        return num;
    }

    public static T RandomElement<T>(IList<T> list)
    {
        if (list == null || list.Count == 0)
        {
            return default(T);
        }
        return list[GameMgr.RandomInt(0, list.Count - 1)];
    }

    public static void EnlistAction(PrincessGameActionTypeID id, ObjectForDraw target, int actionCount = 1)
    {
        if (GameMgr.OnAction != null)
        {
            GameMgr.OnAction(id, target, actionCount);
        }
    }

    public static ObjectForDraw GetUnderlyingObjectScreenPointPrincess(int screenX, int screenY)
    {
        Vector3 position = new Vector3((float)screenX, (float)screenY, 0f);
        Vector3 v = CameraControl.Instance.cameraController.ScreenToWorldPoint(position);
        RaycastHit2D hit = Physics2D.Raycast(v, Vector2.zero);
        if (!hit)
        {
            GridCell cell = GridCellsMgr.Instance.GetCell(v.x, v.y, false, false);
            if (cell != null)
            {
                return cell.Occupant;
            }
            return null;
        }
        ObjectForDraw drawnObject = (ObjectForDraw)hit.collider.gameObject.GetComponent(typeof(ObjectForDraw));
        if (drawnObject == null)
        {
            return null;
        }
        if (drawnObject.Root.transform.parent != null)
        {
            ObjectForDraw[] componentsInChildren = drawnObject.transform.root.GetComponentsInChildren<ObjectForDraw>();
            foreach (ObjectForDraw drawnObject2 in componentsInChildren)
            {
                if (drawnObject2.Root.transform.parent == null)
                {
                    return drawnObject2;
                }
            }
        }
        return drawnObject;
    }

    public static bool IsSimulationPaused()
    {
        return GameMgr.PlayerPaused;
    }

    public static bool IsKindOf<T>(object obj)
    {
        Type type = obj.GetType();
        return type.IsSubclassOf(typeof(T)) || type == typeof(T);
    }

    public static float GetRemainder(float f)
    {
        f = Math.Abs(f);
        return f - Mathf.Floor(f);
    }

    public static List<ObjectForDraw> GetUnderlyingObjectsWorldPointPrincess(float worldX, float worldY)
    {
        Vector2 origin = new Vector2(worldX, worldY);
        RaycastHit2D[] array = Physics2D.RaycastAll(origin, Vector2.zero);
        List<ObjectForDraw> list = new List<ObjectForDraw>();
        foreach (RaycastHit2D raycastHit2D in array)
        {
            ObjectForDraw drawnObject = raycastHit2D.collider.gameObject.GetComponent(typeof(ObjectForDraw)) as ObjectForDraw;
            if (drawnObject != null)
            {
                list.Add(drawnObject);
            }
        }
        return list;
    }

    public static LootTable TryGetLoot(string lootName)
    {
        if (lootName == string.Empty)
        {
            return null;
        }
        return LootTable.GetLootItemOrCreateIfNecessaryPrincess(lootName);
    }

    public static void PerformMoveDropToFreeMetaCellPrincess(ObjectForDraw obj, ObjectPlacementMoveTypeID moveType, bool allowStickyCells = true, bool moveFront = false)
    {
        Vector2 vector = obj.Position2D;
        if (obj.RequiresCellPlacement)
        {
            MetaCell emptyMetaCellNear = GridCellsMgr.Instance.GetEmptyMetaCellNear(obj.Position2D, 1, 1, true, -1, obj.Definition.WidthInTiles, obj.Definition.HeightInTiles, CellProximitySearchTypeID.PreferCloser, CellAdjacencySearchTypeID.AllowAll, false, allowStickyCells, moveFront);
            if (emptyMetaCellNear == null)
            {
                return;
            }
            obj.OccupyMetaCell(emptyMetaCellNear);
            if (moveType == ObjectPlacementMoveTypeID.Swoop)
            {
                obj.TrySwitchToSwooping();
            }
            else
            {
                obj.DefineRootPositionPrincess(emptyMetaCellNear.Center);
            }
        }
        else
        {
            vector = GridCellsMgr.Instance.ObtainEmptyWorldPointNearPrincess(obj.Position2D, -1, CellProximitySearchTypeID.PreferCloser, false);
            if (moveType == ObjectPlacementMoveTypeID.Swoop)
            {
                obj.PerformSwoopOffGridToPrincess(vector.x, vector.y, false, false);
            }
            else
            {
                obj.DefineRootPositionPrincess(vector.x, vector.y);
            }
        }
    }

    public static void PerformSwoopDropToFreeMetaCellPrincess(ObjectForDraw obj, bool moveFront = false)
    {
        GameMgr.PerformMoveDropToFreeMetaCellPrincess(obj, ObjectPlacementMoveTypeID.Swoop, true, moveFront);
    }

    public static Vector3 CheckForInfinityAndNaNPrincess(Vector3 vec)
    {
        float num = vec.x;
        float num2 = vec.y;
        float num3 = vec.z;
        bool flag = false;
        if (float.IsNaN(num) || float.IsInfinity(num))
        {
            num = 0f;
            flag = true;
        }
        if (float.IsNaN(num2) || float.IsInfinity(num2))
        {
            num2 = 0f;
            flag = true;
        }
        if (float.IsNaN(num3) || float.IsInfinity(num3))
        {
            num3 = 0f;
            flag = true;
        }
        if (flag)
        {
            vec = new Vector3(num, num2, num3);
        }
        return vec;
    }

    public static float RandomFloat()
    {
        return (float)GameMgr.s_randomNumberGenerator.NextDouble();
    }

    public static bool Chance(float chanceOfSuccess)
    {
        return chanceOfSuccess >= GameMgr.RandomFloat();
    }

    public static void SwoopOffGridObjectToLocationInCellRadius(ObjectForDraw obj, int cellRadius, Vector2 startingPosition)
    {

        if (obj.Definition.RequiresCellPlacement)
        {
            return;
        }
        Vector2 vector = GridCellsMgr.MapWorldToGrid(startingPosition);
        float x = vector.x + GameMgr.Random((float)(-(float)cellRadius), (float)cellRadius);
        float y = vector.y + GameMgr.Random((float)(-(float)cellRadius), (float)cellRadius);
        Vector2 vector2 = GridCellsMgr.MapGridToWorld(new Vector2(x, y));
        obj.PerformSwoopOffGridToPrincess(vector2.x, vector2.y, false, false);
    }

    public static Bounds RetrieveTotalBoundsPrincess(GameObject obj)
    {
        if (!obj.activeSelf)                   //设置icon尺寸
        {
            return new Bounds(Vector3.zero, Vector3.one);
        }
        SpriteRenderer[] compsInChildren = obj.GetComponentsInChildren<SpriteRenderer>();
        MeshRenderer[] componentsInChildren2 = obj.GetComponentsInChildren<MeshRenderer>();

        List<SpriteRenderer> tempComponents = new List<SpriteRenderer>();
        for (int i = 0; i < compsInChildren.Length; ++i)
        {
            if (compsInChildren[i].sprite != null)
            {
                tempComponents.Add(compsInChildren[i]);
            }
        }

        SpriteRenderer[] componentsInChildren = tempComponents.ToArray();

        if (componentsInChildren.Length == 0 && componentsInChildren2.Length == 0)
        {
            return default(Bounds);
        }
        Bounds result = (componentsInChildren.Length <= 0) ? componentsInChildren2[0].bounds : componentsInChildren[0].bounds;
        if (componentsInChildren.Length > 0)
        {
            for (int i = 1; i < componentsInChildren.Length; i++)
            {
                if (componentsInChildren[i].sprite != null)
                    result.Encapsulate(componentsInChildren[i].bounds);
            }
        }
        int num = (componentsInChildren.Length <= 0) ? 1 : 0;
        if (componentsInChildren2.Length > 0)
        {
            for (int j = num; j < componentsInChildren2.Length; j++)
            {
                result.Encapsulate(componentsInChildren2[j].bounds);
            }
        }
        return result;
    }

    public void FinalUpdates()
    {
        GameInputManager.LastUpdatePrincess();
    }

    public void TryToShowTipFingers()
    {
        TryToShowTipFingers("GoldenSeeds");
        TryToShowTipFingers("Golden_Tree_1");
        TryToShowTipFingers("Golden_Tree_5");
        TryToShowTipFingers("Golden_Tree_10");
        TryToShowTipFingers("Hero_MidasTree");
        TryToShowTipFingers("Fruit_GoldenApple1");
    }

    public void TryToShowTipFingers(string prefabName)
    {
        if (showTip) return;
        if (!MatchObjectDefinition.Definitions.ContainsKey(prefabName)) return;
        MatchObjectDefinition def = MatchObjectDefinition.Definitions[prefabName];
        if (!ObjectForDraw.DrawnObjectLists.ContainsKey(def)) return;
        if (ObjectForDraw.DrawnObjectLists[def] == null) return;
        if (ObjectForDraw.DrawnObjectLists[def].Count == 0) return;
        ObjectForDraw selector_Start_0 = null;
        ObjectForDraw selector_End = null;
        if (GameMgr.Instance.isLandScape)
        {
            if (prefabName == "Golden_Tree_1" && GridCellsMgr.Instance.cells[6][1].KeyObject != null)
            {
                selector_Start_0 = ObjectForDraw.DrawnObjectLists[def][0];
                GridCell target = GridCellsMgr.Instance.cells[6][1];
                if (target == null) return;
                tipFinger_0.SetActive(true);
                ObjectAnim.StartMoveAndScaleAnimation(GameMgr.Instance.tipFinger_0, selector_Start_0.Position2D, target.Center);
                showTip = true;
                return;
            }

            if (prefabName == "Fruit_GoldenApple1" && GridCellsMgr.Instance.cells[6][3].KeyObject != null)
            {
                selector_Start_0 = ObjectForDraw.DrawnObjectLists[def][0];

                GridCell target = GridCellsMgr.Instance.cells[6][3];

                if (target == null) return;
                tipFinger_0.SetActive(true);
                ObjectAnim.StartMoveAndScaleAnimation(GameMgr.Instance.tipFinger_0, selector_Start_0.Position2D, target.Center);
                showTip = true;
                return;
            }
        }
        else
        {
            if (prefabName == "Golden_Tree_1" && GridCellsMgr.Instance.cells[2][1].KeyObject != null)
            {
                selector_Start_0 = ObjectForDraw.DrawnObjectLists[def][0];
                GridCell target = GridCellsMgr.Instance.cells[2][1];
                if (target == null) return;
                tipFinger_0.SetActive(true);
                ObjectAnim.StartMoveAndScaleAnimation(GameMgr.Instance.tipFinger_0, selector_Start_0.Position2D, target.Center);
                showTip = true;
                return;
            }

            if (prefabName == "Fruit_GoldenApple1" && GridCellsMgr.Instance.cells[3][3].KeyObject != null)
            {
                selector_Start_0 = ObjectForDraw.DrawnObjectLists[def][0];
                GridCell target = GridCellsMgr.Instance.cells[3][3];
                if (target == null) return;
                tipFinger_0.SetActive(true);
                ObjectAnim.StartMoveAndScaleAnimation(GameMgr.Instance.tipFinger_0, selector_Start_0.Position2D, target.Center);
                showTip = true;
                return;
            }
        }
        if (prefabName == "Hero_MidasTree" && ObjectForDraw.DrawnObjectLists[def][0].addctiveObject != null)
        {
            selector_Start_0 = ObjectForDraw.DrawnObjectLists[def][0];
            tipFinger_0.SetActive(true);
            GameMgr.Instance.tipFinger_0.transform.position = new Vector2(selector_Start_0.Position2D.x, selector_Start_0.Position2D.y + 1);
            ObjectAnim.StartRotationAnimation(GameMgr.Instance.tipFinger_0.GetComponentInChildren<SpriteRenderer>().gameObject,15,0.5f);
            showTip = true;
            return;
        }
        
        if (prefabName == "Dreamflower_4" && GridCellsMgr.Instance.cells[8][3].KeyObject != null)
        {
            selector_Start_0 = ObjectForDraw.DrawnObjectLists[def][0];
            GridCell target = GridCellsMgr.Instance.cells[8][3];
            if (target == null) return;
            tipFinger_0.SetActive(true);
            ObjectAnim.StartMoveAndScaleAnimation(GameMgr.Instance.tipFinger_0, new Vector2(selector_Start_0.Position2D.x, selector_Start_0.Position2D.y + 0.7f), target.Center);
            showTip = true;
            return;
        }
        if (prefabName == "Dreamflower_1" && GridCellsMgr.Instance.cells[5][4].Dead)
        {
            selector_Start_0 = ObjectForDraw.DrawnObjectLists[def].Find(item => item.deathComponent == null);
            GridCell target;
            if (GridCellsMgr.Instance.cells[5][4].Dead) target = GridCellsMgr.Instance.cells[6][4];
            else target = null;
            if (target == null) return;
            tipFinger_0.SetActive(true);
            ObjectAnim.StartMoveAndScaleAnimation(GameMgr.Instance.tipFinger_0, selector_Start_0.Position2D, target.Center);
            showTip = true;
            return;
        }
        if (ObjectForDraw.DrawnObjectLists[def].Count < 3) return;
        
        bool showTwoFingers = true;

        foreach (var item in ObjectForDraw.DrawnObjectLists[def])
        {
            item.metaCell.FindAvailableMatchesFor_Recursive(def, ref item.neighborPartners, item, true);
            if (item.neighborPartners.Count != 0)
            {
                showTwoFingers = false;
                selector_End = item;
            }
        }
        if (showTwoFingers)
        {
            selector_Start_0 = ObjectForDraw.DrawnObjectLists[def][0];
            selector_End = ObjectForDraw.DrawnObjectLists[def][2];
            GridCell target = GridCellsMgr.Instance.GetGridCellNear(selector_End);
            if (target == null) return;
            tipFinger_0.SetActive(true);
            if (selector_Start_0.Definition.PrefabName == "Princess_Crimson_3_Root") ObjectAnim.StartMoveAndScaleAnimation(GameMgr.Instance.tipFinger_0, new Vector2(selector_Start_0.Position2D.x, selector_Start_0.Position2D.y + 0.5f), target.Center);
            else ObjectAnim.StartMoveAndScaleAnimation(GameMgr.Instance.tipFinger_0, selector_Start_0.Position2D, target.Center);
        }
        else
        {
            selector_Start_0 = ObjectForDraw.DrawnObjectLists[def].Find(item => item.neighborPartners.Count == 0);
            if (selector_Start_0 == null) selector_Start_0 = ObjectForDraw.DrawnObjectLists[def][0];
            tipFinger_0.SetActive(true);
            if (selector_Start_0.Definition.PrefabName == "Princess_Crimson_3_Root") ObjectAnim.StartMoveAndScaleAnimation(GameMgr.Instance.tipFinger_0, new Vector2(selector_Start_0.Position2D.x, selector_Start_0.Position2D.y + 0.5f), selector_End.Position2D);
            else ObjectAnim.StartMoveAndScaleAnimation(GameMgr.Instance.tipFinger_0, selector_Start_0.Position2D, selector_End.Position2D);
        }
        showTip = true;
        foreach (var item in ObjectForDraw.DrawnObjectLists[def])
        {
            item.neighborPartners.Clear();
        }
    }

    public void UnfogATile_ClearAt(Fog fog,bool forcePlayAudio = false)
    {
        if (fog.prefabName != null) GridCellsMgr.Instance.LoadVisibleCellDuringGameplayPrincess(fog.indexX, fog.indexY, fog.prefabName);
        GameAudioMgr.Instance.PlayAtPrincess(GameAudioMgr.Instance.SFX_FogUnitCleared,null,new Vector2(fog.transform.position.x,fog.transform.position.y), 1f, forcePlayAudio);
        GridCellsMgr.Instance.cells[fog.indexX][fog.indexY].IsKeyhole = false;
        GridCellsMgr.Instance.cells[fog.indexX][fog.indexY].KeyObject = null;
        GenerateFromPrefabAtPrincess("ParticleRoot_FogCleared", fog.transform.position);

        if (GameMgr.Instance.isLandScape)
        {
            if (fog.indexX == 6 && fog.indexY == 3)
            {
                GridCell cell = GridCellsMgr.Instance.cells[fog.indexX][fog.indexY];
                cell.IsKeyhole = true;
                cell.keyObjectDefinitionPrefabName = "Fruit_GoldenApple1";
                GameObject tgameObject = GameMgr.GenerateFromPrefabAtPrincess("Fruit_GoldenApple1", new Vector3(cell.transform.position.x, cell.transform.position.y, 10));

                Destroy(tgameObject.GetComponent<ObjectForDraw>());
                Destroy(tgameObject.GetComponentInChildren<AnimationTweenBase>());
                Destroy(tgameObject.GetComponentInChildren<ObjectForDraw>());
                foreach (Transform child in tgameObject.transform)
                {
                    SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();

                    if (spriteRenderer != null)
                    {
                        spriteRenderer.color = Color.black;
                    }

                    foreach (Transform _child in child)
                    {
                        SpriteRenderer _spriteRenderer = _child.GetComponent<SpriteRenderer>();

                        if (_spriteRenderer != null)
                        {
                            _spriteRenderer.color = Color.black;
                        }
                    }
                }
                cell.KeyObject = tgameObject;
            }
        }
        else
        {
            if (fog.indexX == 3 && fog.indexY == 3)
            {
                GridCell cell = GridCellsMgr.Instance.cells[fog.indexX][fog.indexY];
                cell.IsKeyhole = true;
                cell.keyObjectDefinitionPrefabName = "Fruit_GoldenApple1";
                GameObject tgameObject = GameMgr.GenerateFromPrefabAtPrincess("Fruit_GoldenApple1", new Vector3(cell.transform.position.x, cell.transform.position.y, 10));
                Destroy(tgameObject.GetComponent<ObjectForDraw>());
                Destroy(tgameObject.GetComponentInChildren<AnimationTweenBase>());
                Destroy(tgameObject.GetComponentInChildren<ObjectForDraw>());
                foreach (Transform child in tgameObject.transform)
                {
                    SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();

                    if (spriteRenderer != null)
                    {
                        spriteRenderer.color = Color.black;
                    }

                    foreach (Transform _child in child)
                    {
                        SpriteRenderer _spriteRenderer = _child.GetComponent<SpriteRenderer>();

                        if (_spriteRenderer != null)
                        {
                            _spriteRenderer.color = Color.black;
                        }
                    }
                }
                cell.KeyObject = tgameObject;
            }
        }
        
        GameObject.Destroy(fog.gameObject);       
    }

    public static float Random(float max)
    {
        return GameMgr.Random(0f, max);
    }

    public static T RandomElementWeighted<T>(Dictionary<T, float> weightedList)
    {
        if (weightedList == null || weightedList.Count == 0)
        {
            return default(T);
        }
        float num = 0f;
        foreach (float num2 in weightedList.Values)
        {
            float num3 = num2;
            num += num3;
        }
        float num4 = GameMgr.Random(num);
        float num5 = 0f;
        T result = default(T);
        foreach (T t in weightedList.Keys)
        {
            result = t;
            num5 += weightedList[t];
            if (num5 >= num4)
            {
                return t;
            }
        }
        return result;
    }

    public static float CalculateDistancePrincess(GameObject obj1, GameObject obj2)
    {
        Vector2 a = new Vector2(obj1.transform.position.x, obj1.transform.position.y);
        Vector2 b = new Vector2(obj2.transform.position.x, obj2.transform.position.y);
        return Vector2.Distance(a, b);
    }

    public void WinSpawn()
    {
        List<string> list = new List<string> { "Dreamflower_1","Dreamflower_2","Green_Tree_1","Green_Tree_2" };
        System.Random random = new System.Random();
        int randomIndex = random.Next(list.Count);
        string text = list[randomIndex];
        MatchObjectDefinition matchObjectDefinition = MatchObjectDefinition.Definitions[text];
        Vector2 lowerLeftCellSearchAnchorWorld = new Vector2(GridCellsMgr.Instance.cells[5][5].X, GridCellsMgr.Instance.cells[5][5].Y);
        MetaCell emptyMetaCellNear = GridCellsMgr.Instance.GetEmptyMetaCellNear(lowerLeftCellSearchAnchorWorld, 1, 1, false, 5, 1, 1, CellProximitySearchTypeID.RandomFromAll, CellAdjacencySearchTypeID.AllowAll, false, true);
        if (emptyMetaCellNear == null)
        {
            return;
        }
        var temp = MatchObjectDefinition.Definitions[text].GenerateInMetaCellPrincess(emptyMetaCellNear);
        ObjectAnim.StartNewObjectAppearAnimationPrincess(temp);
    }

    public void OpenStore()
    {
        Luna.Unity.Playable.InstallFullGame();
    }


    public void InitFirstKeyHole()
    {
        if (GameMgr.Instance.isLandScape)
        {
            GridCell cell = GridCellsMgr.Instance.cells[6][1];
            cell.keyObjectDefinitionPrefabName = "Golden_Tree_1";
            GameObject tgameObject = GameMgr.GenerateFromPrefabAtPrincess("Golden_Tree_1", new Vector3(cell.transform.position.x, cell.transform.position.y, 2.4f));

            cell.IsKeyhole = true;
            Destroy(tgameObject.GetComponent<ObjectForDraw>());
            tgameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.black;
            cell.KeyObject = tgameObject;
        }
        else
        {
            GridCell cell = GridCellsMgr.Instance.cells[2][1];
            cell.keyObjectDefinitionPrefabName = "Golden_Tree_1";
            GameObject tgameObject = GameMgr.GenerateFromPrefabAtPrincess("Golden_Tree_1", new Vector3(cell.transform.position.x, cell.transform.position.y, 1.8f));

            cell.IsKeyhole = true;
            Destroy(tgameObject.GetComponent<ObjectForDraw>());
            tgameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.black;
            cell.KeyObject = tgameObject;
        }       
    }

    private void SetPlayNowBtnAnim()
    {
        this.playNowBtn.gameObject.AddComponent<ObjectAnimationBase>();
        ObjectAnimationBase temp = this.playNowBtn.gameObject.GetComponent<ObjectAnimationBase>();
        temp.animationTimeScale = 2f;
        temp.tweenScale = 1.05f;
    }

    public void CheckIsLandScape()
    {
        if (Screen.width >= Screen.height) isLandScape = true;
        else isLandScape = false;
    }

    public void AdjustCameraSize()
    {
        Camera cam = Camera.main;
        float targetAspect = 16f / 9f; // 目标宽高比
        float currentAspect = (float)Screen.width / Screen.height;

        if (currentAspect < targetAspect) // 比目标更窄（如手机竖屏）
        {
            var targetSize = 2.4f * (targetAspect / currentAspect);

            if (targetSize >= 6f) cam.orthographicSize = 6f;
            else cam.orthographicSize = targetSize;
        }
        else // 比目标更宽（如超宽屏）
        {
            cam.orthographicSize = 2.4f; // 默认大小
        }

        if (Screen.width < Screen.height)
        {
            RectTransform rt = playNowBtn.GetComponent<RectTransform>();
            rt.anchorMin = new Vector2(0.5f, 0f); // X 轴居中，Y 轴底部
            rt.anchorMax = new Vector2(0.5f, 0f); // X 轴居中，Y 轴底部
            rt.sizeDelta = new Vector2(740f, 280f);
            rt.anchoredPosition = new Vector3(0, 400, 0);
        }
        else
        {
            RectTransform rt = playNowBtn.GetComponent<RectTransform>();
            rt.anchorMin = new Vector2(0.5f, 0f); // X 轴居中，Y 轴底部
            rt.anchorMax = new Vector2(0.5f, 0f); // X 轴居中，Y 轴底部
            rt.sizeDelta = new Vector2(236f, 90f);
            rt.anchoredPosition = new Vector3(515, 55, 0);
        }
    }


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        MatchObjectDefinition.LoadMatchObjectDefinitionsPrincess();
        tipFinger_0 = GameMgr.GenerateFromPrefabPrincess("TipFinger");
        tipFinger_0.SetActive(false);
    }

    private void Start()
    {
        CheckIsLandScape();

        GridCellsMgr.Instance.LoadGridCells();
        Fog.InitializeFogArray();
        InitFirstKeyHole();
        GridCellsMgr.Instance.LoadEntities();

        playNowBtn.onClick.AddListener(OpenStore);
        SetPlayNowBtnAnim();

        Analytics.LogEvent(Analytics.EventType.LevelStart);
        Analytics.LogEvent(Analytics.EventType.TutorialStarted);

        if (isLandScape)
        {
            CameraControl.Camera.transform.position = new Vector3(GridCellsMgr.Instance.cells[6][1].transform.position.x, GridCellsMgr.Instance.cells[6][1].transform.position.y, -10);
        }
        else
        {
            CameraControl.Camera.transform.position = new Vector3((GridCellsMgr.Instance.cells[2][1].transform.position.x + GridCellsMgr.Instance.cells[3][1].transform.position.x)/2,
                GridCellsMgr.Instance.cells[2][1].transform.position.y, -10);
        }
    }

    float temptime = 0f;
    [HideInInspector] public bool startClearFogs_0 = false;
    [HideInInspector] public bool startClearFogs_1 = false;
    [HideInInspector] public bool win = false;
    [HideInInspector] public int winSpawnCount = 16;
    private void LateUpdate()
    {

        temptime += Time.deltaTime;
        if(startClearFogs_0)
        {
            if (temptime > 0.3f)
            {              
                if (fogs_0 != null && fogs_0.Count != 0)
                {
                    temptime = 0;
                    UnfogATile_ClearAt(fogs_0[0],true);
                    fogs_0.Remove(fogs_0[0]);
                }
            }
        }
        if (startClearFogs_1)
        {
            for(int i = 0; i<fogs_1.Count;i++)
            {
                if (fogs_1 != null && fogs_1.Count != 0)
                {
                    UnfogATile_ClearAt(fogs_1[0]);
                    fogs_1.Remove(fogs_1[0]);
                }
            }         
        }
        if(win && winSpawnCount > 0)
        {
            if (temptime > 0.3f)
            {
                temptime = 0;
                WinSpawn();
                winSpawnCount--;
            }           
        }

        GameInputManager.LateUpdate_PlayingState();

        if (GameInputManager.IsPlayerIdle())
        {
            GameInputManager.noInputTime += Time.deltaTime;
            if (GameInputManager.noInputTime >= 1 && !win)
            {
                TryToShowTipFingers();               
                GameInputManager.noInputTime = 0;                               
            }
        }
        else
        {
            GameInputManager.noInputTime = 0;
        }

        CameraControl.Instance.LateUpdate_Custom();

        FinalUpdates();
        AdjustCameraSize();
    }
}
