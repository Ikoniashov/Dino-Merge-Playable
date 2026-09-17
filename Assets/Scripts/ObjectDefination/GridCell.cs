using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    [HideInInspector] public GridCellsMgr m_board;
    [HideInInspector] public int m_xIndex;
    [HideInInspector] public int m_yIndex;
    public GameObject VerticalFaceLocator;
    [HideInInspector] public GridCell m_left;
    [HideInInspector] public GridCell m_right;
    [HideInInspector] public GridCell m_up;
    [HideInInspector] public GridCell m_down;
    [HideInInspector] public GridCell m_leftup;
    [HideInInspector] public GridCell m_rightbottom;
    [HideInInspector] public GameObject m_wall;
    public GameObject[] TuftLocators;
    public GameObject[] TuftPrefabs;
    [HideInInspector] public GameObject[] m_tufts = new GameObject[4];
    public FullofDeadObject m_deathComponent;
    [HideInInspector] public bool IsSticky;
    [HideInInspector] public ObjectForDraw m_occupant;
    [HideInInspector] public bool IsKeyhole;
    [HideInInspector] public bool IsUnlocked;
    [HideInInspector] public GameObject KeyObject;
    [HideInInspector] public ObjectForDraw m_overlapOccupant;
    public static float k_pointMultiplierForHealingDeadTileByPullingObjectFromIt;
    public List<ObjectForDraw> m_offGridMatchObjects = new List<ObjectForDraw>();
    public Renderer m_renderer;
    public string keyObjectDefinitionPrefabName;
    public GameObject m_pendingPlacementParticles;


    public bool Dead
    {
        get
        {
            return this.DeathComponent != null && !this.DeathComponent.Destroyed_F;
        }
    }

    public FullofDeadObject DeathComponent
    {
        get
        {
            if (this.m_deathComponent == null)
            {
                this.m_deathComponent = this.GetComponent<FullofDeadObject>();
            }
            return this.m_deathComponent;
        }
    }

    public bool Occupied
    {
        get
        {
            return this.m_occupant != null;
        }
    }

    public ObjectForDraw Occupant
    {
        get
        {
            return this.m_occupant;
        }
    }

    public ObjectForDraw OverlapOccupant
    {
        get
        {
            return this.m_overlapOccupant;
        }
    }

    public bool OverlapOccupied
    {
        get
        {
            return this.m_overlapOccupant != null;
        }
    }

    public Vector2 Center
    {
        get
        {
            return new Vector2(this.transform.position.x, this.transform.position.y);
        }
    }

    public int XIndex
    {
        get
        {
            return this.m_xIndex;
        }
    }

    public int YIndex
    {
        get
        {
            return this.m_yIndex;
        }
    }

    public Renderer Renderer
    {
        get
        {
            if (this.m_renderer == null)
            {
                this.m_renderer = this.GetComponent<Renderer>();
            }
            return this.m_renderer;
        }
    }

    public bool EmptyAndAlive
    {
        get
        {
            return this.m_occupant == null && this.m_deathComponent == null;
        }
    }

    public float X
    {
        get
        {
            return this.transform.position.x;
        }
    }

    public float Y
    {
        get
        {
            return this.transform.position.y;
        }
    }


    public void Initialize(GridCellsMgr board, int xIndex, int yIndex)
    {
        this.m_board = board;
        this.m_xIndex = xIndex;
        this.m_yIndex = yIndex;
        Vector2 vector = GridCellsMgr.MapGridToWorld((float)xIndex + 0.5f, (float)yIndex + 0.5f);
        this.transform.position = new Vector3(vector.x, vector.y, vector.y);
        this.transform.parent = board.transform;
    }

    public void InitWallsAndTufts()
    {
        bool flag = this.InitWalls();
        bool flag2 = this.InitTufts();
        if ((flag || flag2) && this.Dead)
        {
            this.DeathComponent.RefreshRendererSetAndAlignVisualsPrincess();
        }
    }

    public bool InitWalls()
    {
        if (this.VerticalFaceLocator == null)
        {
            return false;
        }
        if (this.m_left == null || this.m_down == null)
        {
            if (this.m_wall == null)
            {

                this.m_wall = GameMgr.GenerateFromPrefabPrincess("CellSide_BrownRock");
                if (this.m_wall == null)
                {
                    return false;
                }
                Vector3 originalScale = this.m_wall.transform.localScale;
                this.m_wall.transform.parent = this.VerticalFaceLocator.transform;
                if (originalScale == Vector3.one) this.m_wall.transform.localScale = Vector3.one;
                this.m_wall.transform.localPosition = Vector3.zero;
                return true;
            }
        }
        else if (this.m_wall != null)
        {
            UnityEngine.Object.Destroy(this.m_wall);
            this.m_wall = null;
            return true;
        }
        return false;
    }

    public bool InitTufts()
    {
        if (this.TuftLocators == null || this.TuftPrefabs == null || this.TuftLocators.Length == 0 || this.TuftPrefabs.Length == 0)
        {
            return false;
        }
        if (this.TuftLocators.Length != 4 || this.TuftPrefabs.Length != 4)
        {
            Debug.LogError("GridCell has wrong number of tuft locators or tuft prefabs. Check the cell: " + this.name);
            return false;
        }
        bool[] array = new bool[]
        {
            this.m_up == null,
            this.m_right == null,
            this.m_down == null,
            this.m_left == null
        };
        bool result = false;
        for (int i = 0; i < 4; i++)
        {
            if (!array[i])
            {
                if (this.m_tufts[i] != null)
                {
                    UnityEngine.Object.Destroy(this.m_tufts[i]);
                    this.m_tufts[i] = null;
                    result = true;
                }
            }
            else if (this.m_tufts[i] == null)
            {
                this.m_tufts[i] = GameMgr.GenerateFromGameObjectPrincess(this.TuftPrefabs[i]);
                if (this.m_tufts[i] == null)
                {
                    continue;
                }
                Vector3 originalScale = this.m_tufts[i].transform.localScale;
                this.m_tufts[i].transform.parent = this.TuftLocators[i].transform;
                if (originalScale == Vector3.one) this.m_tufts[i].transform.localScale = Vector3.one;
                this.m_tufts[i].transform.localPosition = Vector3.zero;
                result = true;
            }
        }
        // Show desert corner pieces only when the neighboring tile requires them.
        if (this.m_tufts[0] != null)
        {
            Transform left = this.m_tufts[0].transform.Find("Left");
            Transform right = this.m_tufts[0].transform.Find("Right");
            if (left != null) left.gameObject.SetActive(this.m_left == null);
            if (right != null) right.gameObject.SetActive(this.m_right == null);
        }
        if (this.m_tufts[2] != null)
        {
            Transform left = this.m_tufts[2].transform.Find("Left");
            Transform right = this.m_tufts[2].transform.Find("Right");
            Transform rightBottom = this.m_tufts[2].transform.Find("RightBottom");
            if (left != null) left.gameObject.SetActive(this.m_left == null);
            if (right != null) right.gameObject.SetActive(this.m_right == null);
            if (rightBottom != null) rightBottom.gameObject.SetActive(this.m_rightbottom != null);
        }
        if (this.m_tufts[3] != null)
        {
            Transform leftTop = this.m_tufts[3].transform.Find("LeftTop");
            if (leftTop != null) leftTop.gameObject.SetActive(this.m_leftup != null);
        }
        return result;
    }

    public void TryRemovePendingKeyholeParticles()
    {
        if (this.m_pendingPlacementParticles != null)
        {
            UnityEngine.Object.Destroy(this.m_pendingPlacementParticles);
        }
    }

    public void ClearOccupant()
    {
        ObjectForDraw occupant = this.m_occupant;
        this.m_occupant = null;
        if (!this.m_board.CellsInEmptyState.Contains(this))
        {
            this.m_board.CellsInEmptyState.Add(this);
        }
        if (!this.m_board.EmptyCellsInLivingState.Contains(this) && !this.Dead)
        {
            this.m_board.EmptyCellsInLivingState.Add(this);
        }
        if (this.Dead)
        {
            this.DeathComponent.InstantHeal(GridCell.k_pointMultiplierForHealingDeadTileByPullingObjectFromIt);
            if (occupant != null)
            {
                //GameTargetMgr.CompleteMatchOnDeadLandPrincess(occupant);
            }
        }
        this.TryRemovePendingKeyholeParticles();
    }

    public void ClearOverlapOccupant()
    {
        this.m_overlapOccupant = null;
        this.TryRemovePendingKeyholeParticles();
    }

    public bool SetOverlapOccupant(ObjectForDraw newOverlapOccupant)
    {
        if (this.m_overlapOccupant != null)
        {
            return false;
        }
        this.m_overlapOccupant = newOverlapOccupant;
        return true;
    }

    public void SetOccupant_TryKeyholeEffects()
    {
        if (!this.IsKeyhole)
        {
            return;
        }
        if (this.IsUnlocked)
        {
            return;
        }
        if (!FitsLockhole(this.m_occupant, this))
        {
            return;
        }
        if (this.m_pendingPlacementParticles != null)
        {
            return;
        }
        this.m_pendingPlacementParticles = GameMgr.GenerateFromPrefabAtPrincess("ParticleRoot_KeyholePendingMatch", new Vector3(this.X, this.Y, 0f));
    }

    public bool SetOccupant(ObjectForDraw newOccupant)
    {
        if (this.m_occupant != null)
        {
            return false;
        }
        this.m_occupant = newOccupant;
        this.SetOccupant_TryKeyholeEffects();
        if (this.m_board.CellsInEmptyState.Contains(this))
        {
            this.m_board.CellsInEmptyState.Remove(this);
        }
        if (this.m_board.EmptyCellsInLivingState.Contains(this))
        {
            this.m_board.EmptyCellsInLivingState.Remove(this);
        }
        newOccupant.TryAddDeathComponents();
        return true;
    }

    public static bool FitsLockhole(ObjectForDraw possibleKey, GridCell keyholeCell)
    {
        return possibleKey.Definition.PrefabName.Equals(keyholeCell.keyObjectDefinitionPrefabName);
    }

    public bool CanBeOccupiedBy(ObjectForDraw newOccupant)
    {
        return !this.Dead && (!this.IsKeyhole || this.IsUnlocked || FitsLockhole(newOccupant, this)) && (!this.Occupied || this.Occupant == newOccupant);
    }

    public bool OccupantsCanBePushedOutAndOccupiedBy(ObjectForDraw pusher)
    {
        return !this.Dead && (!this.IsKeyhole || this.IsUnlocked) && (!this.Occupied || this.Occupant == pusher || this.Occupant.IsInADraggableState());
    }

    public void RecursiveFindMatches(MatchObjectDefinition definition, ref List<ObjectForDraw> matchPartners, ObjectForDraw requestor,bool skipClaim = false)
    {
        if (this.Occupied)// && (this.m_occupant.Definition == definition || requestor.CheckIfInputCategoryIsValidMatchPrincess(this.m_occupant)) && this.m_occupant.AttemptClaimForMatchPrincess(requestor,skipClaim))
        {
            if (this.m_occupant != null)
            {
                if ((this.m_occupant.Definition == definition || requestor.CheckIfInputCategoryIsValidMatchPrincess(this.m_occupant)) && this.m_occupant.AttemptClaimForMatchPrincess(requestor, skipClaim))
                {
                    if (matchPartners == null)
                    {
                        matchPartners = new List<ObjectForDraw>();
                    }
                    if (matchPartners.Contains(this.m_occupant)) return;
                    else matchPartners.Add(this.m_occupant);
                    if (this.m_occupant.metaCell == null)
                    {

                    }
                    this.m_occupant.metaCell.FindAvailableMatchesFor_Recursive(definition, ref matchPartners, requestor, skipClaim);
                }
            }
        }
    }

    public bool CanBeOverlapOccupiedBy(ObjectForDraw newOccupant)
    {
        return !this.Dead && (!this.Occupied || this.m_occupant.Definition == newOccupant.Definition || this.m_occupant.CheckIfInputCategoryIsValidMatchPrincess(newOccupant)) && (!this.OverlapOccupied || this.OverlapOccupant == newOccupant);
    }

    public void ClearOffGridMatchObjects()
    {
        this.m_offGridMatchObjects.Clear();
    }

    public void AddOffGridMatchObject(ObjectForDraw obj)
    {
        this.m_offGridMatchObjects.Add(obj);
    }

    public bool CheckForOffGridMatchPartners(ObjectForDraw masterObject, ref List<ObjectForDraw> matchPartners, ObjectForDraw requesterToIgnore)
    {
        bool result = false;
        if (this.m_offGridMatchObjects.Count == 0 || this.m_offGridMatchObjects[0].Definition != masterObject.Definition)
        {
            return false;
        }
        foreach (ObjectForDraw drawnObject in this.m_offGridMatchObjects)
        {
            if (!(drawnObject == masterObject))
            {
                if (drawnObject.AttemptClaimForMatchPrincess(requesterToIgnore))
                {
                    if (matchPartners == null)
                    {
                        matchPartners = new List<ObjectForDraw>();
                    }
                    matchPartners.Add(drawnObject);
                    result = true;
                }
            }
        }
        return result;
    }

    public void RecursiveFindMatches_OffGrid(ObjectForDraw masterObject, ref List<ObjectForDraw> matchPartners, ObjectForDraw requesterToIgnore)
    {
        if (this.CheckForOffGridMatchPartners(masterObject, ref matchPartners, requesterToIgnore))
        {
            if (this.m_left != null)
            {
                this.m_left.RecursiveFindMatches_OffGrid(masterObject, ref matchPartners, requesterToIgnore);
            }
            if (this.m_right != null)
            {
                this.m_right.RecursiveFindMatches_OffGrid(masterObject, ref matchPartners, requesterToIgnore);
            }
            if (this.m_up != null)
            {
                this.m_up.RecursiveFindMatches_OffGrid(masterObject, ref matchPartners, requesterToIgnore);
            }
            if (this.m_down != null)
            {
                this.m_down.RecursiveFindMatches_OffGrid(masterObject, ref matchPartners, requesterToIgnore);
            }
        }
    }

    public void FindAvailableMatchesFor_OffGrid(ObjectForDraw masterObject, ref List<ObjectForDraw> matchPartners, ObjectForDraw requesterToIgnore)
    {
        this.CheckForOffGridMatchPartners(masterObject, ref matchPartners, requesterToIgnore);
        if (this.m_left != null)
        {
            this.m_left.RecursiveFindMatches_OffGrid(masterObject, ref matchPartners, requesterToIgnore);
        }
        if (this.m_right != null)
        {
            this.m_right.RecursiveFindMatches_OffGrid(masterObject, ref matchPartners, requesterToIgnore);
        }
        if (this.m_up != null)
        {
            this.m_up.RecursiveFindMatches_OffGrid(masterObject, ref matchPartners, requesterToIgnore);
        }
        if (this.m_down != null)
        {
            this.m_down.RecursiveFindMatches_OffGrid(masterObject, ref matchPartners, requesterToIgnore);
        }
    }

    public bool ContainsPoint(Vector3 position)
    {
        Vector2 vector = GridCellsMgr.MapWorldToGrid(position);
        if (vector.x < 0f || vector.y < 0f)
        {
            return false;
        }
        int num = (int)vector.x;
        int num2 = (int)vector.y;
        return this.m_xIndex == num && this.m_yIndex == num2;

    }
}
