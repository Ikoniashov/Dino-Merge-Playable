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
            fogs[5][4].prefabName = "Princess_Crimson_0";
            fogs[5][3].prefabName = "Princess_Crimson_0";
            fogs[4][4].prefabName = "Princess_Crimson_0";
            fogs[4][3].prefabName = "Princess_Crimson_0";
            fogs[7][4].prefabName = "Princess_Crimson_0";
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    if (fogs[i][j] == null) Debug.Log(i + " " + j);
                    fogs[i][j].prefabName = "Princess_Crimson_0";
                }
            }
        }
        else
        {
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 3; j <= 3; j++)
                {
                    if (i == 2 || i == 3) continue;
                    fogs[i][j].prefabName = "Princess_Crimson_0";
                }
            }

            for (int i = 2; i <= 6; i++)
            {
                for (int j = 4; j <= 5; j++)
                {
                    if ((i == 2 && j == 4) || (i == 3 && j == 4)) continue;
                    fogs[i][j].prefabName = "Princess_Crimson_0";
                }
            }

            for (int i = 3; i <= 7; i++)
            {
                for (int j = 6; j <= 7; j++)
                {
                    fogs[i][j].prefabName = "Princess_Crimson_0";
                }
            }

            for (int i = 4; i <= 8; i++)
            {
                for (int j = 8; j <= 8; j++)
                {
                    if (i == 6) continue;
                    fogs[i][j].prefabName = "Princess_Crimson_0";
                }
            }
        }
    }

    public static void InitializePrefabInFogs_1()
    {
        
    }
}
