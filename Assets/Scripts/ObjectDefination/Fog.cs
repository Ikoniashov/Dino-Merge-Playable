using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    public int indexX;
    public int indexY;
    public string prefabName;
    public static Fog[][] fogs;


    public static void InitializeFogArray()
    {
        fogs = new Fog[GridCellsMgr.Instance.widthInCells][];
        for (int i = 0; i < GridCellsMgr.Instance.widthInCells; i++)
        {
            fogs[i] = new Fog[GridCellsMgr.Instance.heightInCells];
        }
    }

    public static void InitializePrefabInFogs_0()
    {
        if (GameMgr.Instance.isLandScape)
        {
            fogs[4][0].prefabName = "Green_Tree_1";
            fogs[4][1].prefabName = "Green_Tree_1";
            fogs[5][2].prefabName = "Green_Tree_2";
            fogs[6][2].prefabName = "Green_Tree_2";
            fogs[8][1].prefabName = "Green_Tree_3";
            fogs[8][2].prefabName = "Green_Tree_3";
        }
        else
        {
            fogs[4][0].prefabName = "Green_Tree_1";
            fogs[4][1].prefabName = "Green_Tree_1";
            fogs[3][1].prefabName = "Green_Tree_2";
            fogs[3][2].prefabName = "Green_Tree_2";
            fogs[1][2].prefabName = "Green_Tree_3";
            fogs[2][2].prefabName = "Green_Tree_3";
        }
    }

    public static void InitializePrefabInFogs_1()
    {
        
    }
}
