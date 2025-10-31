using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Inventory system for managing player items
/// </summary>
public class InventorySystem : MonoBehaviour
{
    [Header("Inventory Settings")]
    [SerializeField] private int maxSlots = 20;
    
    private List<ItemSlot> inventory = new List<ItemSlot>();
    
    [System.Serializable]
    public class ItemSlot
    {
        public Item item;
        public int quantity;
        
        public ItemSlot(Item item, int quantity)
        {
            this.item = item;
            this.quantity = quantity;
        }
    }
    
    void Start()
    {
        // Initialize inventory
        for (int i = 0; i < maxSlots; i++)
        {
            inventory.Add(null);
        }
    }
    
    public bool AddItem(Item item, int quantity = 1)
    {
        // Check if item already exists in inventory (for stackable items)
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i] != null && inventory[i].item == item)
            {
                if (inventory[i].quantity < item.maxStackSize)
                {
                    int spaceLeft = item.maxStackSize - inventory[i].quantity;
                    int amountToAdd = Mathf.Min(spaceLeft, quantity);
                    inventory[i].quantity += amountToAdd;
                    quantity -= amountToAdd;
                    
                    if (quantity <= 0)
                    {
                        Debug.Log($"Added {item.itemName} to inventory");
                        return true;
                    }
                }
            }
        }
        
        // Add to empty slot
        while (quantity > 0)
        {
            int emptySlot = FindEmptySlot();
            if (emptySlot >= 0)
            {
                int amountToAdd = Mathf.Min(item.maxStackSize, quantity);
                inventory[emptySlot] = new ItemSlot(item, amountToAdd);
                quantity -= amountToAdd;
            }
            else
            {
                Debug.Log("Inventory is full!");
                return false;
            }
        }
        
        Debug.Log($"Added {item.itemName} to inventory");
        return true;
    }
    
    public bool RemoveItem(Item item, int quantity = 1)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i] != null && inventory[i].item == item)
            {
                if (inventory[i].quantity >= quantity)
                {
                    inventory[i].quantity -= quantity;
                    
                    if (inventory[i].quantity <= 0)
                    {
                        inventory[i] = null;
                    }
                    
                    Debug.Log($"Removed {quantity} {item.itemName} from inventory");
                    return true;
                }
            }
        }
        
        Debug.Log($"Not enough {item.itemName} in inventory");
        return false;
    }
    
    public void UseItem(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < inventory.Count && inventory[slotIndex] != null)
        {
            inventory[slotIndex].item.Use();
            RemoveItem(inventory[slotIndex].item, 1);
        }
    }
    
    private int FindEmptySlot()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i] == null)
            {
                return i;
            }
        }
        return -1;
    }
    
    public List<ItemSlot> GetInventory()
    {
        return inventory;
    }
}
