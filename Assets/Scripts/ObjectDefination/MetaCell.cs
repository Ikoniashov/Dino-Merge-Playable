using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MetaCell
{
    public int m_widthInCells = -1;
    public int m_heightInCells = -1;
    public int m_xCellIndexLowerLeft = -1;
    public int m_yCellIndexLowerLeft = -1;
    public GridCell[][] Cells;
    public Vector2 Center;


    public GridCell Anchor
    {
        get
        {
            return this.Cells[0][0];
        }
    }

    public bool Occupied
    {
        get
        {
            for (int i = 0; i < this.m_widthInCells; i++)
            {
                for (int j = 0; j < this.m_heightInCells; j++)
                {
                    if (this.Cells[i][j].Occupied)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    public float X
    {
        get
        {
            return this.Center.x;
        }
    }

    public float Y
    {
        get
        {
            return this.Center.y;
        }
    }

    public GridCell OppositeAnchor
    {
        get
        {
            return this.Cells[this.m_widthInCells - 1][this.m_heightInCells - 1];
        }
    }

    public int CellIndex_Right
    {
        get
        {
            return this.m_xCellIndexLowerLeft + this.m_widthInCells - 1;
        }
    }


    public MetaCell(int boardX, int boardY, int metaCellWidth, int metaCellHeight)
    {
        this.AlignToCells(boardX, boardY, metaCellWidth, metaCellHeight);
    }

    public void InitCellArray()
    {
        if (this.m_widthInCells < 1 || this.m_heightInCells < 1)
        {
            
        }
        this.Cells = new GridCell[this.m_widthInCells][];
        for (int i = 0; i < this.m_widthInCells; i++)
        {
            this.Cells[i] = new GridCell[this.m_heightInCells];
            for (int j = 0; j < this.m_heightInCells; j++)
            {
                GridCell cell = GridCellsMgr.Instance.GetCell(this.m_xCellIndexLowerLeft + i, this.m_yCellIndexLowerLeft + j, true, true);
                this.Cells[i][j] = cell;
            }
        }
    }

    public void InitPosition()
    {
        float xInGridCoords = (float)this.m_xCellIndexLowerLeft + (float)this.m_widthInCells / 2f;
        float yInGridCoords = (float)this.m_yCellIndexLowerLeft + (float)this.m_heightInCells / 2f;
        this.Center = GridCellsMgr.MapGridToWorld(xInGridCoords, yInGridCoords);
    }

    public void AlignToCells(int boardX, int boardY, int metaCellWidth, int metaCellHeight)
    {
        if (GridCellsMgr.Instance.CheckIfMetaCellIsOutOfBoundsOrOverNullCellPrincess(boardX, boardY, metaCellWidth, metaCellHeight, OOBErrorTypeID.ShowIfAnyOOB))
        {
            return;
        }
        this.m_widthInCells = metaCellWidth;
        this.m_heightInCells = metaCellHeight;
        this.m_xCellIndexLowerLeft = boardX;
        this.m_yCellIndexLowerLeft = boardY;
        this.InitCellArray();
        this.InitPosition();
    }

    public bool VerifySizesMatch(ObjectForDraw obj, bool showErrorOnMismatch)
    {
        if (obj.Definition.WidthInTiles != this.m_widthInCells || obj.Definition.HeightInTiles != this.m_heightInCells)
        {
            if (showErrorOnMismatch)
            {

            }
            return false;
        }
        return true;
    }

    public bool IsFullyOccupiedBy(ObjectForDraw obj, bool requireSizeParity)
    {
        if (requireSizeParity && !this.VerifySizesMatch(obj, true))
        {
            return false;
        }
        for (int i = 0; i < this.m_widthInCells; i++)
        {
            for (int j = 0; j < this.m_heightInCells; j++)
            {
                if (this.Cells[i][j].Occupant != obj)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void Vacate(ObjectForDraw obj)
    {
        this.VerifySizesMatch(obj, true);
        for (int i = 0; i < this.m_widthInCells; i++)
        {
            for (int j = 0; j < this.m_heightInCells; j++)
            {
                GridCell cell = this.Cells[i][j];
                if (cell.Occupant == obj)
                {
                    cell.ClearOccupant();
                }
                else if (cell.OverlapOccupant == obj)
                {
                    cell.ClearOverlapOccupant();
                }
            }
        }
    }

    public void SetOverlapOccupant(ObjectForDraw newOverlapOccupant)
    {
        if (!this.VerifySizesMatch(newOverlapOccupant, true))
        {
            return;
        }
        for (int i = 0; i < this.m_widthInCells; i++)
        {
            for (int j = 0; j < this.m_heightInCells; j++)
            {
                this.Cells[i][j].SetOverlapOccupant(newOverlapOccupant);
            }
        }
    }

    public void SetOccupant(ObjectForDraw newOccupant)
    {
        if (!this.VerifySizesMatch(newOccupant, true))
        {
            return;
        }
        for (int i = 0; i < this.m_widthInCells; i++)
        {
            for (int j = 0; j < this.m_heightInCells; j++)
            {
                this.Cells[i][j].SetOccupant(newOccupant);
            }
        }
    }

    public bool CanBeOccupiedBy(ObjectForDraw potentialOccupant)
    {
        if (this.Cells[0][0].IsKeyhole == true && this.Cells[0][0].keyObjectDefinitionPrefabName != null && this.Cells[0][0].IsUnlocked == false)
        {
            if (potentialOccupant.Definition.PrefabName != this.Cells[0][0].keyObjectDefinitionPrefabName) return false;
        }

        if (!this.VerifySizesMatch(potentialOccupant, true))
        {
            return false;
        }
        for (int i = 0; i < this.m_widthInCells; i++)
        {
            for (int j = 0; j < this.m_heightInCells; j++)
            {
                if (!this.Cells[i][j].CanBeOccupiedBy(potentialOccupant))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool OccupantsCanBePushedOutAndOccupiedBy(ObjectForDraw pusher)
    {
        if (!this.VerifySizesMatch(pusher, true))
        {
            return false;
        }
        for (int i = 0; i < this.m_widthInCells; i++)
        {
            for (int j = 0; j < this.m_heightInCells; j++)
            {
                if (!this.Cells[i][j].OccupantsCanBePushedOutAndOccupiedBy(pusher))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public List<ObjectForDraw> GetOccupants()
    {
        List<ObjectForDraw> list = null;
        for (int i = 0; i < this.m_widthInCells; i++)
        {
            for (int j = 0; j < this.m_heightInCells; j++)
            {
                GridCell cell = this.Cells[i][j];
                if (cell.Occupied)
                {
                    if (list == null)
                    {
                        list = new List<ObjectForDraw>();
                    }
                    if (!list.Contains(cell.Occupant))
                    {
                        list.Add(cell.Occupant);
                    }
                }
            }
        }
        return list;
    }

    public void FindAvailableMatchesFor_Recursive(MatchObjectDefinition definition, ref List<ObjectForDraw> matchPartners, ObjectForDraw requesterToIgnore,bool skipClaim = false)
    {
        for (int i = 0; i < this.m_widthInCells; i++)
        {
            for (int j = 0; j < this.m_heightInCells; j++)
            {
                GridCell cell = this.Cells[i][j];
                if (i == 0 && cell.m_left != null)
                {
                    cell.m_left.RecursiveFindMatches(definition, ref matchPartners, requesterToIgnore,skipClaim);
                }
                if (i == this.m_widthInCells - 1 && cell.m_right != null)
                {
                    cell.m_right.RecursiveFindMatches(definition, ref matchPartners, requesterToIgnore, skipClaim);
                }
                if (j == 0 && cell.m_down != null)
                {
                    cell.m_down.RecursiveFindMatches(definition, ref matchPartners, requesterToIgnore, skipClaim);
                }
                if (j == this.m_heightInCells - 1 && cell.m_up != null)
                {
                    cell.m_up.RecursiveFindMatches(definition, ref matchPartners, requesterToIgnore, skipClaim);
                }
            }
        }
    }

    public bool CanBeOverlapOccupiedBy(ObjectForDraw potentialOverlapOccupant)
    {
        if (this.Cells[0][0].IsKeyhole == true && this.Cells[0][0].keyObjectDefinitionPrefabName != null && this.Cells[0][0].IsUnlocked == false)
        {
            if (potentialOverlapOccupant.Definition.PrefabName != this.Cells[0][0].keyObjectDefinitionPrefabName) return false;
        }

        if (!this.VerifySizesMatch(potentialOverlapOccupant, true))
        {
            return false;
        }
        for (int i = 0; i < this.m_widthInCells; i++)
        {
            for (int j = 0; j < this.m_heightInCells; j++)
            {
                if (!this.Cells[i][j].CanBeOverlapOccupiedBy(potentialOverlapOccupant))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool MeetsRequirements(bool allowedToHaveOccupiedCells, bool allowedToHaveDeadCells, bool allowStickyCells)
    {
        if (allowedToHaveOccupiedCells && allowedToHaveDeadCells && allowStickyCells)
        {
            return true;
        }
        for (int i = 0; i < this.m_widthInCells; i++)
        {
            for (int j = 0; j < this.m_heightInCells; j++)
            {
                if (!allowedToHaveOccupiedCells && this.Cells[i][j].Occupied)
                {
                    return false;
                }
                if (!allowedToHaveDeadCells && this.Cells[i][j].Dead)
                {
                    return false;
                }
                if (!allowStickyCells && this.Cells[i][j].IsSticky)
                {
                    return false;
                }
                if (this.Cells[i][j].IsKeyhole && !this.Cells[i][j].IsUnlocked)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool SharesXorYOverlap(MetaCell compareTo)
    {
        return this.Anchor.XIndex == compareTo.Anchor.XIndex || this.OppositeAnchor.XIndex == compareTo.OppositeAnchor.XIndex || this.Anchor.YIndex == compareTo.Anchor.YIndex || this.OppositeAnchor.YIndex == compareTo.OppositeAnchor.YIndex || (this.Anchor.XIndex > compareTo.Anchor.XIndex && this.Anchor.XIndex < compareTo.OppositeAnchor.XIndex) || (this.OppositeAnchor.XIndex > compareTo.Anchor.XIndex && this.OppositeAnchor.XIndex < compareTo.OppositeAnchor.XIndex) || (this.Anchor.YIndex > compareTo.Anchor.YIndex && this.Anchor.YIndex < compareTo.OppositeAnchor.YIndex) || (this.OppositeAnchor.YIndex > compareTo.Anchor.YIndex && this.OppositeAnchor.YIndex < compareTo.OppositeAnchor.YIndex);
    }

    public float GetCellSeparationInCellRings(MetaCell otherCell)
    {
        Vector2 vector = GridCellsMgr.MapWorldToGrid(this.Center);
        Vector2 vector2 = GridCellsMgr.MapWorldToGrid(otherCell.Center);
        float num = vector.x - vector2.x;
        float num2 = vector.y - vector2.y;
        num = Math.Abs(num);
        num2 = Math.Abs(num2);
        return Math.Max(num, num2);
    }

    public bool IsCloserToInCellRingCount(MetaCell otherCell, MetaCell compareTo)
    {
        float cellSeparationInCellRings = this.GetCellSeparationInCellRings(compareTo);
        float cellSeparationInCellRings2 = otherCell.GetCellSeparationInCellRings(compareTo);
        return cellSeparationInCellRings + 0.001f < cellSeparationInCellRings2;
    }

    public bool IsOverlapObject(ObjectForDraw obj)
    {
        return this.Cells[0][0].OverlapOccupant == obj;
    }

    public bool OverlapsLeftwardOn(MetaCell otherMetaCell)
    {
        return otherMetaCell == null || (this.m_xCellIndexLowerLeft == otherMetaCell.m_xCellIndexLowerLeft && this.m_widthInCells == otherMetaCell.m_widthInCells) || this.CellIndex_Right < otherMetaCell.CellIndex_Right;
    }

    public bool Equals(MetaCell otherMetaCell)
    {
        return otherMetaCell != null && (otherMetaCell.m_widthInCells == this.m_widthInCells && otherMetaCell.m_heightInCells == this.m_heightInCells && otherMetaCell.m_xCellIndexLowerLeft == this.m_xCellIndexLowerLeft) && otherMetaCell.m_yCellIndexLowerLeft == this.m_yCellIndexLowerLeft;
    }
}
