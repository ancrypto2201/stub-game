using UnityEngine;

/// <summary>
/// Weapon item with attack power
/// </summary>
[CreateAssetMenu(fileName = "New Weapon", menuName = "RPG/Items/Weapon")]
public class Weapon : Item
{
    [Header("Weapon Stats")]
    public int attackPower = 10;
    public float attackSpeed = 1f;
    public float attackRange = 1.5f;
    
    [Header("Weapon Type")]
    public WeaponType weaponType;
    
    public enum WeaponType
    {
        Sword,
        Axe,
        Bow,
        Staff,
        Dagger
    }
    
    public override void Use()
    {
        base.Use();
        Debug.Log($"Equipped {itemName}");
        
        // In a real implementation, you would:
        // 1. Unequip current weapon
        // 2. Equip this weapon
        // 3. Update player stats
        // 4. Update UI
    }
}
