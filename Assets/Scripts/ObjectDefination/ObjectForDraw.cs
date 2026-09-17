using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

public enum AutonomyLevelID
{
    Autonomous,
    UserDirected
}

public enum MatchStateID
{
    Idle,
    BeingCarried,
    SwoopingToCell,
    SwoopingToOffGridLocation,
    PostSwoopStillSelected,
    ReservedForMatch,
    ReservedForMatchRecheck,
    ReservedByEnemy,
    Matching,
    FlyingToUI,
    Dying,
    Death,
    Icon,
    Keyhole,
    DrawOnly
}

public enum DeathReasonID
{
    None,
    LifeTimedOut,
    HarvestedAway,
    MasterMatched,
    SlaveMatched,
    ReachedTarget,
    Tapped,
    Replaced,
    SoldOrTrashed,
    PurposeFulfilled,
    UnSummoned,
    CheatUsed,
    Sold,
    NoHPLeft,
    Error
}

public class ObjectForDraw : MonoBehaviour
{
    [SerializeField] private bool m_hideAfterOpenCloud = false;

    public MatchObjectDefinition Definition;
    public MatchObjectDefinition originalDefinition;
    public GameObject m_root;
    public bool requiresCellPlacement;
    public MetaCell targetMetaCell;
    public MetaCell metaCell;
    public bool makeImmuneToDeathOnCreation;
    public bool m_initialized;
    public string guidString;
    public static ulong guidCounter = 1UL;
    public ulong m_guid;
    public bool m_selected;
    public GameObject m_highlight;
    public MatchStateID _matchState = MatchStateID.Idle;
    public List<ObjectForDraw> pushList;
    public List<ObjectForDraw> matchPartners;
    public List<ObjectForDraw> neighborPartners;
    public bool stayAwakeOnIdle;
    public ObjectForDraw greenDownArrow;
    public ObjectForDraw matchTarget;
    public static ObjectForDraw.DrawnObjectHandler OnMergeStart;
    public delegate void DrawnObjectHandler(ObjectForDraw obj);
    public int matchInputOverflowPast3;
    public int bonusMatchOutputsFrom5Matches;
    public int extraMatchTriples;
    public int matchObjectRemainders;
    public int ChainReactionDepth;
    public GameObject tapArrow;
    public bool userDirectedOnGridSwoop;
    public Vector2 offGridSwoopTarget;
    public bool userDirectedOffGridSwoop;
    public DragToward dragMomentum;
    public static Dictionary<MatchObjectDefinition, List<ObjectForDraw>> DrawnObjectLists = new Dictionary<MatchObjectDefinition, List<ObjectForDraw>>();
    public FullofDeadObject deathComponent;
    public List<GameMonster> harvesters = new List<GameMonster>();
    public Timer harvestTimeoutTimer;
    public int harvestChargesLeft;
    public Vector3 originalPosition;
    public Vector3 restingScale;
    public float originalHeightOffsetToTop;
    public static GameObject dropTargetHighlight = null;
    public bool didFirstIdleUpdate;
    public Timer deathTimer;
    public Timer tapRechargeTimer;
    public Timer autoTapTimer;
    public bool ForceUpdateZ;
    public Vector3 lastPosition;
    public bool checkedForChainReactions;
    public ulong MatchChainOriginatorGuid;
    public bool MasterCreatedByMatch;
    public bool IsLeftoverFromMatch;
    public bool readyToBeDestroyedOnMatchComplete;
    public bool destroyedImmediately;
    public DeathReasonID deathReason;
    public static ObjectForDraw.DrawnObjectHandler OnObjectDestroy;
    public static ObjectForDraw dropTargetMostRecentTarget = null;
    public GameObject localPositionAnimationTarget;
    public Quaternion originalRotation;
    public bool IsIcon;
    public bool destroyedProperly;
    public bool onDestroyCalled;
    public int dragonPowerCreatedInMatch;
    public bool CreatedByMatch;
    public bool WasTheMasterMatchOutput;
    public bool instakillOverride;
    public int tapsLeft;
    public int startingTaps;
    public Renderer m_renderer;
    public int startingHarvestCharges = -1;
    public int lastHarvestTapChargeTotalForShrink;
    public static float k_MIN_SHRINK_SCALE_FROM_TAP_AND_HARVEST = 0.5f;
    public Vector3 originalScale;
    public AnimationTweenBase baseAnimationComponent;
    public ObjectMovementStateID _momState;
    public static bool isTipFingerShowing = false;
    public bool forceDelete;
    public GameObject addctiveObject;


    public float DrawnX
    {
        get
        {
            return this.X + this.localPositionAnimationTarget.transform.localPosition.x;
        }
    }

    public float DrawnY
    {
        get
        {
            return this.Y + this.localPositionAnimationTarget.transform.localPosition.y;
        }
    }

    public Vector3 DrawnObjectPosition
    {
        get
        {
            return new Vector3(this.DrawnX, this.DrawnY, this.Z);
        }
    }

    public bool RequiresCellPlacement
    {
        get
        {
            bool? flag = (this.originalDefinition != null) ? new bool?(this.originalDefinition.RequiresCellPlacement) : null;
            return (flag == null) ? this.requiresCellPlacement : flag.Value;
        }
    }

    public MatchStateID MatchState
    {
        get
        {
            return this._matchState;
        }
    }

    public GameObject Root
    {
        get
        {
            return this.m_root;
        }
    }

    public float X
    {
        get
        {
            return (!(this.m_root == null)) ? this.m_root.transform.position.x : 0f;
        }
    }

    public float Y
    {
        get
        {
            return (!(this.m_root == null)) ? this.m_root.transform.position.y : 0f;
        }
    }

    public float Z
    {
        get
        {
            return (!(this.m_root == null)) ? this.m_root.transform.position.z : 0f;
        }
    }

    public bool IsAMonster
    {
        get
        {
            return GameMgr.IsKindOf<GameMonster>(this);
        }
    }

    public MatchStateID State
    {
        get
        {
            return this.MatchState;
        }
    }

    public bool Dead
    {
        get
        {
            return this.deathComponent != null;
        }
    }

    public Vector2 Position2D
    {
        get
        {
            return new Vector2(this.m_root.transform.position.x, this.m_root.transform.position.y);
        }
    }

    public bool IsABeing
    {
        get
        {
            return GameMgr.IsKindOf<GameEntityBe>(this);
        }
    }

    public ulong GUID
    {
        get
        {
            return this.m_guid;
        }
    }

    public bool IsMatchLeader
    {
        get
        {
            return this.matchTarget == this;
        }
    }

    public GameObject LocalPositionAnimTarget
    {
        get
        {
            return this.localPositionAnimationTarget;
        }
    }

    public GameMonster AsMonster
    {
        get
        {
            return this as GameMonster;
        }
    }

    public int NumItemsUsedInMatch
    {
        get
        {
            return 3 + this.matchInputOverflowPast3 - this.matchObjectRemainders;
        }
    }

    public bool IsTemporary { get; set; }

    public Renderer Renderer
    {
        get
        {
            if (this.m_renderer == null)
            {
                this.m_renderer = FindObjectRendererPrincess(this.GetComponent<Renderer>() == null ? this.GetComponentInChildren<Renderer>() : this.GetComponent<Renderer>()); //this.GetComponent<Renderer>();

            }
            return this.m_renderer;
        }
    }

    public Vector3 DrawnCenter
    {
        get
        {
            return this.Renderer.bounds.center;
        }
    }

    public AnimationTweenBase BaseAnimComponent
    {
        get
        {
            return this.baseAnimationComponent;
        }
    }

    public bool AtOriginalLocalTransform
    {
        get
        {
            if (this.localPositionAnimationTarget.gameObject == null)
            {
                return true;
            }
            return this.localPositionAnimationTarget.transform.localPosition == this.originalPosition && this.transform.localRotation == this.originalRotation && this.transform.localScale == this.restingScale;
        }
    }


    public bool IsInASelectableState()
    {
        return this.Definition.Selectable && this.MatchState != MatchStateID.Icon && this.MatchState != MatchStateID.ReservedByEnemy && this.MatchState != MatchStateID.Death && this.MatchState != MatchStateID.Dying && this.MatchState != MatchStateID.Matching && this.MatchState != MatchStateID.ReservedForMatch && this.MatchState != MatchStateID.BeingCarried && this.MatchState != MatchStateID.DrawOnly && this.MatchState != MatchStateID.FlyingToUI && !(this.GetComponent<FullofDeadObject>() != null) && !(this.GetComponent<ObjectOfKey>() != null);
    }


    public void SetDefinition(MatchObjectDefinition def)
    {
        this.Definition = def;
        this.originalDefinition = this.Definition;
    }

    public static ObjectForDraw Create(string prefabName, GameObject particlesToAddPrefab = null, float particleZPush = -0.5f)
    {
        UnityEngine.Debug.Log($"ObjectForDraw.cs: Create {prefabName}");

        MatchObjectDefinition matchObjectDefinition = null;
        if (string.IsNullOrEmpty(prefabName))
        {
            return null;
        }
        
        if (MatchObjectDefinition.Definitions.ContainsKey(prefabName))
        {
            matchObjectDefinition = MatchObjectDefinition.Definitions[prefabName];
        }

        if (matchObjectDefinition == null)
        {
            return null;
        }

        string text = matchObjectDefinition.PrefabName;
        
        GameObject gameObject = GameMgr.GenerateFromPrefabPrincess(text);
        if (gameObject == null)
        {
            return null;
        }
        ObjectForDraw componentInChildren = gameObject.GetComponentInChildren<ObjectForDraw>();
        componentInChildren.SetDefinition(matchObjectDefinition);
        if (particlesToAddPrefab != null)
        {
            //componentInChildren.AttachParticleEffectPrincess(particlesToAddPrefab, particleZPush);
        }
        return componentInChildren;
    }

    public void DefineRootPositionPrincess(Vector2 pos)
    {
        pos = GameMgr.InfinityAndNaNCheck(pos);
        this.m_root.transform.position = new Vector3(pos.x, pos.y, this.m_root.transform.position.z);
    }

    public void DefineRootPositionPrincess(float x, float y)
    {
        this.DefineRootPositionPrincess(new Vector2(x, y));
    }

    public void LeaveMetaCellPrincess()
    {
        if (this.metaCell != null)
        {
            if (this.targetMetaCell == this.metaCell)
            {
                this.targetMetaCell = null;
            }
            this.metaCell.Vacate(this);
        }
        this.metaCell = null;
    }

    public void OccupyMetaCell(MetaCell newMetaCell, bool useOverlappingSlot)
    {
        if (!this.RequiresCellPlacement)
        {
            return;
        }
        if (newMetaCell == null)
        {
            return;
        }
        if (newMetaCell.IsFullyOccupiedBy(this, true))
        {
            this.targetMetaCell = newMetaCell;
            return;
        }
        this.LeaveMetaCellPrincess();
        this.metaCell = newMetaCell;
        this.targetMetaCell = newMetaCell;
        if (useOverlappingSlot)
        {
            this.metaCell.SetOverlapOccupant(this);
        }
        else
        {
            this.metaCell.SetOccupant(this);
        }
    }

    public void OccupyMetaCell(MetaCell newMetaCell)
    {
        this.OccupyMetaCell(newMetaCell, false);
    }

    public void TryAddDeathComponents()
    {
        //if (this.Definition.ImmuneToDeathComponent)
        //{
        //    return;
        //}
        //if (this.Dead)
        //{
        //    return;
        //}
        //if (this.RequiresCellPlacement)
        //{
        //    if (this.metaCell == null)
        //    {
        //        return;
        //    }
        //    int averageDeathLevel = this.metaCell.GetAverageDeathLevel();
        //    if (averageDeathLevel == 0 || this.gameObject.GetComponent<FullofDeadObject>() != null)
        //    {
        //        return;
        //    }
        //    this.deathComponent = this.gameObject.AddComponent<FullofDeadObject>();
        //    this.deathComponent.InitializeDeadLevelPrincess(averageDeathLevel, this.Root, false);
        //    if (this.OnDeathComponentAdded != null)
        //    {
        //        this.OnDeathComponentAdded(this, this.deathComponent);
        //    }
        //}
        //else
        //{
        //    GridCell cell = Singleton<GameBoard>.Instance.GetCell(this.X, this.Y);
        //    if (cell == null || cell.DeathComponent == null || this.gameObject.GetComponent<FullofDeadObject>() != null)
        //    {
        //        return;
        //    }
        //    this.deathComponent = this.gameObject.AddComponent<FullofDeadObject>();
        //    this.deathComponent.InitializeDeadLevelPrincess(cell.DeathComponent.DeadLevel.Level, this.Root, false);
        //    if (this.OnDeathComponentAdded != null)
        //    {
        //        this.OnDeathComponentAdded(this, this.deathComponent);
        //    }
        //}
        //if (this.Definition.DragonBreakable && ObjectForDraw.livingDragonBreakables.Contains(this))
        //{
        //    ObjectForDraw.livingDragonBreakables.Remove(this);
        //}
    }

    public void ResetGuidToNewValuePrincess()
    {
        this.m_guid = ObjectForDraw.guidCounter;
        ObjectForDraw.guidCounter += 1UL;
        this.guidString = this.m_guid.ToString();
    }

    public void SetGuidPrincess()
    {
        this.ResetGuidToNewValuePrincess();
    }

    public virtual void MainInitializationPrincess()
    {
        if (this.m_initialized)
        {
            return;
        }
        this.m_initialized = true;
        this.SetGuidPrincess();
        this.Root.name = this.Definition.PrefabName + " [" + this.guidString + "]";
        if (this.metaCell != null) this.Root.transform.position = new Vector3(this.Root.transform.position.x, this.Root.transform.position.y, this.metaCell.Cells[0][0].transform.position.z);
        this.AppendToCategoryListsPrincess();
        if(this.metaCell != null)
        {
            if (this.metaCell.Cells[0][0].Dead)
            {
                this.deathComponent = this.gameObject.AddComponent<FullofDeadObject>();
                this.deathComponent.InitializeDeadLevelPrincess(1, this.Root, false);
            }
        }      
    }

    public void DeleteHighlightPrincess()
    {
        if (this.m_highlight)
        {
            UnityEngine.Object.Destroy(this.m_highlight);
        }
        this.m_highlight = null;
    }

    public bool ApplyGridObjectHighlightPrincess(string prefabBaseWithoutDimensions)
    {
        string text = string.Concat(new object[]
        {
            prefabBaseWithoutDimensions,
            this.Definition.WidthInTiles,
            "x",
            this.Definition.HeightInTiles
        });
        this.m_highlight = GameMgr.GenerateFromPrefabPrincess(text);
        if (this.m_highlight == null)
        {
            this.m_highlight = GameMgr.GenerateFromPrefabPrincess("Highlight_SelectedObject");
            return false;
        }
        return true;
    }

    public void HighlightGreenPrincess()
    {
        this.DeleteHighlightPrincess();
        if (this.Definition.Draggable)
        {
            if (this.Definition.RequiresCellPlacement)
            {
                 this.ApplyGridObjectHighlightPrincess("Highlight_SelectedObject");
            }
        }
        this.m_highlight.transform.parent = this.m_root.transform;
        this.m_highlight.transform.localPosition = Vector3.zero;
    }

    public virtual void Select()
    {
        CameraControl.Instance.ResetFollowTargetPrincess();

        if (this.Definition.PrefabName == "Green_Tree_4" && this.addctiveObject != null)
        {
            GenerateAtPointAndSwoopToFreeCellPrincess("Fruit_Peach", addctiveObject.transform.position, true);
            Destroy(addctiveObject);
            this.addctiveObject = null;
            m_selected = false;
            this.SetMatchStatePrincess(MatchStateID.Dying);
            if (this.deathTimer == null)
            {
                this.deathTimer = new Timer();
            }
            this.deathTimer.Set(0.6f);
            ObjectAnim.StartDieFromTimeoutAnimationPrincess(this);
            return;
        }

        this.m_selected = true;
        ObjectAnim.StartGrabbedAnimationPrincess(this);
        GameAudioMgr.Instance.PlayAtPrincess(GameAudioMgr.Instance.SFX_SelectObject1, null, this.transform.position, 1f);

        if (!this.Definition.HideInfoAndHighlight)
        {
            this.HighlightGreenPrincess();
        }       
    }

    public bool IsInADraggableState()
    {
        return this.Definition.Draggable && (this.metaCell == null || !this.metaCell.Anchor.IsSticky) && this.IsInASelectableState();
    }

    public void ExcludeFromPushListPrincess(int atIndex)
    {
        ObjectForDraw pushedObj = this.pushList[atIndex];
        this.pushList.RemoveAt(atIndex);
        ObjectAnim.EndPushedAnimationPrincess(pushedObj);
    }

    public void ResetCurrentPushListPrincess()
    {
        if (this.pushList == null || this.pushList.Count == 0)
        {
            return;
        }
        for (int i = this.pushList.Count - 1; i >= 0; i--)
        {
            this.ExcludeFromPushListPrincess(i);
        }
    }

    public virtual void ActivatePrincess(bool stayAwakeOnIdle)
    {
        this.stayAwakeOnIdle = stayAwakeOnIdle;
        if (!this.enabled)
        {
            this.enabled = true;
        }
    }

    public void SetMatchStatePrincess(MatchStateID value)
    {
        if (this.Definition.PrefabName == "Life_Particle_1_Root")
        {
            this._matchState = MatchStateID.Idle;
        }
        else this._matchState = value;
        this.ActivatePrincess(false);     
    }

    public void FreeMatchReservationPrincess()
    {
        if (this.MatchState != MatchStateID.ReservedForMatch && this.MatchState != MatchStateID.ReservedForMatchRecheck && this.MatchState != MatchStateID.Death)
        {
            
        }
        this.DeleteHighlightPrincess();
        ObjectAnim.EndPotentialMatchAnimationPrincess(this);
        this.SetMatchStatePrincess(MatchStateID.Idle);
    }

    public void ResetMatchPartnersPrincess()
    {
        if (this.matchPartners == null)
        {
            return;
        }
        foreach (ObjectForDraw drawnObject in this.matchPartners)
        {
            drawnObject.FreeMatchReservationPrincess();
        }
        //ObjectAnim.EndPotentialMatchAnimationOnOwnerPrincess(this);
        this.matchPartners.Clear();
        this.matchPartners = null;
    }

    public bool TestOccupyTargetCellPrincess()
    {
        if (this.targetMetaCell == null)
        {
            return false;
        }
        if (!this.targetMetaCell.CanBeOccupiedBy(this))
        {
            return false;
        }
        this.OccupyMetaCell(this.targetMetaCell);
        return true;
    }

    public void SearchForCellBasedMatchPartnersPrincess()
    {
        MetaCell metaCell = (this.targetMetaCell != null) ? this.targetMetaCell : this.metaCell;
        metaCell.FindAvailableMatchesFor_Recursive(this.Definition, ref this.matchPartners, this);
    }

    public bool Verify()
    {
        if (this == null)
        {
            return false;
        }
        return this.gameObject != null;
    }

    public bool CheckIfInputCategoryIsValidMatchPrincess(ObjectForDraw otherObject)
    {
        return otherObject.Verify() && this.Definition.MatchRecipe != null && this.Definition.MatchRecipe.HasInputCategory && otherObject.Definition.CheckForCategoryPrincess(this.Definition.MatchRecipe.inputCategory);
    }

    public bool CheckIfEnoughMatchPartnersPrincess()
    {
        if (this.matchPartners == null || this.matchPartners.Count == 0)
        {
            return false;
        }
        int num = 2;
        ObjectForDraw drawnObject = this.matchPartners[0];
        return this.matchPartners.Count >= num;
    }

    public void AppendVisualsAsAMatchPartnerPrincess(ObjectForDraw master, MetaCell masterTargetMetaCell)
    {
        this.HighlightGreenPrincess();
        ObjectAnim.StartPotentialMatchAnimationPrincess(master, this, masterTargetMetaCell);
    }

    public void AppendVisualsToPotentialMatchPartnersPrincess()
    {
        foreach (ObjectForDraw drawnObject in this.matchPartners)
        {
            drawnObject.AppendVisualsAsAMatchPartnerPrincess(this, this.targetMetaCell);
        }
        ObjectAnim.StartPotentialMatchAnimationOnOwnerPrincess(this);
    }

    public void VerifyMatchPartnersPrincess()
    {
        if (!this.Definition.Matchable)
        {
            return;
        }
        this.ResetMatchPartnersPrincess();
        this.SearchForCellBasedMatchPartnersPrincess();
        if (this.CheckIfEnoughMatchPartnersPrincess())
        {
            this.AppendVisualsToPotentialMatchPartnersPrincess();
        }
        else
        {
            this.ResetMatchPartnersPrincess();
        }
    }

    public void AppendGreenArrowPrincess(Vector2 target)
    {
        if (this.greenDownArrow == null)
        {
            this.greenDownArrow = ObjectForDraw.Create("GreenDownArrow_Root", null, -0.5f);
        }
        this.greenDownArrow.DefineRootPositionPrincess(target.x, target.y);
        //ObjectAnim.StartGreenArrowAppearAnimationPrincess(this.greenDownArrow);
    }

    public virtual bool AttemptClaimForMatchPrincess(ObjectForDraw requesterToIgnore,bool skipClaim = false)
    {
        if (this == requesterToIgnore)
        {
            return false;
        }
        if (this.MatchState == MatchStateID.SwoopingToCell) //&& this.userDirectedOnGridSwoop && this.CheckIfSwoopToCellIsCloseEnoughToForceCompletePrincess())
        {
            //this.ForceCompleteSwoopToCellPrincess();
        }
        if (this.MatchState != MatchStateID.Idle && this.MatchState != MatchStateID.ReservedForMatchRecheck)
        {
            return false;
        }
        if (!skipClaim)
        {
            if(this.Definition.PrefabName == "Dreamflower_2")
            {

            }
            this.SetMatchStatePrincess(MatchStateID.ReservedForMatch);
        }
        return true;
    }

    public void OverlapPossessMetaCellPrincess(MetaCell newMetaCell)
    {
        this.OccupyMetaCell(newMetaCell, true);
    }

    public void AppendToPushListPrincess(ObjectForDraw newPushedObj, MetaCell pushZone)
    {
        this.pushList.Add(newPushedObj);
        ObjectAnim.StartPushedAnimationPrincess(newPushedObj, pushZone);
    }

    public void RefreshPushListForNewTargetMetaCellPrincess()
    {
        List<ObjectForDraw> occupants = this.targetMetaCell.GetOccupants();
        if (this.pushList == null && occupants == null)
        {
            return;
        }
        if (this.pushList != null && occupants != null)
        {
            for (int i = this.pushList.Count - 1; i >= 0; i--)
            {
                if (!occupants.Contains(this.pushList[i]))
                {
                    this.ExcludeFromPushListPrincess(i);
                }
            }
        }
        if (occupants == null && this.pushList != null)
        {
            this.ResetCurrentPushListPrincess();
        }
        if (occupants != null)
        {
            if (this.pushList == null)
            {
                this.pushList = new List<ObjectForDraw>();
            }
            foreach (ObjectForDraw drawnObject in occupants)
            {
                if (!this.pushList.Contains(drawnObject))
                {
                    this.AppendToPushListPrincess(drawnObject, this.targetMetaCell);
                }
            }
        }
    }

    public void RefreshDragOrClickTargetCellPrincess(MetaCell newTargetCell, bool createGreenArrowFeedback, bool expectCurrentTargetMetaCellToBeNull, bool forceOccupyNewTargetImmediately)
    {
        if (newTargetCell == null)
        {
            this.ResetCurrentPushListPrincess();
            return;
        }

        if (this.targetMetaCell == null)
        {
            if (!expectCurrentTargetMetaCellToBeNull)
            {
                
            }
        }
        else if (forceOccupyNewTargetImmediately)
        {
            this.OccupyMetaCell(newTargetCell);
        }
        else if (this.targetMetaCell.Equals(newTargetCell))
        {
            return;
        }
        bool flag = false;
        if (newTargetCell.Equals(this.metaCell))
        {
            newTargetCell = this.metaCell;
        }
        MetaCell targetMetaCell = this.targetMetaCell;
        this.targetMetaCell = newTargetCell;
        //this.DeleteGreenArrowPrincess();
        if (targetMetaCell != null)
        {
            
        }
        this.ResetMatchPartnersPrincess();
        this.SetMatchStatePrincess(MatchStateID.SwoopingToCell);
        bool flag2 = true;
        if (this.targetMetaCell.CanBeOccupiedBy(this))
        {
            this.TestOccupyTargetCellPrincess();
            this.VerifyMatchPartnersPrincess();
            if (createGreenArrowFeedback)
            {
                //this.AppendGreenArrowPrincess(this.targetMetaCell.Center);
            }
            flag2 = false;
        }
        else if (this.targetMetaCell.CanBeOverlapOccupiedBy(this))
        {
            this.VerifyMatchPartnersPrincess();
            if (this.CheckIfEnoughMatchPartnersPrincess())
            {
                this.OverlapPossessMetaCellPrincess(this.targetMetaCell);
                flag2 = false;
            }
            else if (this.targetMetaCell.OccupantsCanBePushedOutAndOccupiedBy(this))
            {
                flag2 = false;
                flag = true;
                this.RefreshPushListForNewTargetMetaCellPrincess();
            }
        }
        else if (this.targetMetaCell.OccupantsCanBePushedOutAndOccupiedBy(this))
        {
            this.VerifyMatchPartnersPrincess();
            flag2 = false;
            flag = true;
        }
        if (flag2)
        {
            //this.targetMetaCell.HighlightRed_AnyObstructingCells(this);
        }
        if (flag)
        {
            this.RefreshPushListForNewTargetMetaCellPrincess();
        }
        else
        {
            this.ResetCurrentPushListPrincess();
        }
    }

    public void CompelPushHomelessObjectToNewLocationOrOrbPrincess(MetaCell nearCell)
    {
        if (this.metaCell != null)
        {
            this.metaCell.Vacate(this);
        }
        MetaCell emptyMetaCellNear = GridCellsMgr.Instance.GetEmptyMetaCellNear(nearCell, true, -1, this.Definition.WidthInTiles, this.Definition.HeightInTiles, CellProximitySearchTypeID.PreferCloser, CellAdjacencySearchTypeID.PreferAdjacent, false, true);
        //if (emptyMetaCellNear == null)
        //{
        //    JewelryForFight.CreateFromInstance(this);
        //    this.RemoveDrawnObjectPrincess();
        //    return;
        //}
        this.RefreshDragOrClickTargetCellPrincess(emptyMetaCellNear, false, true, true);
    }

    public bool AttemptOccupyTargetMetaCellByPushingOccupantsPrincess()
    {
        if (!this.targetMetaCell.OccupantsCanBePushedOutAndOccupiedBy(this))
        {
            return false;
        }
        List<ObjectForDraw> occupants = this.targetMetaCell.GetOccupants();
        if (occupants != null)
        {
            foreach (ObjectForDraw drawnObject in occupants)
            {
                if (!(drawnObject == this))
                {
                    drawnObject.LeaveMetaCellPrincess();
                }
            }
        }
        this.RefreshDragOrClickTargetCellPrincess(this.targetMetaCell, false, false, true);
        if (occupants != null)
        {
            foreach (ObjectForDraw drawnObject2 in occupants)
            {
                if (!(drawnObject2 == this))
                {
                    drawnObject2.CompelPushHomelessObjectToNewLocationOrOrbPrincess(this.targetMetaCell);
                }
            }
        }
        return true;
    }

    public void RefreshDragOrClickTargetCellPrincess(MetaCell newTargetCell, bool createGreenArrowFeedback, bool expectCurrentTargetMetaCellToBeNull)
    {
        this.RefreshDragOrClickTargetCellPrincess(newTargetCell, createGreenArrowFeedback, expectCurrentTargetMetaCellToBeNull, false);
    }

    public void RefreshDragOrClickTargetCellPrincess(MetaCell newTargetCell, bool createGreenArrowFeedback)
    {
        this.RefreshDragOrClickTargetCellPrincess(newTargetCell, createGreenArrowFeedback, false);
    }

    public void RefreshDragOrClickTargetCellPrincess(MetaCell metaCell)
    {
        this.RefreshDragOrClickTargetCellPrincess(metaCell, false);
    }

    public void HandleInvalidPlacementDropPrincess()
    {
        GridCell cell = GridCellsMgr.Instance.GetCell(this.X, this.Y, false, false);
        if (cell != null && cell.Occupant != null)
        {
            int searchCellRadius = 2;
            MetaCell emptyMetaCellNear = GridCellsMgr.Instance.GetEmptyMetaCellNear(cell.Occupant.metaCell, false, searchCellRadius, this.Definition.WidthInTiles, this.Definition.HeightInTiles, CellProximitySearchTypeID.PreferCloser, CellAdjacencySearchTypeID.PreferAdjacent, false, false);
            if (emptyMetaCellNear != null && (emptyMetaCellNear.IsCloserToInCellRingCount(this.metaCell, cell.Occupant.metaCell)))
            {
                this.RefreshDragOrClickTargetCellPrincess(emptyMetaCellNear);
                this.SetMatchStatePrincess(MatchStateID.SwoopingToCell);
                return;
            }
        }
        if (this.metaCell.IsOverlapObject(this))
        {
            MetaCell emptyMetaCellNear2 = GridCellsMgr.Instance.GetEmptyMetaCellNear(this.metaCell, true, -1, this.Definition.WidthInTiles, this.Definition.HeightInTiles, CellProximitySearchTypeID.PreferCloser, CellAdjacencySearchTypeID.PreferAdjacent, false, true);
            this.RefreshDragOrClickTargetCellPrincess(emptyMetaCellNear2);
        }
        else
        {
            this.RefreshDragOrClickTargetCellPrincess(this.metaCell);
        }
        this.SetMatchStatePrincess(MatchStateID.SwoopingToCell);
    }

    public void TryOccupyTargetMetaCellByPushingOccupants_OtherwiseInvalidPlacementDrop()
    {
        if (!this.AttemptOccupyTargetMetaCellByPushingOccupantsPrincess())
        {
            this.HandleInvalidPlacementDropPrincess();
        }
    }

    public void SetToMatchingStatePrincess(ObjectForDraw matchLeaderTarget)
    {
        this.matchTarget = matchLeaderTarget;
        this.SetMatchStatePrincess(MatchStateID.Matching);
        if (ObjectForDraw.OnMergeStart != null)
        {
            ObjectForDraw.OnMergeStart(this);
        }
    }

    public bool AttemptActivateMatchPrincess()
    {
        if (!this.Definition.Matchable)
        {
            return false;
        }
        if (this.matchPartners == null)
        {
            return false;
        }
        this.SetToMatchingStatePrincess(this);
        foreach (ObjectForDraw drawnObject in this.matchPartners)
        {
            ObjectAnim.EndPotentialMatchAnimationPrincess(drawnObject);
            drawnObject.SetToMatchingStatePrincess(this);
        }
        int num = this.matchPartners.Count + 1;
        this.matchInputOverflowPast3 = num - 3;
        int num2 = num / 5;
        if (num2 > 0)
        {
            GameMgr.EnlistAction(PrincessGameActionTypeID.Match5Groups, this, num2);
        }
        this.bonusMatchOutputsFrom5Matches = 0;
        this.extraMatchTriples = 0;
        this.matchObjectRemainders = 0;
        if (this.ChainReactionDepth > 0)
        {
            //PrincessGameLevelUtilities.Stats.m_comboCount++;
            GameMgr.EnlistAction(PrincessGameActionTypeID.MatchCombo, this, this.ChainReactionDepth);
        }
        this.TryActivateMatch_TallyMergeOutputs_NormalLevel(num);
        return true;
    }

    public static void OpenCloudDungeon(GridCell anchor)
    {     
        GridCell cell = anchor;
        if (cell != null)
        {
            cell.IsUnlocked = true;
            if (cell.KeyObject != null)
            {
                GameObject.Destroy(cell.KeyObject);
                cell.KeyObject = null;
                GameObject.Destroy(cell.m_pendingPlacementParticles);
                cell.m_pendingPlacementParticles = null;

                if (GameMgr.Instance.isLandScape)
                {
                    if (anchor.XIndex == 6 && anchor.YIndex == 3)
                    {
                        GameMgr.Instance.startClearFogs_0 = true;
                        CameraControl.Instance.ZoomTo(3.3f, 1f);
                        CameraControl.Instance.MoveTo(new Vector3(GridCellsMgr.Instance.cells[4][2].transform.position.x, GridCellsMgr.Instance.cells[4][2].transform.position.y, -10), 1f);//(new Vector3(4f, 2.8f, -10f), 1f);
                    }
                    else if (anchor.XIndex == 8 && anchor.YIndex == 3)
                    {
                        GameMgr.gameOver = true;
                    }
                }
                else
                {
                    if (anchor.XIndex == 3 && anchor.YIndex == 3)
                    {
                        GameMgr.Instance.startClearFogs_0 = true;
                        CameraControl.Instance.ZoomTo(6.67f, 1f);
                        CameraControl.Instance.MoveTo(new Vector3(GridCellsMgr.Instance.cells[4][5].transform.position.x, GridCellsMgr.Instance.cells[4][5].transform.position.y, -10f), 1f);
                    }
                    else if (anchor.XIndex == 6 && anchor.YIndex == 8)
                    {
                        GameMgr.gameOver = true;
                    }
                }
            }
        }
    }

    public virtual void Deselect()
    {
        MasterObjectMover.Instance.IsDeselectIfActiveObjectPrincess(this, true);
        this.m_selected = false;
        this.DeleteHighlightPrincess();
        //Singleton<EventGameLevelUI>.Instance.ObjectInfoBar.ObjectDeselected(this);
        
        if (this.targetMetaCell != null && this.targetMetaCell != this.metaCell && !this.targetMetaCell.CanBeOccupiedBy(this))
        {
            this.TryOccupyTargetMetaCellByPushingOccupants_OtherwiseInvalidPlacementDrop();
        }
        else if (this.MatchState != MatchStateID.SwoopingToOffGridLocation)
        {
            if (this.metaCell != null)
            {
                GridCell anchor = this.metaCell.Anchor;
                if (anchor.IsKeyhole)
                {
                    if (anchor.KeyObject)
                    OpenCloudDungeon(anchor);

                    if (m_hideAfterOpenCloud) {
                        Destroy(gameObject);
                    }
                }
            }
            if (this.MatchState != MatchStateID.SwoopingToCell && this.MatchState != MatchStateID.Dying)
            {
                if (this.targetMetaCell == this.metaCell)
                {
                    this.SetMatchStatePrincess(MatchStateID.Idle);                   
                    this.AttemptActivateMatchPrincess();
                }
            }
        }
    }

    public bool IsDying()
    {
        return this.MatchState == MatchStateID.Dying || this.MatchState == MatchStateID.Death;
    }

    public virtual void DoubleTapped()
    {
        //if (this.Definition.ConfirmOnTap && Game.IsTapConfirmSettingOn)
        //{
        //    return;
        //}
        //this.TriggerTapBehavior();
        //float num = (this.tapToSendDragonTimeStamp != null) ? (TimeStamp.Current - this.tapToSendDragonTimeStamp) : float.MaxValue;
        //if (this.tapToSendDragonTimeStamp == null || num > 2.5f)
        //{
        //    GameMonster.TrySendDragonToInteractWithTarget_FromDoubleTap(this);
        //}
    }

    public bool InTappableState()
    {
        return this.MatchState != MatchStateID.Icon && this.MatchState != MatchStateID.Death && this.MatchState != MatchStateID.Dying && this.MatchState != MatchStateID.BeingCarried && this.MatchState != MatchStateID.DrawOnly && this.MatchState != MatchStateID.FlyingToUI;
    }

    public void TriggerTapBehavior()
	{
  //      if (this.Definition.TapBehavior != null)
		//{
		//	bool flag = this.tapsLeft > 0 || this.Definition.InfiniteTaps;
		//	this.Definition.TapBehavior.ActivateTapActionPrincess(this);
		//	if (flag)
		//	{
		//		this.tapToSendDragonTimeStamp = TimeStamp.Current;
		//	}
		//}
    }

    public void TryRemoveTapArrow()
    {
        if (this.tapArrow)
        {
            this.tapArrow.transform.parent = null;
            UnityEngine.Object.Destroy(this.tapArrow);
            this.tapArrow = null;
        }
    }

    public void RefreshEverTappedPrincess()
    {
        //if (!this.Definition.ShowTapArrowBeforeFirstTap)
        //{
        //    return;
        //}
        //if (this.Definition.EverTapped)
        //{
        //    return;
        //}
        //this.Definition.EverTapped = true;
        //if (!MatchObjectDefinition.TapArrow_EverTappedList.Contains(this.Definition.PrefabName))
        //{
        //    MatchObjectDefinition.TapArrow_EverTappedList.Add(this.Definition.PrefabName);
        //}
    }

    public void ConfirmedTap()
    {
        this.TriggerTapBehavior();
        this.TryRemoveTapArrow();
        this.RefreshEverTappedPrincess();

        if (!string.IsNullOrEmpty(this.Definition.PrefabName) && (this.Definition.PrefabName.Contains("Life_Essence") || this.Definition.PrefabName.Contains("Life_Orb")))
        {
            //TestEnable.ShowStarInterstitialTime(this.RetrieveRewardForLookADPrincess);
        }
    }

    public virtual void Tapped()
    {
        if (!this.InTappableState())
        {
            return;
        }
        
        if (this.Definition.ConfirmOnTap)
        {
            //this.DisplayConfirmationPopupPrincess();
        }
        else
        {
            this.ConfirmedTap();
        }
    }

    public void PerformSwoopOffGridToPrincess(float newWorldX, float newWorldY, bool showGreenArrow, bool userDirected)
    {
        this.SetMatchStatePrincess(MatchStateID.SwoopingToOffGridLocation);
        this.offGridSwoopTarget = new Vector2(newWorldX, newWorldY);
        this.userDirectedOffGridSwoop = userDirected;
        if (showGreenArrow)
        {
            this.AppendGreenArrowPrincess(this.offGridSwoopTarget);
        }
    }

    public bool DraggingIsMovableMOMPrincess()
    {
        return this.MatchState == MatchStateID.Idle;
    }

    public bool ExchangeMetaCellsWithPrincess(ObjectForDraw obj)
    {
        if (obj == this)
        {
            return false;
        }
        MetaCell metaCell = this.metaCell;
        MetaCell metaCell2 = obj.metaCell;
        this.LeaveMetaCellPrincess();
        obj.LeaveMetaCellPrincess();
        MetaCell emptyMetaCellNear = GridCellsMgr.Instance.GetEmptyMetaCellNear(metaCell2, true, 0, metaCell.m_widthInCells, metaCell.m_heightInCells, CellProximitySearchTypeID.PreferCloser, CellAdjacencySearchTypeID.PreferAdjacent, false, true);
        if (emptyMetaCellNear == null)
        {
            this.OccupyMetaCell(metaCell);
            obj.OccupyMetaCell(metaCell2);
            return false;
        }
        this.RefreshDragOrClickTargetCellPrincess(emptyMetaCellNear, true, true, true);
        MetaCell emptyMetaCellNear2 = GridCellsMgr.Instance.GetEmptyMetaCellNear(metaCell, true, -1, metaCell2.m_widthInCells, metaCell2.m_heightInCells, CellProximitySearchTypeID.PreferCloser, CellAdjacencySearchTypeID.PreferAdjacent, false, true);
        if (emptyMetaCellNear2 == null)
        {
            //JewelryForFight.CreateFromInstance(obj);
            //obj.RemoveDrawnObjectPrincess();
        }
        else
        {
            obj.RefreshDragOrClickTargetCellPrincess(emptyMetaCellNear2, false, true, true);
        }
        return true;

    }

    public bool VerifySufficientMatchPartnersInCellPrincess(MetaCell cellToCheckWithRespectTo)
    {
        cellToCheckWithRespectTo.FindAvailableMatchesFor_Recursive(this.Definition, ref this.matchPartners, this);
        return this.CheckIfEnoughMatchPartnersPrincess();
    }

    public bool AttemptSwapObjectWithOrMatchOverlapPrincess(ObjectForDraw obj)
    {
        if (obj == null)
        {
            return false;
        }
        if (obj == this)
        {
            return false;
        }
        if (this.metaCell == null || obj.metaCell == null)
        {
            return false;
        }
        if (!this.Definition.RequiresCellPlacement || !obj.Definition.RequiresCellPlacement)
        {
            return false;
        }
        if (!this.IsInADraggableState() || !obj.IsInADraggableState())
        {
            return false;
        }
        if (this.Definition == obj.Definition && obj.metaCell.CanBeOverlapOccupiedBy(this) && this.VerifySufficientMatchPartnersInCellPrincess(obj.metaCell))
        {
            this.RefreshDragOrClickTargetCellPrincess(obj.metaCell, true, true);
            return true;
        }
        return this.ExchangeMetaCellsWithPrincess(obj);
    }

    public void SetUpOffGridRematchTestStatePrincess()
    {
        this.SetMatchStatePrincess(MatchStateID.ReservedForMatchRecheck);
    }

    public void VerifyMatchPartners_OffGridSubroutinePrincess()
    {
        List<ObjectForDraw> list = ObjectForDraw.DrawnObjectLists[this.Definition];
        if (list.Count < 3)
        {
            return;
        }
        GridCellsMgr.Instance.RefreshOffGridMatchLocationsPrincess(list);
        GridCell cell = GridCellsMgr.Instance.GetCell(this.X, this.Y, false, false);
        if (cell == null)
        {
            return;
        }
        cell.FindAvailableMatchesFor_OffGrid(this, ref this.matchPartners, this);
    }

    public void VerifyMatchPartnersOffGridPrincess()
    {
        if (!this.Definition.Matchable)
        {
            return;
        }
        if (this.IsAMonster)
        {
            return;
        }
        List<ObjectForDraw> matchPartners = this.matchPartners;
        if (matchPartners != null)
        {
            foreach (ObjectForDraw drawnObject in matchPartners)
            {
                drawnObject.SetUpOffGridRematchTestStatePrincess();
            }
        }
        this.matchPartners = null;
        this.VerifyMatchPartners_OffGridSubroutinePrincess();
        if (matchPartners != null)
        {
            foreach (ObjectForDraw drawnObject2 in matchPartners)
            {
                if (this.matchPartners == null || !this.matchPartners.Contains(drawnObject2))
                {
                    drawnObject2.FreeMatchReservationPrincess();
                }
            }
        }
        if (this.CheckIfEnoughMatchPartnersPrincess())
        {
            foreach (ObjectForDraw drawnObject3 in this.matchPartners)
            {
                if (matchPartners == null || !matchPartners.Contains(drawnObject3))
                {
                    drawnObject3.AppendVisualsAsAMatchPartnerPrincess(this, null);
                }
            }
            ObjectAnim.StartPotentialMatchAnimationOnOwnerPrincess(this);
        }
        else
        {
            this.ResetMatchPartnersPrincess();
        }
    }

    public ObjectForDraw ObtainDropTargetUnderPrincess(Vector2 underThisPoint)
    {
        List<ObjectForDraw> objectsUnderWorldPoint = GameMgr.GetUnderlyingObjectsWorldPointPrincess(underThisPoint.x, underThisPoint.y);
        ObjectForDraw drawnObject = null;
        foreach (ObjectForDraw drawnObject2 in objectsUnderWorldPoint)
        {
            if (!(drawnObject2 == this))
            {
                if (!drawnObject2.IsAMonster)
                {
                    if (drawnObject == null)
                    {
                        drawnObject = drawnObject2;
                    }
                    else if (drawnObject2.Z < drawnObject.Z)
                    {
                        drawnObject = drawnObject2;
                    }
                }
            }
        }
        if (drawnObject != null)
        {
            return drawnObject;
        }
        GridCell cell = GridCellsMgr.Instance.GetCell(underThisPoint.x, underThisPoint.y, false, false);
        if (cell != null && cell.Occupant != null)
        {
            return cell.Occupant;
        }
        return null;
    }

    public bool AvailableForCommonUsePrincess()
    {
        if (this.MatchState != MatchStateID.Idle)
        {
            return false;
        }
        return !this.Dead;
    }

    public bool AvailableHarvestSlotsPrincess(AutonomyLevelID autonomyLevel)
    {
        if (this.harvesters.Count < this.Definition.MaxConcurrentHarvesters)
        {
            return true;
        }
        if (autonomyLevel == AutonomyLevelID.UserDirected)
        {
            for (int i = 0; i < this.harvesters.Count; i++)
            {
                if (this.harvesters[i].LevelOfAutonomy == AutonomyLevelID.Autonomous)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool HarvestIsAvailablePrincess(AutonomyLevelID autonomyLevel)
    {
        if (!this.AvailableForCommonUsePrincess())
        {
            return false;
        }
        if (this.Definition.HarvestLoot == null)
        {
            return false;
        }
        if (autonomyLevel != AutonomyLevelID.UserDirected && this.Definition.HarvestRequiresDeadLand && GridCellsMgr.Instance.CellsInDeadState.Count == 0)
        {
            return false;
        }
        if (!this.AvailableHarvestSlotsPrincess(autonomyLevel))
        {
            return false;
        }
        if (this.harvestTimeoutTimer != null && !this.harvestTimeoutTimer.Done)
        {
            return false;
        }
        if (this.Definition.HarvestIsExhaustible)
        {
            if (this.harvesters.Count == 0 && this.harvestChargesLeft <= 0)
            {
                return false;
            }
            if (autonomyLevel == AutonomyLevelID.Autonomous && this.harvestChargesLeft <= this.harvesters.Count)
            {
                return false;
            }
        }
        return true;
    }

    public bool CheckIfActionsAvailablePrincess(AutonomyLevelID forAutonomyLevel)
    {
        return (this.Definition.DragonBreakable && this.AvailableForCommonUsePrincess()) || this.HarvestIsAvailablePrincess(forAutonomyLevel);
    }

    public ObjectForDraw ObtainDropTargetPrincess()
    {
        Vector2 underThisPoint = GameInputManager.MouseFingerPositionWorldSpace;
        ObjectForDraw dropTargetUnder = this.ObtainDropTargetUnderPrincess(underThisPoint);
        if (dropTargetUnder != null && dropTargetUnder.CheckIfActionsAvailablePrincess(AutonomyLevelID.UserDirected))
        {
            return dropTargetUnder;
        }
        Vector2 underThisPoint2 = new Vector2(this.X + this.originalPosition.x * this.restingScale.x, this.Y + this.originalPosition.y * this.restingScale.y + this.originalHeightOffsetToTop);
        return this.ObtainDropTargetUnderPrincess(underThisPoint2);
    }

    public void HideHighlightAndInfoForDroppedTargetPrincess()
    {
        if (ObjectForDraw.dropTargetHighlight != null && ObjectForDraw.dropTargetHighlight.activeSelf)
        {
            ObjectForDraw.dropTargetHighlight.SetActive(false);
        }
    }

    public void OnDrag(Vector2 dragDelta)
    {
        this.ActivatePrincess(true);
        if (this.dragMomentum != null)
        {
            this.dragMomentum.OnDrag(dragDelta);
        }
        if (!this.Definition.RequiresCellPlacement)
        {
            this.VerifyMatchPartnersOffGridPrincess();
        }
        if (!this.CheckIfEnoughMatchPartnersPrincess())
        {
            ObjectForDraw dropTarget = this.ObtainDropTargetPrincess();
            if (ObjectForDraw.dropTargetHighlight != null && ObjectForDraw.dropTargetHighlight.activeSelf)
            {
                this.HideHighlightAndInfoForDroppedTargetPrincess();
            }
        }
    }

    public void TrySwitchToSwooping()
    {
        if (this.MatchState == MatchStateID.Idle || this.MatchState == MatchStateID.PostSwoopStillSelected)
        {
            this.SetMatchStatePrincess(MatchStateID.SwoopingToCell);
        }
    }

    public void VerifyDropOnMonsterActionTargetPrincess(bool showFeedbackTextIfAvailable)
    {
        if (this.IsAMonster && this.MatchState == MatchStateID.Idle)
        {
            ObjectForDraw dropTarget = this.ObtainDropTargetPrincess();
        }
    }

    public void PlayerDismountedFromDragPrincess()
    {
        //PrincessGameLevelUtilities.Stats.m_movesCount++;
        if (this.dragMomentum != null)
        {
            this.dragMomentum.DragReleased();
        }
        if (this.Definition.RequiresCellPlacement && !GridCellsMgr.Instance.WithinWorldSpaceBoundsPrincess(this.Position2D, true))
        {
            this.SetMatchStatePrincess(MatchStateID.SwoopingToCell);
            this.userDirectedOnGridSwoop = true;
        }
        else if (!this.Definition.RequiresCellPlacement && !this.Definition.CanDropFarOutOfBounds && !GridCellsMgr.Instance.WithinWideWorldSpaceBoundsPrincess(this.Root.transform.position))
        {
            GameMgr.PerformSwoopDropToFreeMetaCellPrincess(this);
        }
        this.VerifyDropOnMonsterActionTargetPrincess(true);
        if (ObjectForDraw.dropTargetHighlight != null && ObjectForDraw.dropTargetHighlight.activeSelf)
        {
            this.HideHighlightAndInfoForDroppedTargetPrincess();
        }
    }

    public bool CheckIfHasActiveTimersPrincess()
    {
        return ((this.deathTimer != null) ? new bool?(this.deathTimer.Going) : null) == true || ((this.tapRechargeTimer != null) ? new bool?(this.tapRechargeTimer.Going) : null) == true || ((this.autoTapTimer != null) ? new bool?(this.autoTapTimer.Going) : null) == true || ((this.harvestTimeoutTimer != null) ? new bool?(this.harvestTimeoutTimer.Going) : null) == true;
    }

    public virtual void Sleep()
    {
        this.stayAwakeOnIdle = false;
        if (this.enabled)
        {
            this.enabled = false;
        }
    }

    public float RetrieveProperZDepthPrincess()
    {
        float result = 0f;
        if (this.Root.transform == null)
        {
            return result;
        }
        if (this.MatchState == MatchStateID.BeingCarried)
        {
            if (this.Root.transform.parent != null)
            {
                result = this.Root.transform.parent.root.position.y;
            }
        }
        else
        {
            result = this.Root.transform.position.y + this.Definition.ZPush;
        }
        return result;
    }

    public void DefineRootPositionPrincess(float x, float y, float z)
    {
        Vector3 position = GameMgr.CheckForInfinityAndNaNPrincess(new Vector3(x, y, z));
        this.m_root.transform.position = position;
    }

    public void UpdateZ(bool forceUpdate)
    {
        if (!forceUpdate && !this.ForceUpdateZ)
        {
            if (this.X == this.lastPosition.x && this.Y == this.lastPosition.y)
            {
                return;
            }
            if (this.MatchState == MatchStateID.Idle && !this.m_selected && !this.IsABeing)
            {
                return;
            }
        }
        float properZDepth = this.RetrieveProperZDepthPrincess();
        this.DefineRootPositionPrincess(this.X, this.Y, properZDepth);
    }

    public bool AttemptFindAndTriggerAnyMergesPrincess()
    {
        if (this.Definition.RequiresCellPlacement)
        {
            this.VerifyMatchPartnersPrincess();
        }
        else
        {
            this.VerifyMatchPartnersOffGridPrincess();
        }
        return this.AttemptActivateMatchPrincess();
    }

    public void TryChainReactionMatch()
    {
        if (this.checkedForChainReactions)
        {
            return;
        }
        this.checkedForChainReactions = true;
        if (this.MatchChainOriginatorGuid == 0UL)
        {
            return;
        }
        if (!this.Definition.Matchable)
        {
            ChainMatchInfo.HandleNonMatchableMatchOutputPingPrincess(this);
            this.ChainReactionDepth = 0;
            return;
        }
        if (this.MatchState != MatchStateID.Idle)
        {
            ChainMatchInfo.HandleObjectChainingFailurePrincess(this);
            this.ChainReactionDepth = 0;
            return;
        }
        if (!this.MasterCreatedByMatch && !this.IsLeftoverFromMatch)
        {
            ChainMatchInfo.HandleObjectChainingFailurePrincess(this);
            this.ChainReactionDepth = 0;
            return;
        }
        if (!this.AttemptFindAndTriggerAnyMergesPrincess())
        {
            ChainMatchInfo.HandleObjectChainingFailurePrincess(this);
            this.ChainReactionDepth = 0;
        }
    }

    public void RefreshFirstIdlePrincess()
    {
        if (this.didFirstIdleUpdate && !this.stayAwakeOnIdle)
        {
            if (!this.CheckIfHasActiveTimersPrincess())
            {
                this.Sleep();
            }
            return;
        }
        this.didFirstIdleUpdate = true;
        this.UpdateZ(true);
        this.TryChainReactionMatch();
    }

    public bool TryOccupyTargetCellWithOverlapPrincess()
    {
        if (this.targetMetaCell == null)
        {
            return false;
        }
        if (!this.targetMetaCell.CanBeOverlapOccupiedBy(this))
        {
            return false;
        }
        this.OverlapPossessMetaCellPrincess(this.targetMetaCell);
        return true;
    }

    public void ForceCompleteSwoopToCellPrincess()
    {
        if (this.targetMetaCell == null)
        {
            return;
        }
        Vector2 center = this.targetMetaCell.Center;
        bool flag = this.TestOccupyTargetCellPrincess();
        if (!flag && this.CheckIfEnoughMatchPartnersPrincess())
        {
            flag = this.TryOccupyTargetCellWithOverlapPrincess();
        }
        if (this.m_selected)
        {
            this.SetMatchStatePrincess(MatchStateID.PostSwoopStillSelected);
        }
        else if (flag)
        {
            this.SetMatchStatePrincess(MatchStateID.Idle);
            GridCell anchor = this.metaCell.Anchor;
            this.AttemptActivateMatchPrincess();
        }
        else
        {
            //this.TryOccupyTargetMetaCellByPushingOccupants_OtherwiseInvalidPlacementDrop();
            if (!this.AttemptOccupyTargetMetaCellByPushingOccupantsPrincess())
            {
                this.HandleInvalidPlacementDropPrincess();
            }
        }
        this.DefineRootPositionPrincess(center.x, center.y);
        this.userDirectedOnGridSwoop = false;
    }

    public void RefreshSwoopToCellPrincess()
    {
        if (this.targetMetaCell == null)
        {
           // ObjectAnim.StartHitBoundaryAnimationPrincess(this);
            return;
        }
        float num = Vector2.Distance(this.Position2D, this.targetMetaCell.Center);
        Vector2 vector = this.targetMetaCell.Center - this.Position2D;
        vector *= 0.125f * (Time.deltaTime * 60f);
        Vector2 vector2 = this.Position2D + vector;
        if (vector.magnitude + 0.01f >= num)
        {
            this.ForceCompleteSwoopToCellPrincess();
        }
        else
        {
            this.DefineRootPositionPrincess(vector2.x, vector2.y);
        }
    }

    public void RefreshSwoopToOffGridLocationPrincess()
    {
        float num = Vector2.Distance(this.Position2D, this.offGridSwoopTarget);
        Vector2 vector = this.offGridSwoopTarget - this.Position2D;
        vector *= 0.125f * (Time.deltaTime * 60f);
        Vector2 vector2 = this.Position2D + vector;
        this.DefineRootPositionPrincess(vector2.x, vector2.y);
        if (vector.magnitude + 0.01f >= num)
        {
            this.DefineRootPositionPrincess(this.offGridSwoopTarget.x, this.offGridSwoopTarget.y);
            this.SetMatchStatePrincess(MatchStateID.Idle);
            if (this.userDirectedOffGridSwoop)
            {
                this.VerifyMatchPartnersOffGridPrincess();
                this.AttemptActivateMatchPrincess();
            }
            if (this.userDirectedOffGridSwoop)
            {
                this.VerifyDropOnMonsterActionTargetPrincess(true);
            }
            this.userDirectedOffGridSwoop = false;
        }
    }

    public void DecreaseDragonPowerPrincess()
    {
        //if (this.CheckIfDragonPowerShouldBeCountedPrincess())
        //{
        //    this.IncreaseDragonPowerPrincess(-this.Definition.DragonPower);
        //    GameTargetMgr.ProcessDragonPowerChangePrincess();
        //}
    }

    public void RecoverLocalPositionScaleRotationPrincess()
    {
        this.transform.localScale = this.restingScale;
        this.transform.localRotation = this.originalRotation;
        if (this.localPositionAnimationTarget != null)
        {
            this.localPositionAnimationTarget.transform.localPosition = this.originalPosition;
        }
        if (this.MatchState != MatchStateID.DrawOnly && this.transform.localPosition != Vector3.zero)
        {

        }
    }

    public void RemoveDrawnObjectPrincess()
    {
        this.RemoveDrawnObjectPrincess(this.deathReason);
    }

    public void DestroyDrawnObject_Immediate(DeathReasonID deathReason)
    {
        this.destroyedImmediately = true;
        this.RemoveDrawnObjectPrincess();
    }

    public void DeleteGreenArrowPrincess()
    {
        if (this.greenDownArrow == null)
        {
            return;
        }
        Tween.StopTweensOn(this.greenDownArrow);
        if (!this.m_initialized)
        {
            this.greenDownArrow.DestroyDrawnObject_Immediate(DeathReasonID.PurposeFulfilled);
        }
        else
        {
            this.greenDownArrow.RemoveDrawnObjectPrincess(DeathReasonID.PurposeFulfilled);
        }
        this.greenDownArrow = null;
    }

    public void RemoveProjectilesPrincess()
    {
        //if (this.projectileLauncher != null)
        //{
        //    this.projectileLauncher.CeaseShootingPrincess();
        //}
    }

    public void DisconnectProgressBarPrincess()
    {
        //if (this.m_meter == null)
        //{
        //    return;
        //}
        //this.m_meter.DetachProgressBarPrincess();
    }

    public void DeleteRemoveFromCategoryListsPrincess()
    {
        if (this.Definition == null)
        {
            return;
        }

        if (ObjectForDraw.DrawnObjectLists.ContainsKey(this.Definition))
        {
            List<ObjectForDraw> list = ObjectForDraw.DrawnObjectLists[this.Definition];
            list.Remove(this);
        }
    }

    public virtual void RemoveDrawnObjectPrincess(DeathReasonID deathReason)
    {
        if (!this.m_initialized && !this.destroyedImmediately)
        {
            this.destroyedImmediately = true;
        }
        this.deathReason = deathReason;
        if (!this.destroyedImmediately && ObjectForDraw.OnObjectDestroy != null)
        {
            ObjectForDraw.OnObjectDestroy(this);
        }
        this.DecreaseDragonPowerPrincess();
        this.SetMatchStatePrincess(MatchStateID.Death);
        if (this.deathReason == DeathReasonID.SlaveMatched)
        {
            ChainMatchInfo.HandleDyingMatchSlaveInputPingPrincess(this);
        }
        if (this.Definition != null && this.Definition.Event_DestroyedFunction != null && !this.IsIcon)
        {
            this.Definition.Event_DestroyedFunction.Invoke(null, new object[]
            {
                this,
                this.deathReason
            });
        }
        if (ObjectForDraw.dropTargetMostRecentTarget == this)
        {
            this.HideHighlightAndInfoForDroppedTargetPrincess();
        }
        this.DeleteGreenArrowPrincess();
        this.RemoveProjectilesPrincess();
        this.LeaveMetaCellPrincess();
        this.ResetMatchPartnersPrincess();
        this.DeleteHighlightPrincess();
        this.DisconnectProgressBarPrincess();
        this.DeleteRemoveFromCategoryListsPrincess();
        Tween.StopTweensOn(this);
        this.destroyedProperly = true;
        if (!this.onDestroyCalled)
        {
            UnityEngine.Object.Destroy(this.m_root);
        }
        this.Root.SetActive(false);
    } 

    public static bool VerifyCreateObjectPrefabPrincess(string prefabName)
    {
        if (string.IsNullOrEmpty(prefabName))
        {
            return false;
        }
        return true;
    }

    public static void GenerateMatchParticlesForPrincess(ObjectForDraw obj)
    {
        GameObject gameObject = GameMgr.GenerateFromPrefabAtPrincess("ParticleRoot_MatchLow", obj.transform.position);
        ParticleSystem component = gameObject.GetComponent<ParticleSystem>();
        //component.startSize += (float)(obj.Definition.ItemLevel - 1) * component.startSize * 0.2f;
        var mainModule = component.main;
        mainModule.startSizeMultiplier += (float)(obj.Definition.ItemLevel - 1) * mainModule.startSizeMultiplier * 0.2f;
        int num = obj.Definition.ItemLevel * obj.Definition.ItemLevel - 1;
        if (num > 0)
        {
            component.Emit(num);
        }
    }

    public static ObjectForDraw GenerateAtPointAndSwoopToFreeCellPrincess(string prefabName, Vector2 creationPoint, JewelryForFight lootOrb, GameObject particlesPrefab = null, bool shakeCameraVerticalImpact = false, float particleZPush = -0.5f, bool moveFront = false)
    {
        if (string.IsNullOrEmpty(prefabName))
        {
            return null;
        }
        MatchObjectDefinition matchObjectDefinition;
        ObjectForDraw drawnObject;
        if (MatchObjectDefinition.Definitions.TryGetValue(prefabName, out matchObjectDefinition))
        {
            if (GridCellsMgr.Instance.BoardCapacityExceededForPrincess(prefabName))
            {
                if (lootOrb)
                {
                    lootOrb.AppendTreasurePrincess(prefabName);
                    return lootOrb.GetComponent<ObjectForDraw>();
                }
                drawnObject = JewelryForFight.Create(prefabName);
            }
            else if (!matchObjectDefinition.RequiresCellPlacement && !ObjectForDraw.VerifyCreateObjectPrefabPrincess(prefabName))
            {
                drawnObject = JewelryForFight.Create(prefabName);
            }
            else
            {
                drawnObject = ObjectForDraw.Create(prefabName, null, -0.5f);
            }
        }
        else
        {
            drawnObject = JewelryForFight.Create(prefabName);
        }

        try
        {
            drawnObject.DefineRootPositionPrincess(creationPoint.x, creationPoint.y);
        }
        catch (Exception)
        {

            throw;
        }


        ObjectAnim.StartNewObjectAppearAnimationPrincess(drawnObject);
        ObjectForDraw.GenerateMatchParticlesForPrincess(drawnObject);
        if (drawnObject.IsABeing && !drawnObject.RequiresCellPlacement)
        {
            GameMgr.SwoopOffGridObjectToLocationInCellRadius(drawnObject, 2, creationPoint);
        }
        else
        {
            GameMgr.PerformSwoopDropToFreeMetaCellPrincess(drawnObject, moveFront);
        }
        if (particlesPrefab != null)
        {
            GameObject gameObject = GameMgr.GenerateFromPrefabAtPrincess(particlesPrefab, new Vector3(drawnObject.transform.position.x, drawnObject.transform.position.y, drawnObject.RetrieveProperZDepthPrincess() + particleZPush));
            gameObject.transform.parent = drawnObject.Root.transform;
        }
        if (shakeCameraVerticalImpact)
        {
            Tween.ShakeCamera_VerticalImpact();
        }
        return drawnObject;
    }

    public static ObjectForDraw GenerateAtPointAndSwoopToFreeCellPrincess(string prefabName, Vector2 creationPoint, bool moveFront = false)
    {
        return ObjectForDraw.GenerateAtPointAndSwoopToFreeCellPrincess(prefabName, creationPoint, null, null, false, -0.5f, moveFront);
    }

    public void StartMatchCreatedSoundEffectPrincess()
    {
        GameAudioMgr.Instance.PlayAtItemLevelPrincess(GameAudioMgr.Instance.SFX_Bundle_Match3_Object, BundlePlayTypeID.BasedOnItemLevel, this.DrawnObjectPosition, this.Definition.ItemLevel, 1f);
    }

    public ObjectForDraw RefreshMatchingHandleChanceDropsPrincess(ulong matchOriginatorGuid, int originatorChainDepth, List<string> prefabsToCreate, Vector2 creationPoint)
    {
        JewelryForFight lootOrb = null;
        ObjectForDraw drawnObject = null;
        foreach (string prefabName in prefabsToCreate)
        {
            ObjectForDraw drawnObject2 = ObjectForDraw.GenerateAtPointAndSwoopToFreeCellPrincess(prefabName, creationPoint, lootOrb, null, false, -0.5f);
            drawnObject2.ChainReactionDepth = originatorChainDepth + 1;
            drawnObject2.MatchChainOriginatorGuid = matchOriginatorGuid;
            drawnObject2.CreatedByMatch = true;
            if (drawnObject == null)
            {
                drawnObject = drawnObject2;
            }
            ChainMatchInfo.HandleMatchOutputCreationPrincess(drawnObject2);
            this.dragonPowerCreatedInMatch += drawnObject2.Definition.DragonPower;
            if (lootOrb == null)
            {
                lootOrb = drawnObject2.GetComponent<JewelryForFight>();
            }
        }
        return drawnObject;
    }

    public void HandleAsBonusDropPrincess(ObjectForDraw bonusDrop)
    {
        //FloatingText.GenerateInfoTextPrincess(ScriptLocalization.Script.Bonus, InfoTextColorID.Green, bonusDrop, true, false, false, false, TextAppearLocationID.Above);
    }

    public void RefreshMatchingHandleExcessInputsPrincess(ulong matchOriginatorGuid, int originatorChainDepth, ObjectForDraw matchOutput, MatchObjectDefinition definitionOfMatchInputs)
    {
        Vector2 position2D = matchOutput.Position2D;
        for (int i = 0; i < this.extraMatchTriples; i++)
        {
            this.RefreshMatchingHandleChanceDropsPrincess(matchOriginatorGuid, originatorChainDepth, definitionOfMatchInputs.RetrieveMatchOutputListPrincess(), position2D);
        }
        for (int j = 0; j < this.bonusMatchOutputsFrom5Matches; j++)
        {
            ObjectForDraw drawnObject = this.RefreshMatchingHandleChanceDropsPrincess(matchOriginatorGuid, originatorChainDepth, definitionOfMatchInputs.RetrieveMatchOutputListPrincess(), position2D);
            this.HandleAsBonusDropPrincess(drawnObject);
            PrincessGameActionHandler.EnlistAction(PrincessGameActionTypeID.Match5Plus, this, 1);
        }
        for (int k = 0; k < this.matchObjectRemainders; k++)
        {
            ObjectForDraw drawnObject2 = ObjectForDraw.GenerateAtPointAndSwoopToFreeCellPrincess(definitionOfMatchInputs.PrefabName, position2D);
            drawnObject2.IsLeftoverFromMatch = true;
            drawnObject2.MatchChainOriginatorGuid = matchOriginatorGuid;
            ChainMatchInfo.HandleMatchOutputCreationPrincess(drawnObject2);
        }
    }

    public void HandleChangesInDragonPowerForCurrentMatchPrincess(ObjectForDraw newObject)
    {
        int num = this.NumItemsUsedInMatch * this.Definition.DragonPower;
        int num2 = this.dragonPowerCreatedInMatch - num;
        if (num2 <= 0)
        {
            return;
        }
        //GameMgr.Instance.ThrowSpecificDragonPowerFloatingTextPrincess(newObject, num2);
    }

    public void HandleCelebratoryActionsOnMatchCreationPrincess()
    {
        //if (this.ContainsCategoryPrincess(CategoryID.Wonders))
        //{
        //    this.HandleSpecialObjectCelebrationOnMatchCreationPrincess(this.Definition, ScriptLocalization.Script.MadeWonder, 3.5f, false);
        //}
        //else if (this.customLootBundle != null && this.customLootBundle.CheckContentsFor_Category(CategoryID.Wonders))
        //{
        //    MatchObjectDefinition definitionOfCelbratedObject = this.customLootBundle.CheckContentsFor_Category_AndGetDef(CategoryID.Wonders);
        //    this.HandleSpecialObjectCelebrationOnMatchCreationPrincess(definitionOfCelbratedObject, ScriptLocalization.Script.MadeWonder, 3.5f, false);
        //}
        //else if (this.ContainsCategoryPrincess(CategoryID.Nests) && this.Definition.ItemLevel == 6)
        //{
        //    this.HandleSpecialObjectCelebrationOnMatchCreationPrincess(this.Definition, ScriptLocalization.Script.MadeT2Nest, 2f, true);
        //}
        //else if (this.customLootBundle != null && this.customLootBundle.CheckContentsFor_Tier2Nest())
        //{
        //    MatchObjectDefinition definitionOfCelbratedObject2 = this.customLootBundle.CheckContentsFor_Tier2Nest_AndGetDef();
        //    this.HandleSpecialObjectCelebrationOnMatchCreationPrincess(definitionOfCelbratedObject2, ScriptLocalization.Script.MadeT2Nest, 2f, true);
        //}
    }

    public static void UpdateEzraHUDOnMatchCreationPrincess(ObjectForDraw createdObject)
    {
        //int itemLevel = createdObject.Definition.ItemLevel;
        //if (itemLevel >= 4 && itemLevel <= 7)
        //{
        //    if (Singleton<EventGameLevelUI>.Exists)
        //    {
        //        Singleton<EventGameLevelUI>.Instance.ezraHud.SetExpression(new HudUIForGame.Expression[]
        //        {
        //            HudUIForGame.Expression.Excited,
        //            HudUIForGame.Expression.Surprised
        //        }.Random<HudUIForGame.Expression>(), 0.5f);
        //    }
        //}
        //else if (itemLevel >= 8 && Singleton<EventGameLevelUI>.Exists)
        //{
        //    Singleton<EventGameLevelUI>.Instance.ezraHud.SetExpression(HudUIForGame.Expression.Impressed, 1f);
        //}
        //if (createdObject.IsAMonster && Singleton<EventGameLevelUI>.Exists)
        //{
        //    Singleton<EventGameLevelUI>.Instance.ezraHud.SetExpression(new HudUIForGame.Expression[]
        //    {
        //        HudUIForGame.Expression.Excited,
        //        HudUIForGame.Expression.Happy
        //    }.Random<HudUIForGame.Expression>(), 0.7f);
        //}
        //if (createdObject.ChainReactionDepth > 1 && Singleton<EventGameLevelUI>.Exists)
        //{
        //    Singleton<EventGameLevelUI>.Instance.ezraHud.SetExpression(HudUIForGame.Expression.Excited, 0.5f);
        //}
    }

    public void RefreshMatching_MatchSlaveUpdatePrincess()
    {
        if (this.readyToBeDestroyedOnMatchComplete)
        {
            return;
        }
        float num = Vector2.Distance(this.Position2D, this.matchTarget.Position2D);
        Vector2 vector = this.matchTarget.Position2D - this.Position2D;
        vector *= 0.2f * (Time.deltaTime * 60f);
        if (vector.magnitude + 0.01f >= num)
        {
            this.readyToBeDestroyedOnMatchComplete = true;
        }
        else
        {
            Vector2 vector2 = this.Position2D + vector;
            this.DefineRootPositionPrincess(vector2.x, vector2.y);
        }
    }

    public void RefreshMatchingCheckForFinaleReadinessPrincess()
    {
        if (this.matchPartners != null && this.matchPartners.Count > 0)
        {
            foreach (ObjectForDraw drawnObject in this.matchPartners)
            {
                if (drawnObject != null && !drawnObject.readyToBeDestroyedOnMatchComplete)
                {
                    return;
                }
            }
            while (this.matchPartners.Count > 0)
            {
                ObjectForDraw ofd = this.matchPartners.PopLast<ObjectForDraw>();

                if (ofd != null)
                {
                    ofd.RemoveDrawnObjectPrincess(DeathReasonID.SlaveMatched);
                }

            }
        }
        Vector2 position2D = this.Position2D;
        int chainReactionDepth = this.ChainReactionDepth;
        ulong num = (this.MatchChainOriginatorGuid != 0UL) ? this.MatchChainOriginatorGuid : this.GUID;
        List<string> matchOutputList = this.Definition.RetrieveMatchOutputListPrincess();
        if (matchOutputList == null || matchOutputList.Count == 0)
        {
            this.RemoveDrawnObjectPrincess(DeathReasonID.Error);
            return;
        }
        string text = matchOutputList[0];
        if (!MatchObjectDefinition.Definitions.ContainsKey(text))
        {
            return;
        }
        PrincessGameActionHandler.EnlistAction(PrincessGameActionTypeID.Match, this, 1);
        ChainMatchInfo.MasterGeneratedMatchPrincess(this, this.Definition.PrefabName);
        this.RemoveDrawnObjectPrincess(DeathReasonID.MasterMatched);
        this.dragonPowerCreatedInMatch = 0;
        ObjectForDraw drawnObject2 = ObjectForDraw.GenerateAtPointAndSwoopToFreeCellPrincess(text, position2D);

        if (drawnObject2 == null)
        {
            return;
        }

        this.dragonPowerCreatedInMatch += drawnObject2.Definition.DragonPower;
        drawnObject2.ChainReactionDepth = chainReactionDepth + 1;
        matchOutputList.RemoveAt(0);
        drawnObject2.MatchChainOriginatorGuid = num;
        drawnObject2.CreatedByMatch = true;
        drawnObject2.WasTheMasterMatchOutput = true;
        ChainMatchInfo.HandleMatchOutputCreationPrincess(drawnObject2);
        ObjectAnim.StartNewObjectAppearAnimationPrincess(drawnObject2, true);
        ObjectForDraw.GenerateMatchParticlesForPrincess(drawnObject2);
        drawnObject2.StartMatchCreatedSoundEffectPrincess();
        drawnObject2.MasterCreatedByMatch = true;
        if (drawnObject2.IsAMonster && this.IsAMonster && this.AsMonster != null && this.AsMonster.FirstName != string.Empty)
        {
            drawnObject2.AsMonster.FirstName = this.AsMonster.FirstName;
        }
        this.RefreshMatchingHandleChanceDropsPrincess(num, chainReactionDepth, matchOutputList, position2D);
        this.RefreshMatchingHandleExcessInputsPrincess(num, chainReactionDepth, drawnObject2, this.Definition);
        ChainMatchInfo.HandleMatchLeaderRetirementPrincess(this);
        this.HandleChangesInDragonPowerForCurrentMatchPrincess(drawnObject2);
        drawnObject2.HandleCelebratoryActionsOnMatchCreationPrincess();
        ObjectForDraw.UpdateEzraHUDOnMatchCreationPrincess(drawnObject2);
    }

    public void Update_Matching()
    {
        if (this.IsMatchLeader)
        {
            this.RefreshMatchingCheckForFinaleReadinessPrincess();
        }
        else
        {
            this.RefreshMatching_MatchSlaveUpdatePrincess();
        }
    }

    public void Update_FlyingToUI()
    {
        //Vector3 worldPositionOfGUI = GameUIMgr.GetWorldPositionOfGUI(this.uiTarget);
        //Vector2 a = new Vector2(worldPositionOfGUI.x, worldPositionOfGUI.y);
        //Vector2 vector = a - this.DrawnObjectPosition2D;
        //float screenWidthHeightFactorInWorldCoords = CameraControl.Instance.ScreenWidthHeightFactorInWorldCoords;
        //float magnitude = vector.magnitude;
        //vector.Normalize();
        //vector = vector * (1.5f * screenWidthHeightFactorInWorldCoords) * Time.deltaTime;
        //float magnitude2 = vector.magnitude;
        //if (magnitude2 > magnitude)
        //{
        //    if (this.hitUICallback != null)
        //    {
        //        this.hitUICallback();
        //    }
        //    else
        //    {
        //        this.TrySetToSetToDying(DeathReasonID.ReachedTarget, true);
        //    }
        //}
        //else
        //{
        //    Vector2 vector2 = this.Position2D + vector;
        //    this.DefineRootPositionPrincess(vector2.x, vector2.y);
        //}
    }

    public void ActivateDeathLootTableAndTerminatePrincess()
    {
        if (this.deathReason == DeathReasonID.LifeTimedOut)
        {
            PrincessGameActionHandler.EnlistAction(PrincessGameActionTypeID.DieFromTimeout, this, 1);
        }
        if (this.Definition.DeathLootTable != null && (this.deathReason == DeathReasonID.HarvestedAway || this.deathReason == DeathReasonID.LifeTimedOut || this.deathReason == DeathReasonID.Tapped))
        {
            string prefabName = this.Definition.DeathLootTable.DropPrefab();
            Vector2 position2D = this.Position2D;
            this.RemoveDrawnObjectPrincess();
            ObjectForDraw.GenerateAtPointAndSwoopToFreeCellPrincess(prefabName, position2D);
            //Singleton<GameAudioMgr>.Instance.PlayAtPrincess(Singleton<GameAudioMgr>.Instance.SFX_ObjectGrowsOrMiscAppears, position2D, 1f);
        }
        else
        {
            this.RemoveDrawnObjectPrincess();
        }
    }

    public void RefreshDyingPrincess()
    {
        if (this.Definition.InstaDeathOnDie || this.instakillOverride)
        {
            this.ActivateDeathLootTableAndTerminatePrincess();
        }
        else
        {
            this.deathTimer.Update(Time.deltaTime);
            if (this.deathTimer.Done)
            {
                this.ActivateDeathLootTableAndTerminatePrincess();
            }
        }
    }

    public Renderer FindObjectRendererPrincess(Renderer renderer)
    {
        List<Renderer> reult = new List<Renderer>();

        if (renderer is SpriteRenderer)
        {
            if ((renderer as SpriteRenderer).sprite == null)
            {
                SpriteRenderer[] spriteRenderers = renderer.GetComponentsInChildren<SpriteRenderer>();
                foreach (SpriteRenderer spriteRenderer in spriteRenderers)
                {
                    if (spriteRenderer.sprite != null)
                    {
                        reult.Add(spriteRenderer);
                    }
                }
            }

        }
        else
        {

            Renderer[] spriteRenderers = renderer.GetComponentsInChildren<Renderer>();
            foreach (Renderer spriteRenderer in spriteRenderers)
            {
                if (spriteRenderer != null)
                {
                    reult.Add(spriteRenderer);
                }
            }

        }

        if (reult.Count > 0)
        {
            return reult[0];
        }
        else
            return renderer;
    }

    public void TryAddTapArrow(bool showEvenIfItemTypeHadArrowBefore = false)
    {
        //if (this.Definition.TapBehavior == null || !this.HasTapsAvailable)
        //{
        //    return;
        //}
        if (this.Dead || this.State == MatchStateID.BeingCarried)
        {
            return;
        }
        if (this.tapArrow)
        {
            return;
        }
        if (!showEvenIfItemTypeHadArrowBefore && (!this.Definition.ShowTapArrowBeforeFirstTap || this.Definition.EverTapped))
        {
            return;
        }
        this.tapArrow = GameMgr.GenerateFromPrefabAtPrincess("TapArrow_Root", this.DrawnCenter);
        if (this.tapArrow == null)
        {
            return;
        }
        Bounds totalBounds = GameMgr.RetrieveTotalBoundsPrincess(this.Root);
        this.tapArrow.transform.localPosition = new Vector3(0f, totalBounds.max.y, 0f);
        this.tapArrow.transform.parent = this.Root.transform;
        this.tapArrow.transform.localPosition = new Vector3(0f, this.tapArrow.transform.localPosition.y, -2f);
    }

    public void UpdateShrinkScaleFromTapOrHarvestPrincess()
    {
        if (this.State == MatchStateID.BeingCarried || this.State == MatchStateID.Icon || this.State == MatchStateID.DrawOnly)
        {
            return;
        }
        int num = 0;
        int num2 = 0;
        if (!this.Definition.ShrinkWithHarvest) //&& (this.Definition.TapBehavior == null || !this.Definition.TapBehavior.shrinkOnTap))
        {
            return;
        }
        if (this.startingHarvestCharges == 0 && this.startingTaps == 0)
        {
            return;
        }
        if (this.startingHarvestCharges > 0 && this.Definition.ShrinkWithHarvest)
        {
            num += this.startingHarvestCharges;
            num2 += this.harvestChargesLeft;
        }
        if (this.startingTaps > 0) //&& this.Definition.TapBehavior != null && this.Definition.TapBehavior.shrinkOnTap)
        {
            num += this.startingTaps;
            num2 += this.tapsLeft;
        }
        if (this.lastHarvestTapChargeTotalForShrink == num2)
        {
            return;
        }
        this.lastHarvestTapChargeTotalForShrink = num2;
        float num3 = ObjectForDraw.k_MIN_SHRINK_SCALE_FROM_TAP_AND_HARVEST + ObjectForDraw.k_MIN_SHRINK_SCALE_FROM_TAP_AND_HARVEST * ((float)num2 / (float)num);
        this.restingScale = new Vector3(this.originalScale.x * num3, this.originalScale.y * num3, this.originalScale.z);
        Tween.EaseBackToOriginalScale(this);
    }

    public void AttemptToReplenishTapPrincess()
    {
        if (this.tapsLeft >= this.startingTaps)
        {
            return;
        }
        this.tapsLeft++;
        //if (this.tapVisualizer != null)
        //{
        //    this.tapVisualizer.OnTapAmountChangePrincess();
        //}
        this.TryAddTapArrow(false);
        this.UpdateShrinkScaleFromTapOrHarvestPrincess();
    }

    public bool CheckIfCanLoseLifetimeRightNowPrincess()
    {
        return this.MatchState != MatchStateID.Icon && this.MatchState != MatchStateID.Dying && this.MatchState != MatchStateID.Death && this.MatchState != MatchStateID.Matching && this.MatchState != MatchStateID.BeingCarried && this.MatchState != MatchStateID.FlyingToUI && this.MatchState != MatchStateID.Keyhole && this.MatchState != MatchStateID.DrawOnly && !this.Dead;
    }

    public bool CheckIfCanDieFromTimeoutRightNowPrincess()
    {
        return this.MatchState != MatchStateID.Icon && this.MatchState != MatchStateID.ReservedByEnemy && this.MatchState != MatchStateID.Dying && this.MatchState != MatchStateID.Death && this.MatchState != MatchStateID.Matching && this.MatchState != MatchStateID.BeingCarried && this.MatchState != MatchStateID.ReservedForMatch && this.MatchState != MatchStateID.Keyhole && this.MatchState != MatchStateID.DrawOnly;
    }

    public bool TrySetToSetToDying(DeathReasonID deathReason, bool instakillOverride, float timeToShrinkAndDie)
    {
        if (!this.CheckIfCanDieFromTimeoutRightNowPrincess())
        {
            return false;
        }
        this.SetMatchStatePrincess(MatchStateID.Dying);
        this.deathReason = deathReason;
        if (ObjectForDraw.dropTargetMostRecentTarget == this)
        {
            this.HideHighlightAndInfoForDroppedTargetPrincess();
        }
        if (instakillOverride)
        {
            this.instakillOverride = true;
        }
        if (this.Definition.InstaDeathOnDie || instakillOverride)
        {
            return true;
        }
        if (this.deathTimer == null)
        {
            this.deathTimer = new Timer();
        }
        this.deathTimer.Set(timeToShrinkAndDie);
        //ObjectAnim.StartDieFromTimeoutAnimationPrincess(this);
        return true;
    }

    public bool TrySetToSetToDying(DeathReasonID deathReason, bool instakillOverride)
    {
        return this.TrySetToSetToDying(deathReason, instakillOverride, 0.5f);
    }

    public bool TrySetToSetToDying(DeathReasonID deathReason)
    {
        return this.TrySetToSetToDying(deathReason, false);
    }

    public void RefreshLifetimeAndTimersPrincess()
    {
        if (this.IsTemporary)
        {
            return;
        }
        if (this.harvestTimeoutTimer != null)
        {
            this.harvestTimeoutTimer.Update(Time.deltaTime);
        }
        if (this.autoTapTimer != null)
        {
            this.autoTapTimer.Update(Time.deltaTime);
            if (this.autoTapTimer.Done && this.State == MatchStateID.Idle)
            {
                this.TriggerTapBehavior();
                if (this.tapsLeft > 0)
                {
                    this.autoTapTimer.Reset();
                }
                else
                {
                    this.autoTapTimer = null;
                }
            }
        }
        if (this.tapRechargeTimer != null)
        {
            this.tapRechargeTimer.Update(Time.deltaTime);
            if (this.tapRechargeTimer.Done)
            {
                this.AttemptToReplenishTapPrincess();
                this.tapRechargeTimer.Reset();
            }
        }
        if (this.Definition.DiesAfterTimeout && this.CheckIfCanLoseLifetimeRightNowPrincess())
        {
            this.deathTimer.Update(Time.deltaTime);
            if (this.deathTimer.Done)
            {
                this.TrySetToSetToDying(DeathReasonID.LifeTimedOut);
            }
        }
    }

    public void TryActivateMatch_TallyMergeOutputs_NormalLevel(int totalMatchInputs)
    {
        while (totalMatchInputs > 0)
        {
            if (totalMatchInputs == 9)
            {
                this.extraMatchTriples += 3;
                totalMatchInputs = 0;
            }
            else if (totalMatchInputs == 7)
            {
                this.extraMatchTriples += 2;
                this.matchObjectRemainders = 1;
                totalMatchInputs = 0;
            }
            else if (totalMatchInputs == 6)
            {
                this.extraMatchTriples += 2;
                totalMatchInputs = 0;
            }
            else if (totalMatchInputs >= 5)
            {
                this.bonusMatchOutputsFrom5Matches++;
                this.extraMatchTriples++;
                totalMatchInputs -= 5;
            }
            else if (totalMatchInputs >= 3)
            {
                this.extraMatchTriples++;
                totalMatchInputs -= 3;
            }
            else
            {
                this.matchObjectRemainders = totalMatchInputs;
                totalMatchInputs = 0;
            }
        }
        this.extraMatchTriples--;
    }

    public void RecoverLocalRotationPrincess()
    {
        this.transform.localRotation = this.originalRotation;
    }

    public void AppendToCategoryListsPrincess()
    {
        if (!ObjectForDraw.DrawnObjectLists.ContainsKey(this.Definition))
        {
            ObjectForDraw.DrawnObjectLists.Add(this.Definition, new List<ObjectForDraw>());
        }
        List<ObjectForDraw> list = ObjectForDraw.DrawnObjectLists[this.Definition];
        list.Add(this);
    }

    public void ShiftRootPositionPrincess(Vector2 movementVector)
    {
        UnityEngine.Debug.Log("this.m_root.transform.position = " + this.m_root.transform.position + "  movementVector = " + movementVector);
        this.m_root.transform.position = new Vector3(movementVector.x + this.X, movementVector.y + this.Y, this.Z);
        UnityEngine.Debug.Log("this.m_root.transform.position = " + this.m_root.transform.position);
    }


    private void Awake()
    {
        this.matchPartners = null;
        if (this.m_root == null)
        {
            if (this.transform.parent != null)
            {
                UnityEngine.Debug.LogError(this.name + ": ERROR>> Root needs to be set in the editor on the ObjectForDraw component. Drag the root object into the root field.");
            }
            this.m_root = GameMgr.GenerateFromPrefabPrincess("Root");
            this.m_root.transform.position = this.transform.position;
            this.transform.parent = this.m_root.transform;

        }
        this.localPositionAnimationTarget = GameMgr.GenerateFromPrefabPrincess("Root");
        this.localPositionAnimationTarget.name = "PosAnimTarget";
        this.localPositionAnimationTarget.transform.position = this.transform.position;
        this.localPositionAnimationTarget.transform.parent = this.m_root.transform;
        this.transform.parent = this.localPositionAnimationTarget.transform;
        this.originalPosition = this.localPositionAnimationTarget.transform.localPosition;

        this.restingScale = this.transform.localScale;
        this.originalScale = this.restingScale;
        this.originalRotation = this.transform.localRotation;
        //this.originalSortingLayerID = this.Renderer.sortingLayerID;
        this.originalHeightOffsetToTop = this.Renderer.bounds.max.y - this.m_root.transform.position.y; 
    }

    private void Start()
    {
        this.MainInitializationPrincess();
        if (this.Definition.PrefabName == "Green_Tree_4")
        {
            Transform locate = transform.Find("TapVisualizer");
            GameObject temp = GameMgr.GenerateFromPrefabAtPrincess("Fruit_Peach", this.transform.position);
            Destroy(temp.GetComponent<ObjectForDraw>());
            Destroy(temp.GetComponent<CircleCollider2D>());
            temp.transform.parent = locate;
            temp.transform.localPosition = Vector3.zero;
            this.addctiveObject = temp;
        }
    }

    public virtual void Update()
    {
        if (GameMgr.IsSimulationPaused())
        {
            return;
        }
        if (this.MatchState == MatchStateID.Idle)
        {
            this.RefreshFirstIdlePrincess();
        }
        else if (this.MatchState == MatchStateID.SwoopingToCell)
        {
            this.RefreshSwoopToCellPrincess();
        }
        else if (this.MatchState == MatchStateID.SwoopingToOffGridLocation)
        {
            this.RefreshSwoopToOffGridLocationPrincess();
        }
        else if (this.MatchState == MatchStateID.PostSwoopStillSelected)
        {
            if (!this.CheckIfHasActiveTimersPrincess())
            {
                this.Sleep();
            }
        }
        else if (this.MatchState == MatchStateID.Matching)
        {
            this.Update_Matching();
        }
        else if (this.MatchState == MatchStateID.FlyingToUI)
        {
            this.Update_FlyingToUI();
        }
        else if (this.MatchState == MatchStateID.Dying)
        {
            this.RefreshDyingPrincess();
        }
        else if (this.MatchState == MatchStateID.Icon && !this.CheckIfHasActiveTimersPrincess())
        {
            this.Sleep();
        }
        if (this.MatchState != MatchStateID.Icon && this.MatchState != MatchStateID.DrawOnly)
        {
            this.RefreshLifetimeAndTimersPrincess();
        }
        _momState = MasterObjectMover.Instance.State;

    }

    private void OnDestroy()
    {
        if (this.Definition == null) return;
        if (ObjectForDraw.DrawnObjectLists.ContainsKey(this.Definition))
        {
            List<ObjectForDraw> list = ObjectForDraw.DrawnObjectLists[this.Definition];
            if (list.Contains(this))
            {
                this.DeleteRemoveFromCategoryListsPrincess();
            }
        }
    }
}
