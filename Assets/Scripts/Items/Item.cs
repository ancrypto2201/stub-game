using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Base item class for inventory system
/// All items in the game inherit from this
/// </summary>
[CreateAssetMenu(fileName = "New Item", menuName = "RPG/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;
    public int maxStackSize = 1;
    public ItemType itemType;
    
    public enum ItemType
    {
        Consumable,
        Weapon,
        Armor,
        Quest,
        Misc
    }
    
    public virtual void Use()
    {
        Debug.Log($"Using {itemName}");
    }
}
