using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum CategoryID
{
    NONE,
    ANY,
    Test,
    AlreadyHasWinParticles,
    Bushes,
    Coins,
    CoinStorage,
    Chest_Red,
    Chest_Nature,
    Chest_Crystal,
    Chest_Purple,
    Chest_SuperNest,
    Chest_MegaNest,
    Chest_ValueTest,
    Clouds,
    DeadPlants,
    DeadTrees,
    DemonGates,
    Dragons,
    DragonPortals,
    DragonTrees,
    Ducks,
    Eggs,
    EggBankDropPremium,
    EggBankDropRare,
    EggChests,
    Fruit,
    FruitTrees,
    FloatingLifeOrbs,
    Grass,
    HealingStatues,
    HideLootInfoButtonInBuyConf,
    LifeFlowers,
    LifeFlowerSeeds,
    LifeParticles,
    LifeTrees,
    LifelessRocks,
    LifeOrbs,
    LivingStones,
    Lvl1Dragons,
    Lvl2Dragons,
    Lvl3Dragons,
    Lvl4Dragons,
    Lvl7Dragons,
    Lvl8Dragons,
    Lvl9Dragons,
    Lvl10Dragons,
    LootOrbs,
    MonsterHouse,
    MonsterIdol,
    Mountains,
    Mushrooms,
    MushroomCaps,
    MysteryEggs,
    Nests,
    NestVaults,
    NormalFallenStars,
    NotInEvents,
    PetrifiedZomblins,
    PrismFlowers,
    Riches,
    Seeds,
    StarterBundle_1,
    StoneBricks,
    StoneStorage,
    TapOnDeadDrop,
    TimedChests,
    Totems,
    TreasureChests,
    MoonChests,
    GoldChests,
    DangerousChests,
    OccultChests,
    SpectralChests,
    Wonders,
    Wood,
    Zomblins,
    ZomblinCaves,
    ZomblinSpawner,
    AlarmBonuses,
    ForgottenFlowers,
    AncientObjects,
    DropTest,
    Merge_LockedT1_A,
    Merge_LockedT1_B,
    Merge_LockedT1_C,
    Merge_LockedT1_D,
    Merge_LockedT2_A,
    Merge_LockedT2_B,
    Merge_LockedT2_C,
    Merge_LockedT2_D,
    Merge_LockedT3_A,
    Merge_LockedT3_B,
    Merge_LockedT3_C,
    Merge_LockedT3_D,
    Merge_LockedT4_A,
    Merge_LockedT4_B,
    Merge_LockedT4_C,
    Merge_LockedT4_D
}

public class MatchRecipe
{
    public CategoryID inputCategory;
    public WeightedList<MatchOutput> additionalChanceOutputs;
    public float chanceOfAChanceDrop;
    public bool defaultDropsEvenIfChanceDrops;
    public string inputPrefabName;
    public MatchOutput defaultOutput;
    public static Dictionary<string, MatchRecipe> MatchRecipes = new Dictionary<string, MatchRecipe>();

    public bool HasInputCategory
    {
        get
        {
            //return this.inputCategory != CategoryID.NONE;
            return false;
        }
    }

    public List<string> RetrieveOutputPrefabsPrincess()
    {
        List<string> list = new List<string>();
        MatchOutput matchOutput = null;
        if (this.additionalChanceOutputs != null && GameMgr.Chance(this.chanceOfAChanceDrop))
        {
            matchOutput = this.additionalChanceOutputs.GetRandomElementWeighted();
        }
        if (matchOutput == null || this.defaultDropsEvenIfChanceDrops)
        {
            list.Add(this.defaultOutput.RetrieveOutputPrincess());
        }
        if (matchOutput != null)
        {
            int num = matchOutput.dropAmountRange.Random();
            for (int i = 0; i < num; i++)
            {
                list.Add(matchOutput.RetrieveOutputPrincess());
            }
        }
        if (list.Count == 0)
        {
            list.Add(this.defaultOutput.RetrieveOutputPrincess());
        }
        return list;
    }

    public MatchRecipe(string inputPrefabName,string outputPrefabName)
    {
        this.inputPrefabName = inputPrefabName;
        this.defaultOutput = new MatchOutput(outputPrefabName, new RangeI(1, 1));
    }

    public static void LoadRecipeDataPrincess()
    {
        MatchRecipe.MatchRecipes.Add("Treasure_Chest", new MatchRecipe("Treasure_Chest", "Treasure_Chest_2"));
        MatchRecipe.MatchRecipes.Add("Treasure_Chest_2", new MatchRecipe("Treasure_Chest_2", "Treasure_Chest_3"));
        MatchRecipe.MatchRecipes.Add("Treasure_Chest_3", new MatchRecipe("Treasure_Chest_3", "Treasure_Chest_5"));
    }
}
