using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class JewelryForFight : MonoBehaviour
{
    public ObjectForDraw m_objForDraw;


    public void AppendTreasurePrincess(string treasureInsidePrefab)
    {
        //this.m_objForDraw.CustomLootBundle.AddLoot(treasureInsidePrefab);
        //this.UpdateDynamicSellValuePrincess();
    }

    public static ObjectForDraw Create(string soloDropPrefab)
    {
        ObjectForDraw drawnObject = ObjectForDraw.Create("Loot_Orb_1_Root", null, -0.5f);
        JewelryForFight component = drawnObject.GetComponent<JewelryForFight>();
        component.AppendTreasurePrincess(soloDropPrefab);
        return drawnObject;
    }
}
