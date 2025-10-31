using UnityEngine;

/// <summary>
/// Item pickup that can be collected by player
/// </summary>
public class ItemPickup : MonoBehaviour
{
    [Header("Item Settings")]
    [SerializeField] private Item item;
    [SerializeField] private int quantity = 1;
    [SerializeField] private float pickupRange = 1.5f;
    
    private Transform player;
    private bool isCollected = false;
    
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }
    
    void Update()
    {
        if (player == null || isCollected) return;
        
        float distance = Vector3.Distance(transform.position, player.position);
        
        if (distance <= pickupRange)
        {
            // Automatic pickup or press F to pickup
            if (Input.GetKeyDown(KeyCode.F) || true) // Set to true for auto-pickup
            {
                PickupItem();
            }
        }
    }
    
    void PickupItem()
    {
        InventorySystem inventory = player.GetComponent<InventorySystem>();
        if (inventory != null)
        {
            if (inventory.AddItem(item, quantity))
            {
                Debug.Log($"Picked up {quantity}x {item.itemName}");
                isCollected = true;
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Inventory is full!");
            }
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, pickupRange);
    }
}
