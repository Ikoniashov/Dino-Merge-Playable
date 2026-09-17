using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public enum OOBErrorTypeID
{
    SuppressErrors,
    ShowIfLowerLeftAnchorIsOOB,
    ShowIfAnyOOB,
    ShowIfOverNullCell
}

public enum DeadCellSearchID
{
    Any,
    NeedsHealing
}

public class GridCellsMgr : MonoBehaviour
{
    public static GridCellsMgr Instance { get; private set; }

    public GridCell[][] cells;
    [HideInInspector] public List<GridCell> CellsInEmptyState = new List<GridCell>();
    [HideInInspector] public List<GridCell> CellsInLivingState = new List<GridCell>();
    [HideInInspector] public List<GridCell> EmptyCellsInLivingState = new List<GridCell>();
    [HideInInspector] public List<GridCell> AllGameCells = new List<GridCell>();
    [HideInInspector] public static float A = 1.202107f,B = -0.49975f, C = 0.261094f, D = 0.60745f;
    [HideInInspector] public int widthInCells,heightInCells;
    [HideInInspector] public static float AD_minus_BC = A * D - B * C;
    [HideInInspector] public Bounds boundsWideForOffGridObjects;
    [HideInInspector] public List<GridCell> CellsInDeadState = new List<GridCell>();


    public GridCell GetCell(int boardX, int boardY, bool errorOnOutofBounds, bool errorOnInternalNull)
    {
        if (boardX >= this.widthInCells || boardY >= this.heightInCells || boardX < 0 || boardY < 0)
        {
            if (errorOnOutofBounds)
            {
                Debug.LogError(string.Concat(new object[]
                {
                    "Trying to access GameBoard GridCell out of bounds: [",
                    boardX,
                    ", ",
                    boardY,
                    "]   :("
                }));
            }
            return null;
        }
        if (this.cells[boardX][boardY] == null && errorOnInternalNull)
        {
            Debug.LogError(string.Concat(new object[]
            {
                "Trying to access public null GameBoard GridCell at: [",
                boardX,
                ", ",
                boardY,
                "]   :("
            }));
        }
        return this.cells[boardX][boardY];
    }

    public GridCell GetCell(float worldX, float worldY, bool errorOnOutofBounds, bool errorOnInternalNull)
    {
        Vector2 vector = GridCellsMgr.MapWorldToGrid(new Vector2(worldX, worldY));
        return this.GetCell(Mathf.FloorToInt(vector.x), Mathf.FloorToInt(vector.y), errorOnOutofBounds, errorOnInternalNull);
    }

    public static Vector2 MapWorldToGrid(Vector2 worldCoords)
    {
        float x = (D * worldCoords.x - B * worldCoords.y) / AD_minus_BC;
        float y = (A * worldCoords.y - C * worldCoords.x) / AD_minus_BC;
        return new Vector2(x, y);
    }

    public static Vector2 MapGridToWorld(float xInGridCoords, float yInGridCoords)
    {
        float x = GridCellsMgr.A * xInGridCoords + GridCellsMgr.B * yInGridCoords;
        float y = GridCellsMgr.C * xInGridCoords + GridCellsMgr.D * yInGridCoords;
        return new Vector2(x, y);
    }

    public void InitializeCellArrayPrincess()
    {
        this.cells = new GridCell[this.widthInCells][];
        for (int i = 0; i < this.widthInCells; i++)
        {
            this.cells[i] = new GridCell[this.heightInCells];
        }
    }

    public void SpawnCellPrincess(string tilePrefabName, int xCellIndex, int yCellIndex)
    {
        GameObject gameObject = GameMgr.GenerateFromPrefabPrincess(tilePrefabName);
        GridCell component = gameObject.GetComponent<GridCell>();
        component.Initialize(this, xCellIndex, yCellIndex);
        if (xCellIndex < this.widthInCells && yCellIndex < this.heightInCells) this.cells[xCellIndex][yCellIndex] = component;
        else
        {
            widthInCells = Mathf.Max(this.widthInCells, xCellIndex + 1);
            heightInCells= Mathf.Max(this.heightInCells, yCellIndex + 1);
            GridCell[][] newCells = new GridCell[widthInCells][];
            // 复制原数组的内容到新数组
            for (int i = 0; i < cells.Length; i++)
            {
                // 确保新的行数组足够长
                newCells[i] = new GridCell[heightInCells];
                // 将原数组的内容复制到新数组中
                Array.Copy(cells[i], newCells[i], cells[i].Length);
            }
            // 如果新行数大于原数组的行数，初始化剩余的行
            for (int i = cells.Length; i < widthInCells; i++)
            {
                newCells[i] = new GridCell[heightInCells];
            }
            cells = newCells;
            this.cells[xCellIndex][yCellIndex] = component;
        }
        this.CellsInEmptyState.Add(component);
        this.EmptyCellsInLivingState.Add(component);
        this.CellsInLivingState.Add(component);
        this.AllGameCells.Add(component);
    }

    public void LoadGridCells()
    {
        InitializeCellArrayPrincess();
        if (GameMgr.Instance.isLandScape)
        {
            for (int i = 0; i < widthInCells; i++)
            {
                for (int j = 0; j < heightInCells; j++)
                {
                    if ((i + j) % 2 == 0) SpawnCellPrincess("Cell_Grass_Dark", i, j);
                    else SpawnCellPrincess("Cell_Grass_Light", i, j);
                }
            }
        }
        else
        {
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    if ((i + j) % 2 == 0) SpawnCellPrincess("Cell_Grass_Dark", i, j);
                    else SpawnCellPrincess("Cell_Grass_Light", i, j);
                }
            }

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 3; j <= 3; j++)
                {
                    if ((i + j) % 2 == 0) SpawnCellPrincess("Cell_Grass_Dark", i, j);
                    else SpawnCellPrincess("Cell_Grass_Light", i, j);
                }
            }

            for (int i = 2; i <= 6; i++)
            {
                for (int j = 4; j <= 5; j++)
                {
                    if ((i + j) % 2 == 0) SpawnCellPrincess("Cell_Grass_Dark", i, j);
                    else SpawnCellPrincess("Cell_Grass_Light", i, j);
                }
            }

            for (int i = 3; i <= 7; i++)
            {
                for (int j = 6; j <= 7; j++)
                {
                    if ((i + j) % 2 == 0) SpawnCellPrincess("Cell_Grass_Dark", i, j);
                    else SpawnCellPrincess("Cell_Grass_Light", i, j);
                }
            }

            for (int i = 4; i <= 8; i++)
            {
                for (int j = 8; j <= 9; j++)
                {
                    if ((i + j) % 2 == 0) SpawnCellPrincess("Cell_Grass_Dark", i, j);
                    else SpawnCellPrincess("Cell_Grass_Light", i, j);
                }
            }

            for (int i = 5; i <= 9; i++)
            {
                for (int j = 10; j <= 11; j++)
                {
                    if ((i + j) % 2 == 0) SpawnCellPrincess("Cell_Grass_Dark", i, j);
                    else SpawnCellPrincess("Cell_Grass_Light", i, j);
                }
            }

            for (int i = 6; i <= 10; i++)
            {
                for (int j = 12; j <= 12; j++)
                {
                    if ((i + j) % 2 == 0) SpawnCellPrincess("Cell_Grass_Dark", i, j);
                    else SpawnCellPrincess("Cell_Grass_Light", i, j);
                }
            }
        }

        EstablishAllCellDirectionalLinksPrincess();

        InitDeadCells();
    }

    public void InitDeadCells()
    {
        if (GameMgr.Instance.isLandScape)
        {
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    if (!(i <= 5 && i >= 4 && j <= 2))
                    {
                        cells[i][j].m_deathComponent = cells[i][j].transform.gameObject.AddComponent<FullofDeadObject>();
                        cells[i][j].m_deathComponent.InitializeDeadLevelPrincess(1, cells[i][j].m_deathComponent.gameObject, false);
                        CellsInDeadState.Add(cells[i][j]);
                    }
                }
            }

            for (int i = 9; i <= 12; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    cells[i][j].m_deathComponent = cells[i][j].transform.gameObject.AddComponent<FullofDeadObject>();
                    cells[i][j].m_deathComponent.InitializeDeadLevelPrincess(1, cells[i][j].m_deathComponent.gameObject, false);
                    CellsInDeadState.Add(cells[i][j]);
                }
            }
        }
        else
        {
            for (int i = 4; i <= 5; i++)
            {
                for (int j = 3; j <= 3; j++)
                {
                    cells[i][j].m_deathComponent = cells[i][j].transform.gameObject.AddComponent<FullofDeadObject>();
                    cells[i][j].m_deathComponent.InitializeDeadLevelPrincess(1, cells[i][j].m_deathComponent.gameObject, false);
                    CellsInDeadState.Add(cells[i][j]);
                }
            }

            for (int i = 4; i <= 6; i++)
            {
                for (int j = 4; j <= 4; j++)
                {
                    cells[i][j].m_deathComponent = cells[i][j].transform.gameObject.AddComponent<FullofDeadObject>();
                    cells[i][j].m_deathComponent.InitializeDeadLevelPrincess(1, cells[i][j].m_deathComponent.gameObject, false);
                    CellsInDeadState.Add(cells[i][j]);
                }
            }

            for (int i = 2; i <= 6; i++)
            {
                for (int j = 5; j <= 5; j++)
                {
                    cells[i][j].m_deathComponent = cells[i][j].transform.gameObject.AddComponent<FullofDeadObject>();
                    cells[i][j].m_deathComponent.InitializeDeadLevelPrincess(1, cells[i][j].m_deathComponent.gameObject, false);
                    CellsInDeadState.Add(cells[i][j]);
                }
            }

            for (int i = 3; i <= 7; i++)
            {
                for (int j = 6; j <= 7; j++)
                {
                    cells[i][j].m_deathComponent = cells[i][j].transform.gameObject.AddComponent<FullofDeadObject>();
                    cells[i][j].m_deathComponent.InitializeDeadLevelPrincess(1, cells[i][j].m_deathComponent.gameObject, false);
                    CellsInDeadState.Add(cells[i][j]);
                }
            }

            for (int i = 4; i <= 8; i++)
            {
                for (int j = 8; j <= 9; j++)
                {
                    if (i == 6 && j == 8) continue;
                    cells[i][j].m_deathComponent = cells[i][j].transform.gameObject.AddComponent<FullofDeadObject>();
                    cells[i][j].m_deathComponent.InitializeDeadLevelPrincess(1, cells[i][j].m_deathComponent.gameObject, false);
                    CellsInDeadState.Add(cells[i][j]);
                }
            }

            for (int i = 5; i <= 9; i++)
            {
                for (int j = 10; j <= 11; j++)
                {
                    cells[i][j].m_deathComponent = cells[i][j].transform.gameObject.AddComponent<FullofDeadObject>();
                    cells[i][j].m_deathComponent.InitializeDeadLevelPrincess(1, cells[i][j].m_deathComponent.gameObject, false);
                    CellsInDeadState.Add(cells[i][j]);
                }
            }

            for (int i = 6; i <= 10; i++)
            {
                for (int j = 12; j <= 12; j++)
                {
                    cells[i][j].m_deathComponent = cells[i][j].transform.gameObject.AddComponent<FullofDeadObject>();
                    cells[i][j].m_deathComponent.InitializeDeadLevelPrincess(1, cells[i][j].m_deathComponent.gameObject, false);
                    CellsInDeadState.Add(cells[i][j]);
                }
            }
        }
    }

    public void EstablishAllCellDirectionalLinksPrincess()
    {
        for (int i = 0; i < this.widthInCells; i++)
        {
            for (int j = 0; j < this.heightInCells; j++)
            {
                this.EstablishCellDirectionalLinksPrincess(i, j);
            }
        }
    }

    public void EstablishCellDirectionalLinksPrincess(int x, int y)
    {
        if (this.cells[x][y] == null)
        {
            return;
        }
        if (x > 0)
        {
            this.cells[x][y].m_left = this.cells[x - 1][y];
        }
        if (x < this.widthInCells - 1)
        {
            this.cells[x][y].m_right = this.cells[x + 1][y];
        }
        if (y != 0)
        {
            this.cells[x][y].m_down = this.cells[x][y - 1];
        }
        if (y < this.heightInCells - 1)
        {
            this.cells[x][y].m_up = this.cells[x][y + 1];
        }
        if (x > 0 && y < this.heightInCells - 1)
        {
            this.cells[x][y].m_leftup = this.cells[x - 1][y + 1];
        }
        if (x < this.widthInCells - 1 && y > 0)
        {
            this.cells[x][y].m_rightbottom = this.cells[x + 1][y - 1];
        }
        this.cells[x][y].InitWallsAndTufts();
    }

    public bool CheckIfMetaCellIsOverNullCellPrincess(int boardX, int boardY, int metaCellWidth, int metaCellHeight, bool errorIfNull)
    {
        for (int i = boardX; i < boardX + metaCellWidth; i++)
        {
            for (int j = boardY; j < boardY + metaCellHeight; j++)
            {
                if (this.cells[i][j] == null)
                {
                    if (errorIfNull)
                    {
                        
                    }
                    return true;
                }
            }
        }
        return false;
    }

    public bool CheckIfMetaCellIsOutOfBoundsOrOverNullCellPrincess(int boardX, int boardY, int metaCellWidth, int metaCellHeight, OOBErrorTypeID errorType)
    {
        if (boardX >= this.widthInCells || boardY >= this.heightInCells || boardX < 0 || boardY < 0)
        {
            if (errorType == OOBErrorTypeID.ShowIfLowerLeftAnchorIsOOB || errorType == OOBErrorTypeID.ShowIfAnyOOB)
            {
                
            }
            return true;
        }
        if (boardX + metaCellWidth - 1 >= this.widthInCells || boardY + metaCellHeight - 1 >= this.heightInCells)
        {
            if (errorType == OOBErrorTypeID.ShowIfAnyOOB)
            {
                
            }
            return true;
        }
        bool errorIfNull = errorType == OOBErrorTypeID.ShowIfOverNullCell || errorType == OOBErrorTypeID.ShowIfAnyOOB;
        return this.CheckIfMetaCellIsOverNullCellPrincess(boardX, boardY, metaCellWidth, metaCellHeight, errorIfNull);
    }

    public void LoadFogs()
    {
        if (GameMgr.Instance.isLandScape)
        {
            for (int i = 0; i <= 8; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    if (!(i >= 4 && i <= 8 && j >= 0 && j <= 3) || ((i == 4 && j == 3) || (i == 5 && j == 3) || (i == 7 && j == 3) || (i == 8 && j == 3)))
                    {
                        GameObject temp = SpawnEntitiesOffGrid("Fog_Cloud", i, j);
                        Fog fog = temp.GetComponent<Fog>();
                        fog.indexX = i; fog.indexY = j;
                        GameMgr.Instance.fogs_0.Add(fog);
                        Fog.fogs[i][j] = fog;
                        GridCellsMgr.Instance.cells[i][j].IsKeyhole = true;
                        GridCellsMgr.Instance.cells[i][j].KeyObject = temp;
                    }
                }
            }
            for (int i = 9; i <= 12; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    GameObject temp = SpawnEntitiesOffGrid("Fog_Cloud", i, j);
                    Fog fog = temp.GetComponent<Fog>();
                    fog.indexX = i; fog.indexY = j;
                    GameMgr.Instance.fogs_1.Add(fog);
                    Fog.fogs[i][j] = fog;
                    GridCellsMgr.Instance.cells[i][j].IsKeyhole = true;
                    GridCellsMgr.Instance.cells[i][j].KeyObject = temp;
                }
            }
        }
        else
        {
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 3; j <= 3; j++)
                {
                    if (i == 3) continue;
                    GameObject temp = SpawnEntitiesOffGrid("Fog_Cloud", i, j);
                    Fog fog = temp.GetComponent<Fog>();
                    fog.indexX = i; fog.indexY = j;
                    GameMgr.Instance.fogs_0.Add(fog);
                    Fog.fogs[i][j] = fog;
                    GridCellsMgr.Instance.cells[i][j].IsKeyhole = true;
                    GridCellsMgr.Instance.cells[i][j].KeyObject = temp;
                }
            }

            for (int i = 2; i <= 6; i++)
            {
                for (int j = 4; j <= 5; j++)
                {
                    GameObject temp = SpawnEntitiesOffGrid("Fog_Cloud", i, j);
                    Fog fog = temp.GetComponent<Fog>();
                    fog.indexX = i; fog.indexY = j;
                    GameMgr.Instance.fogs_0.Add(fog);
                    Fog.fogs[i][j] = fog;
                    GridCellsMgr.Instance.cells[i][j].IsKeyhole = true;
                    GridCellsMgr.Instance.cells[i][j].KeyObject = temp;
                }
            }

            for (int i = 3; i <= 7; i++)
            {
                for (int j = 6; j <= 7; j++)
                {
                    GameObject temp = SpawnEntitiesOffGrid("Fog_Cloud", i, j);
                    Fog fog = temp.GetComponent<Fog>();
                    fog.indexX = i; fog.indexY = j;
                    GameMgr.Instance.fogs_0.Add(fog);
                    Fog.fogs[i][j] = fog;
                    GridCellsMgr.Instance.cells[i][j].IsKeyhole = true;
                    GridCellsMgr.Instance.cells[i][j].KeyObject = temp;
                }
            }

            for (int i = 4; i <= 8; i++)
            {
                for (int j = 8; j <= 8; j++)
                {
                    GameObject temp = SpawnEntitiesOffGrid("Fog_Cloud", i, j);
                    Fog fog = temp.GetComponent<Fog>();
                    fog.indexX = i; fog.indexY = j;
                    GameMgr.Instance.fogs_0.Add(fog);
                    Fog.fogs[i][j] = fog;
                    GridCellsMgr.Instance.cells[i][j].IsKeyhole = true;
                    GridCellsMgr.Instance.cells[i][j].KeyObject = temp;
                }
            }

            for (int i = 4; i <= 8; i++)
            {
                for (int j = 9; j <= 9; j++)
                {
                    GameObject temp = SpawnEntitiesOffGrid("Fog_Cloud", i, j);
                    Fog fog = temp.GetComponent<Fog>();
                    fog.indexX = i; fog.indexY = j;
                    GameMgr.Instance.fogs_1.Add(fog);
                    Fog.fogs[i][j] = fog;
                    GridCellsMgr.Instance.cells[i][j].IsKeyhole = true;
                    GridCellsMgr.Instance.cells[i][j].KeyObject = temp;
                }
            }

            for (int i = 5; i <= 9; i++)
            {
                for (int j = 10; j <= 11; j++)
                {
                    GameObject temp = SpawnEntitiesOffGrid("Fog_Cloud", i, j);
                    Fog fog = temp.GetComponent<Fog>();
                    fog.indexX = i; fog.indexY = j;
                    GameMgr.Instance.fogs_1.Add(fog);
                    Fog.fogs[i][j] = fog;
                    GridCellsMgr.Instance.cells[i][j].IsKeyhole = true;
                    GridCellsMgr.Instance.cells[i][j].KeyObject = temp;
                }
            }

            for (int i = 6; i <= 10; i++)
            {
                for (int j = 12; j <= 12; j++)
                {
                    GameObject temp = SpawnEntitiesOffGrid("Fog_Cloud", i, j);
                    Fog fog = temp.GetComponent<Fog>();
                    fog.indexX = i; fog.indexY = j;
                    GameMgr.Instance.fogs_1.Add(fog);
                    Fog.fogs[i][j] = fog;
                    GridCellsMgr.Instance.cells[i][j].IsKeyhole = true;
                    GridCellsMgr.Instance.cells[i][j].KeyObject = temp;
                }
            }
        }

        Fog.InitializePrefabInFogs_0();
        Fog.InitializePrefabInFogs_1();
    }

    public void LoadEntities()
    {
        if (GameMgr.Instance.isLandScape)
        {
            LoadEntitiesCellFromMapDataPrincess("Hero_MagicTome", 6, 1);
        }
        else
        {
            LoadEntitiesCellFromMapDataPrincess("Hero_MagicTome", 3, 1);
        }

        LoadFogs();
    }

    public GameObject SpawnEntitiesOffGrid(string entityName, int xCellIndex, int yCellIndex)
    {
        if (string.IsNullOrEmpty(entityName)) return null;
        else
        {
            GameObject drawnObject = GameMgr.GenerateFromPrefabAtPrincess(entityName,this.transform.position);
            Vector2 vector = GridCellsMgr.MapGridToWorld((float)xCellIndex + 0.5f, (float)yCellIndex + 0.5f);
            drawnObject.transform.position = new Vector3(vector.x, vector.y, vector.y);
            if (entityName == "Fog_Cloud")
            {
                // The replacement fog tree has a bottom pivot, unlike the old cloud.
                drawnObject.transform.position = new Vector3(vector.x - 0.05f, vector.y - 0.25f, vector.y);
                GridCell cell = this.GetCell(xCellIndex, yCellIndex, false, false);
                if (cell != null && cell.Dead)
                {
                    SpriteRenderer treeRenderer = drawnObject.GetComponent<SpriteRenderer>();
                    SpriteRenderer groundRenderer = cell.GetComponent<SpriteRenderer>();
                    if (treeRenderer != null && groundRenderer != null)
                    {
                        treeRenderer.color = groundRenderer.color;
                    }
                }
            }
            return drawnObject;
        }
    }

    public void LoadEntitiesCellFromMapDataPrincess(string entityName, int xCellIndex, int yCellIndex)
    {
        if (string.IsNullOrEmpty(entityName))
        {
            return;
        }
        else
        {
            MatchObjectDefinition matchObjectDefinition = MatchObjectDefinition.Definitions[entityName];
            ObjectForDraw drawnObject = null;

            MetaCell metaCell = new MetaCell(xCellIndex, yCellIndex, matchObjectDefinition.WidthInTiles, matchObjectDefinition.HeightInTiles);
            //GridCell anchor = metaCell.Anchor;

            drawnObject = matchObjectDefinition.GenerateInMetaCellPrincess(metaCell, true, true);
            ObjectAnim.StartNewObjectAppearAnimationPrincess(drawnObject);

            if (drawnObject != null)
            {
                drawnObject.makeImmuneToDeathOnCreation = false;
            }
        }
    }

    public void AddCellToList(MatchObjectDefinition def,ref List<GridCell> list,int cellIndexX,int cellIndexY)
    {
        if (cellIndexX < widthInCells && cellIndexX >= 0 && cellIndexY < heightInCells && cellIndexY >= 0)
        {
            if ((cells[cellIndexX][cellIndexY] == null)) return;
            if (cells[cellIndexX][cellIndexY].IsKeyhole) return;
            if (cells[cellIndexX][cellIndexY].Occupant == null) list.Add(cells[cellIndexX][cellIndexY]);
            else
            {
                if (cells[cellIndexX][cellIndexY].Occupant.Definition != def ) list.Add(cells[cellIndexX][cellIndexY]);
            }
        }
    }

    public GridCell GetGridCellNear(ObjectForDraw objectForDraw)
    {
        if (objectForDraw.metaCell == null) return null;
        int x = objectForDraw.metaCell.Cells[0][0].XIndex;
        int y = objectForDraw.metaCell.Cells[0][0].YIndex;
        List<GridCell> list = new List<GridCell>();
        AddCellToList(objectForDraw.Definition, ref list, x - 1, y);
        AddCellToList(objectForDraw.Definition, ref list, x + 1, y);
        AddCellToList(objectForDraw.Definition, ref list, x, y - 1);
        AddCellToList(objectForDraw.Definition, ref list, x, y + 1);
        if (list != null && list.Count != 0)
        {
            GridCell randomElement = list[UnityEngine.Random.Range(0, list.Count)];
            return randomElement;
        }
        else return null;
    }

    public GridCell GetCellNear(float nearWorldX, float nearWorldY)
    {
        Vector2 vector = GridCellsMgr.MapWorldToGrid(new Vector2(nearWorldX, nearWorldY));
        GridCell cell = this.GetCell(Mathf.FloorToInt(vector.x), Mathf.FloorToInt(vector.y), false, false);
        if (cell)
        {
            return cell;
        }
        Vector2 a = new Vector2(nearWorldX, nearWorldY);
        float num = float.MaxValue;
        for (int i = 0; i < this.cells.Length; i++)
        {
            for (int j = 0; j < this.cells[i].Length; j++)
            {
                GridCell cell2 = this.cells[i][j];
                if (!(cell2 == null))
                {
                    float num2 = Vector2.Distance(a, cell2.Center);
                    if (num2 < num)
                    {
                        num = num2;
                        cell = cell2;
                    }
                }
            }
        }
        if (cell == null)
        {

        }
        return cell;
    }

    public int MaxCellsToBoardEdgeFromPrincess(GridCell start)
    {
        int a = Mathf.Max(start.XIndex, this.widthInCells - start.XIndex);
        int b = Mathf.Max(start.YIndex, this.heightInCells - start.YIndex);
        return Mathf.Max(a, b);
    }

    public MetaCell GetMetaCell_WithLowerLeftIndex(int lowerLeftXIndex, int lowerLeftYIndex, int metaWidth, int metaHeight, OOBErrorTypeID errorType)
    {
        if (this.CheckIfMetaCellIsOutOfBoundsOrOverNullCellPrincess(lowerLeftXIndex, lowerLeftYIndex, metaWidth, metaHeight, errorType))
        {
            return null;
        }
        return new MetaCell(lowerLeftXIndex, lowerLeftYIndex, metaWidth, metaHeight);
    }

    public List<MetaCell> GetMetaCellRing(GridCell lowerLeftAnchor, int anchorWidth, int anchorHeight, bool allowOverlapOfCenter, int radius, int metaWidth, int metaHeight, bool allowOccupiedCells, bool allowDeadCells, bool allowStickyCells, bool moveFront = false)
    {
        if (anchorWidth < 1)
        {
            anchorWidth = 1;
        }
        if (anchorHeight < 1)
        {
            anchorHeight = 1;
        }
        List<MetaCell> list = new List<MetaCell>();
        if (radius <= 0)
        {
            MetaCell metaCell_WithLowerLeftIndex = this.GetMetaCell_WithLowerLeftIndex(lowerLeftAnchor.XIndex, lowerLeftAnchor.YIndex, metaWidth, metaHeight, OOBErrorTypeID.ShowIfLowerLeftAnchorIsOOB);
            if (metaCell_WithLowerLeftIndex != null && metaCell_WithLowerLeftIndex.MeetsRequirements(allowOccupiedCells, allowDeadCells, allowStickyCells))
            {
                list.Add(metaCell_WithLowerLeftIndex);
            }
            return list;
        }
        int num = (!allowOverlapOfCenter) ? metaWidth : 1;
        int num2 = (!allowOverlapOfCenter) ? metaHeight : 1;
        int num3 = lowerLeftAnchor.XIndex - radius - (num - 1);
        int num4 = lowerLeftAnchor.XIndex + (anchorWidth - 1) + radius;
        int num5 = lowerLeftAnchor.YIndex - radius - (num2 - 1);
        int num6 = lowerLeftAnchor.YIndex + (anchorHeight - 1) + radius;
        int i = num3;
        int j = num6;
        while (i < num4)
        {
            MetaCell metaCell_WithLowerLeftIndex = this.GetMetaCell_WithLowerLeftIndex(i, j, metaWidth, metaHeight, OOBErrorTypeID.SuppressErrors);
            if (metaCell_WithLowerLeftIndex != null && metaCell_WithLowerLeftIndex.MeetsRequirements(allowOccupiedCells, allowDeadCells, allowStickyCells))
            {
                list.Add(metaCell_WithLowerLeftIndex);
            }
            i++;
        }
        while (j > num5)
        {
            MetaCell metaCell_WithLowerLeftIndex = this.GetMetaCell_WithLowerLeftIndex(i, j, metaWidth, metaHeight, OOBErrorTypeID.SuppressErrors);
            if (metaCell_WithLowerLeftIndex != null && metaCell_WithLowerLeftIndex.MeetsRequirements(allowOccupiedCells, allowDeadCells, allowStickyCells))
            {
                list.Add(metaCell_WithLowerLeftIndex);
            }
            j--;
        }
        while (i > num3)
        {
            MetaCell metaCell_WithLowerLeftIndex = this.GetMetaCell_WithLowerLeftIndex(i, j, metaWidth, metaHeight, OOBErrorTypeID.SuppressErrors);
            if (metaCell_WithLowerLeftIndex != null && metaCell_WithLowerLeftIndex.MeetsRequirements(allowOccupiedCells, allowDeadCells, allowStickyCells))
            {
                list.Add(metaCell_WithLowerLeftIndex);
            }
            i--;
        }
        while (j < num6)
        {
            MetaCell metaCell_WithLowerLeftIndex = this.GetMetaCell_WithLowerLeftIndex(i, j, metaWidth, metaHeight, OOBErrorTypeID.SuppressErrors);
            if (metaCell_WithLowerLeftIndex != null && metaCell_WithLowerLeftIndex.MeetsRequirements(allowOccupiedCells, allowDeadCells, allowStickyCells))
            {
                list.Add(metaCell_WithLowerLeftIndex);
            }
            j++;
        }

        if (moveFront)
        {
            if (list.Count != 0)
            {
                foreach (var item in list.ToList())
                {
                    if (item.Cells[0][0].YIndex > lowerLeftAnchor.YIndex) list.Remove(item);
                }
            }
        }

        return list;
    }

    public List<MetaCell> ObtainListWithRemovedNonAdjacentCellsPrincess(List<MetaCell> metaCells, MetaCell compareTo)
    {
        List<MetaCell> list = new List<MetaCell>();
        for (int i = 0; i < metaCells.Count; i++)
        {
            MetaCell metaCell = metaCells[i];
            if (metaCell.SharesXorYOverlap(compareTo))
            {
                list.Add(metaCell);
            }
        }
        return list;
    }

    public MetaCell GetMetaCellNear(Vector2 lowerLeftCellSearchAnchorWorld, int innerCellWidth, int innerCellHeight, bool allowOverlapOfCenter, int maxSearchCellRadius, int metaWidth, int metaHeight, CellProximitySearchTypeID searchType, CellAdjacencySearchTypeID adjacencyPreference, bool allowDeadCells, bool allowOccupiedCells, bool allowStickyCells, bool moveFront = false)
    {
        if (innerCellWidth < 1)
        {
            innerCellWidth = 1;
        }
        if (innerCellHeight < 1)
        {
            innerCellHeight = 1;
        }
        List<MetaCell> list = new List<MetaCell>();
        GridCell cellNear = this.GetCellNear(lowerLeftCellSearchAnchorWorld.x, lowerLeftCellSearchAnchorWorld.y);
        if (maxSearchCellRadius < 0)
        {
            maxSearchCellRadius = this.MaxCellsToBoardEdgeFromPrincess(cellNear);
        }
        for (int i = 0; i <= maxSearchCellRadius; i++)
        {
            List<MetaCell> metaCellRing = this.GetMetaCellRing(cellNear, innerCellWidth, innerCellHeight, allowOverlapOfCenter, i, metaWidth, metaHeight, allowOccupiedCells, allowDeadCells, allowStickyCells, moveFront);
            if (metaCellRing.Count != 0)
            {
                if (searchType == CellProximitySearchTypeID.PreferCloser)
                {
                    list = metaCellRing;
                    break;
                }
                if (searchType == CellProximitySearchTypeID.RandomFromAll)
                {
                    list.AddRange(metaCellRing);
                }
            }
        }
        if (adjacencyPreference == CellAdjacencySearchTypeID.PreferAdjacent)
        {
            List<MetaCell> listWithRemovedNonAdjacentCells = this.ObtainListWithRemovedNonAdjacentCellsPrincess(list, new MetaCell(cellNear.XIndex, cellNear.YIndex, innerCellWidth, innerCellHeight));
            if (listWithRemovedNonAdjacentCells.Count != 0)
            {
                list = listWithRemovedNonAdjacentCells;
            }
        }
        if (list.Count == 0)
        {
            return null;
        }
        return GameMgr.RandomElement<MetaCell>(list);
    }

    public MetaCell GetEmptyMetaCellNear(Vector2 lowerLeftCellSearchAnchorWorld, int innerCellWidth, int innerCellHeight, bool allowOverlapOfCenter, int maxSearchCellRadius, int metaWidth, int metaHeight, CellProximitySearchTypeID searchType, CellAdjacencySearchTypeID adjacencyPreference, bool allowDeadCells, bool allowStickyCells, bool moveFront = false)
    {
        return this.GetMetaCellNear(lowerLeftCellSearchAnchorWorld, innerCellWidth, innerCellHeight, allowOverlapOfCenter, maxSearchCellRadius, metaWidth, metaHeight, searchType, adjacencyPreference, allowDeadCells, false, allowStickyCells, moveFront);
    }

    public MetaCell GetEmptyMetaCellNear(MetaCell searchAround, bool allowOverlapOfCenter, int searchCellRadius, int metaWidth, int metaHeight, CellProximitySearchTypeID searchType, CellAdjacencySearchTypeID adjacencyPreference, bool allowDeadCells, bool allowStickyCells = true)
    {
        return this.GetEmptyMetaCellNear(searchAround.Anchor.Center, searchAround.m_widthInCells, searchAround.m_heightInCells, allowOverlapOfCenter, searchCellRadius, metaWidth, metaHeight, searchType, adjacencyPreference, allowDeadCells, allowStickyCells);
    }

    public bool WithinBoundsPrincess(int xIndex, int yIndex, bool alsoCheckForNullInternalCells)
    {
        return xIndex >= 0 && xIndex < this.widthInCells && yIndex >= 0 && yIndex < this.heightInCells && (!alsoCheckForNullInternalCells || !(this.cells[xIndex][yIndex] == null));
    }

    public int ObtainLowerLeftMetaCellCornerIndexPrincess(float metaCellCenterCoordinate, int dimensionSizeInCells)
    {
        int result;
        if (dimensionSizeInCells % 2 == 0)
        {
            metaCellCenterCoordinate -= (float)((dimensionSizeInCells - 2) / 2);
            float remainder = GameMgr.GetRemainder(metaCellCenterCoordinate);
            if (remainder > 0.5f)
            {
                result = (int)metaCellCenterCoordinate;
            }
            else
            {
                result = (int)metaCellCenterCoordinate - 1;
            }
        }
        else
        {
            metaCellCenterCoordinate -= (float)((dimensionSizeInCells - 1) / 2);
            result = (int)metaCellCenterCoordinate;
        }
        return result;
    }

    public MetaCell GetMetaCell_CenteredOn(float worldX, float worldY, int metaWidth, int metaHeight, bool errorIfOverNullCell)
    {
        Vector2 vector = GridCellsMgr.MapWorldToGrid(new Vector2(worldX, worldY));
        int num = this.ObtainLowerLeftMetaCellCornerIndexPrincess(vector.x, metaWidth);
        int num2 = this.ObtainLowerLeftMetaCellCornerIndexPrincess(vector.y, metaHeight);
        if (num < 0)
        {
            num = 0;
        }
        else if (num + metaWidth > this.widthInCells)
        {
            num = this.widthInCells - metaWidth;
        }
        if (num2 < 0)
        {
            num2 = 0;
        }
        else if (num2 + metaHeight > this.heightInCells)
        {
            num2 = this.heightInCells - metaHeight;
        }
        if (this.CheckIfMetaCellIsOverNullCellPrincess(num, num2, metaWidth, metaHeight, false))
        {
            Vector2 lowerLeftCellSearchAnchorWorld = GridCellsMgr.MapGridToWorld((float)num + 0.5f, (float)num2 + 0.5f);
            return this.GetMetaCellNear(lowerLeftCellSearchAnchorWorld, 1, 1, true, -1, metaWidth, metaHeight, CellProximitySearchTypeID.PreferCloser, CellAdjacencySearchTypeID.AllowAll, true, true, true);
        }
        return new MetaCell(num, num2, metaWidth, metaHeight);
    }

    public MetaCell GetMetaCell_CenteredOn(float worldX, float worldY, ObjectForDraw forObject, bool errorIfOverNullCell)
    {
        return this.GetMetaCell_CenteredOn(worldX, worldY, forObject.Definition.WidthInTiles, forObject.Definition.HeightInTiles, errorIfOverNullCell);
    }

    public bool WithinBoundsPrincess(float xCellSpace, float yCellSpace, bool alsoCheckForNullInternalCells)
    {
        return xCellSpace >= 0f && yCellSpace >= 0f && this.WithinBoundsPrincess((int)xCellSpace, (int)yCellSpace, alsoCheckForNullInternalCells);
    }

    public bool WithinWorldSpaceBoundsPrincess(float xWorld, float yWorld, bool alsoCheckForNullInternalCells)
	{
		Vector2 vector = GridCellsMgr.MapWorldToGrid(new Vector2(xWorld, yWorld));
		return this.WithinBoundsPrincess(vector.x, vector.y, alsoCheckForNullInternalCells);
	}

    public bool WithinWideWorldSpaceBoundsPrincess(Vector3 pos)
    {
        return this.boundsWideForOffGridObjects.Contains(pos);
    }

    public GridCell GetCell(float worldX, float worldY)
    {
        return this.GetCell(worldX, worldY, false, false);
    }

    public void RefreshOffGridMatchLocationsPrincess(List<ObjectForDraw> objectsOfType)
    {
        List<GridCell> list = new List<GridCell>();
        foreach (ObjectForDraw drawnObject in objectsOfType)
        {
            GridCell cell = this.GetCell(drawnObject.X, drawnObject.Y);
            if (!(cell == null))
            {
                if (!list.Contains(cell))
                {
                    cell.ClearOffGridMatchObjects();
                    list.Add(cell);
                }
                cell.AddOffGridMatchObject(drawnObject);
            }
        }
    }

    public bool WithinWorldSpaceBoundsPrincess(Vector2 pos, bool alsoCheckForNullInternalCells)
    {
        Vector2 vector = GridCellsMgr.MapWorldToGrid(pos);
        return this.WithinBoundsPrincess(vector.x, vector.y, alsoCheckForNullInternalCells);
    }

    public List<GridCell> ObtainCellRingPrincess(GridCell center, int radius)
    {
        List<GridCell> list = new List<GridCell>();
        if (radius <= 0)
        {
            list.Add(center);
            return list;
        }
        int num = radius * 2;
        int i = center.XIndex;
        int j = center.YIndex;
        i -= radius;
        j += radius;
        int num2 = i + num;
        int num3 = j;
        while (i < num2)
        {
            if (this.WithinBoundsPrincess(i, j, true))
            {
                list.Add(this.cells[i][j]);
            }
            i++;
        }
        num3 -= num;
        while (j > num3)
        {
            if (this.WithinBoundsPrincess(i, j, true))
            {
                list.Add(this.cells[i][j]);
            }
            j--;
        }
        num2 -= num;
        while (i > num2)
        {
            if (this.WithinBoundsPrincess(i, j, true))
            {
                list.Add(this.cells[i][j]);
            }
            i--;
        }
        num3 += num;
        while (j < num3)
        {
            if (this.WithinBoundsPrincess(i, j, true))
            {
                list.Add(this.cells[i][j]);
            }
            j++;
        }
        return list;
    }

    public void DeleteOccupiedCellsPrincess(ref List<GridCell> cells)
    {
        if (cells == null || cells.Count == 0)
        {
            return;
        }
        for (int i = cells.Count - 1; i >= 0; i--)
        {
            if (cells[i].Occupied)
            {
                cells.RemoveAt(i);
            }
        }
    }

    public void DeleteDeadCellsPrincess(ref List<GridCell> cells)
    {
        if (cells == null || cells.Count == 0)
        {
            return;
        }
        for (int i = cells.Count - 1; i >= 0; i--)
        {
            if (cells[i].DeathComponent != null)
            {
                cells.RemoveAt(i);
            }
        }
    }

    public GridCell ObtainEmptyCellNearPrincess(Vector2 nearPosition, int searchCellRadius, CellProximitySearchTypeID searchType, bool allowDeadCells)
    {
        List<GridCell> list = new List<GridCell>();
        GridCell cellNear = this.GetCellNear(nearPosition.x, nearPosition.y);
        if (searchCellRadius < 0)
        {
            searchCellRadius = this.MaxCellsToBoardEdgeFromPrincess(cellNear);
        }
        for (int i = 0; i <= searchCellRadius; i++)
        {
            List<GridCell> cellRing = this.ObtainCellRingPrincess(cellNear, i);
            this.DeleteOccupiedCellsPrincess(ref cellRing);
            if (!allowDeadCells)
            {
                this.DeleteDeadCellsPrincess(ref cellRing);
            }
            if (cellRing.Count != 0)
            {
                if (searchType == CellProximitySearchTypeID.PreferCloser)
                {
                    list = cellRing;
                    break;
                }
                if (searchType == CellProximitySearchTypeID.RandomFromAll)
                {
                    list.AddRange(cellRing);
                }
            }
        }
        if (list.Count == 0)
        {
            return null;
        }
        return GameMgr.RandomElement<GridCell>(list);
    }

    public Vector2 ObtainEmptyWorldPointNearPrincess(Vector2 nearPosition, int searchCellRadius, CellProximitySearchTypeID searchType, bool allowDeadCells)
    {
        GridCell emptyCellNear = this.ObtainEmptyCellNearPrincess(nearPosition, searchCellRadius, searchType, allowDeadCells);
        if (emptyCellNear == null)
        {
            return nearPosition;
        }
        float x = GameMgr.Random(emptyCellNear.Renderer.bounds.min.x, emptyCellNear.Renderer.bounds.max.x);
        float y = GameMgr.Random(emptyCellNear.Renderer.bounds.min.y, emptyCellNear.Renderer.bounds.max.y);
        return new Vector2(x, y);
    }

    public bool BoardCapacityExceededForPrincess(MatchObjectDefinition def)
    {
        if (!def.RequiresCellPlacement)
        {
            return false;
        }
        if (def.WidthInTiles == 1 && def.HeightInTiles == 1)
        {
            int num = this.EmptyCellsInLivingState.Count((GridCell cell) => cell != null && (!cell.IsKeyhole || cell.IsUnlocked));
            return num <= 2;
        }
        int num2 = def.WidthInTiles * def.HeightInTiles + 2;
        if (this.EmptyCellsInLivingState.Count < num2)
        {
            return true;
        }
        bool flag = false;
        for (int i = 0; i < this.EmptyCellsInLivingState.Count; i++)
        {
            GridCell cell2 = this.EmptyCellsInLivingState[i];
            if (cell2.XIndex + def.WidthInTiles <= this.widthInCells && cell2.YIndex + def.HeightInTiles <= this.heightInCells)
            {
                for (int j = cell2.XIndex; j < cell2.XIndex + def.WidthInTiles; j++)
                {
                    for (int k = cell2.YIndex; k < cell2.YIndex + def.HeightInTiles; k++)
                    {
                        if (this.cells[j][k] == null || !this.cells[j][k].EmptyAndAlive || (this.cells[j][k].IsKeyhole && !this.cells[j][k].IsUnlocked))
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                    {
                        break;
                    }
                }
                if (!flag)
                {
                    return false;
                }
                flag = false;
            }
        }
        return true;
    }

    public bool BoardCapacityExceededForPrincess(string prefabName)
    {
        return this.BoardCapacityExceededForPrincess(MatchObjectDefinition.Definitions[prefabName]);
    }

    public static Vector2 MapGridToWorld(Vector2 gridCoords)
    {
        return GridCellsMgr.MapGridToWorld(gridCoords.x, gridCoords.y);
    }

    public void EstablishDirectionalLinks_PlusNeighborsPrincess(int x, int y)
    {
        this.EstablishCellDirectionalLinksPrincess(x, y);
        if (this.WithinBoundsPrincess(x + 1, y, true))
        {
            this.EstablishCellDirectionalLinksPrincess(x + 1, y);
            this.cells[x + 1][y].InitWallsAndTufts();
        }
        if (this.WithinBoundsPrincess(x - 1, y, true))
        {
            this.EstablishCellDirectionalLinksPrincess(x - 1, y);
            this.cells[x - 1][y].InitWallsAndTufts();
        }
        if (this.WithinBoundsPrincess(x, y + 1, true))
        {
            this.EstablishCellDirectionalLinksPrincess(x, y + 1);
            this.cells[x][y + 1].InitWallsAndTufts();
        }
        if (this.WithinBoundsPrincess(x, y - 1, true))
        {
            this.EstablishCellDirectionalLinksPrincess(x, y - 1);
            this.cells[x][y - 1].InitWallsAndTufts();
        }
    }

    public void LoadVisibleCellDuringGameplayPrincess(int x, int y, string objectPrefabName = "")
    {
        if (objectPrefabName != "") GridCellsMgr.Instance.LoadEntitiesCellFromMapDataPrincess(objectPrefabName,x, y);
    }

    public List<GridCell> ObtainDeadCellsClosestToPrincess(Vector2 searchStart, int numToFind, DeadCellSearchID deadSearchType)
    {
        if (this.CellsInDeadState.Count == 0)
        {
            return null;
        }
        List<GridCell> list = new List<GridCell>(this.CellsInDeadState);
        List<GridCell> list2 = new List<GridCell>();
        bool flag = false;
        while (list2.Count < numToFind)
        {
            if (list.Count == 0 || flag)
            {
                break;
            }
            float num = float.MaxValue;
            GridCell cell = null;
            foreach (GridCell cell2 in list)
            {
                if (deadSearchType != DeadCellSearchID.NeedsHealing || cell2.GetComponent<FullofDeadObject>().NeedsMoreHealing)
                {
                    float sqrMagnitude = (cell2.Center - searchStart).sqrMagnitude;
                    if (sqrMagnitude < num)
                    {
                        num = sqrMagnitude;
                        cell = cell2;
                    }
                }
            }
            if (cell != null)
            {
                list2.Add(cell);
                list.Remove(cell);
            }
            else
            {
                flag = true;
            }
        }
        return list2;
    }


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        widthInCells = 13;
        heightInCells = 5;
    }
}
