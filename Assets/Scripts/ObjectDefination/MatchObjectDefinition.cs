using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Serialization;

public enum DataLoadStateID
{
    MoreDataToLoad,
    AllDataLoaded
}

public class MatchObjectDefinition
{
    public bool Draggable;
    public bool Selectable;
    public int WidthInTiles = 1;
    public int HeightInTiles = 1;
    public bool HideInfoAndHighlight;
    public MatchRecipe MatchRecipe;
    public bool RequiresCellPlacement = true;
    public string Selected_GameTip = string.Empty;
    public static Dictionary<string, MatchObjectDefinition> Definitions = new Dictionary<string, MatchObjectDefinition>();
    public string PrefabName;
    public static int currentLoadRow = 0;
    public bool ConfirmOnTap;
    public bool CanDropFarOutOfBounds = false;
    public bool DragonBreakable;
    public LootTableRef _harvestLootRef;
    public bool HarvestRequiresDeadLand;
    public int MaxConcurrentHarvesters = 1;
    public int HarvestCharges;
    public float ZPush;
    public MethodInfo Event_CreatedFunction;
    public MethodInfo Event_DestroyedFunction;
    public int ItemLevel = 1;
    public int DragonPower;
    public bool InstaDeathOnDie;
    public LootTableRef _deathLootTableRef;
    public bool ShowTapArrowBeforeFirstTap;
    public bool EverTapped;
    //public OnTapBehaviorDefinition TapBehavior;
    public bool ShrinkWithHarvest;
    public RangeF LifetimeRange;


    public bool Matchable
    {
        get
        {
            return this.MatchRecipe != null;
        }
    }

    public LootTable HarvestLoot
    {
        get
        {
            return (this._harvestLootRef == null) ? null : this._harvestLootRef.LootTable;
        }
    }

    public bool HarvestIsExhaustible
    {
        get
        {
            return this.HarvestCharges > 0;
        }
    }

    public LootTable DeathLootTable
    {
        get
        {
            return (this._deathLootTableRef == null) ? null : this._deathLootTableRef.LootTable;
        }
    }

    public bool DiesAfterTimeout
    {
        get
        {
            return this.LifetimeRange != null;
        }
    }


    public ObjectForDraw GenerateInMetaCellPrincess(MetaCell target, bool isLevelLoad, bool isFromFreshMapData = false)
    {
        if (target.Occupied)
        {
            return null;
        }
        ObjectForDraw drawnObject = ObjectForDraw.Create(this.PrefabName, null, -0.5f);
        drawnObject.DefineRootPositionPrincess(target.X, target.Y);
        if (drawnObject.RequiresCellPlacement)
        {
            drawnObject.OccupyMetaCell(target);
        }
        return drawnObject;
    }

    public void LoadRowBaseData(string prefabName)
    {
        if(prefabName == "Life_Particle_1_Root")
        {
            this.PrefabName = prefabName;
            this.Draggable = false;
            this.Selectable = false;
            this.RequiresCellPlacement = false;
        }
        else
        {
            this.PrefabName = prefabName;
            this.Draggable = true;
            this.Selectable = true;
        }
        if (prefabName == "Hero_MidasTree")
        {
            this.WidthInTiles = 2;
            this.HeightInTiles = 2;
        }
        if (prefabName == "Hero_Rainbow")
        {
            this.WidthInTiles = 3;
            this.HeightInTiles = 2;
        }
        MatchRecipe.MatchRecipes.TryGetValue(this.PrefabName, out this.MatchRecipe);
    }

    public static void InsertDefinitionIntoDictionaryPrincess(MatchObjectDefinition matchObjectDefinition)
    {
        if (MatchObjectDefinition.Definitions.ContainsKey(matchObjectDefinition.PrefabName))
        {
            return;
        }
        else
        {
            MatchObjectDefinition.Definitions.Add(matchObjectDefinition.PrefabName, matchObjectDefinition);
        }
    }

    public static DataLoadStateID _LoadRowBaseData(string prefabName)
    {
        MatchObjectDefinition matchObjectDefinition = new MatchObjectDefinition();
        matchObjectDefinition.LoadRowBaseData(prefabName);
        MatchObjectDefinition.InsertDefinitionIntoDictionaryPrincess(matchObjectDefinition);
        return DataLoadStateID.MoreDataToLoad;
    }

    public static void LoadMatchObjectDefinitionsPrincess()
    {
        MatchRecipe.LoadRecipeDataPrincess();

        MatchObjectDefinition._LoadRowBaseData("MonsterHouse_6");
        MatchObjectDefinition._LoadRowBaseData("Key_Cloud_Dungeon");
        MatchObjectDefinition._LoadRowBaseData("Princess_Crimson_0");
        MatchObjectDefinition._LoadRowBaseData("Princess_Crimson_1_Root");
        MatchObjectDefinition._LoadRowBaseData("Princess_Crimson_3_Root");
        MatchObjectDefinition._LoadRowBaseData("Princess_Crimson_4_Root");
    }

    public bool CheckForCategoryPrincess(CategoryID category)
    {
        return false;//this.Categories != null && this.Categories.Contains(category);
    }

    public List<string> RetrieveMatchOutputListPrincess()
    {
        if (!this.Matchable)
        {
            return null;
        }
        return this.MatchRecipe.RetrieveOutputPrefabsPrincess();
    }

    public ObjectForDraw GenerateInMetaCellPrincess(MetaCell target)
    {
        return this.GenerateInMetaCellPrincess(target, false, false);
    }
}
