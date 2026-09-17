using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/ObjectSet")]
public class ObjectSet : ScriptableObject
{
    public string Name;
    public Sprite RewardCardSprite;
    public List<ObjectMapping> Mappings;
}

[System.Serializable]
public class ObjectMapping
{
    public string GenericId;     // напр.: "item_1"
    public string ConcreteType;  // напр.: "Apple", "Chest", "GemLevel1"
}