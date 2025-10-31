using UnityEngine;

/// <summary>
/// Example script showing how to use the RPG systems together
/// This is a reference implementation - attach to a test object to see how everything connects
/// </summary>
public class RPGSystemsExample : MonoBehaviour
{
    [Header("Example Configuration")]
    [SerializeField] private Item examplePotion;
    [SerializeField] private Weapon exampleWeapon;
    [SerializeField] private Quest exampleQuest;
    
    void Start()
    {
        Debug.Log("=== RPG Systems Example ===");
        DemonstratePlayerSystem();
        DemonstrateInventorySystem();
        DemonstrateCombatSystem();
        DemonstrateQuestSystem();
        DemonstrateSaveSystem();
    }
    
    void DemonstratePlayerSystem()
    {
        Debug.Log("\n--- Player System Example ---");
        
        // Find player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogWarning("No player found! Create a GameObject with 'Player' tag.");
            return;
        }
        
        // Get player stats
        CharacterStats stats = player.GetComponent<CharacterStats>();
        if (stats != null)
        {
            Debug.Log($"Player Level: {stats.Level}");
            Debug.Log($"Player HP: {stats.CurrentHealth}/{stats.MaxHealth}");
            Debug.Log($"Player MP: {stats.CurrentMana}/{stats.MaxMana}");
        }
        
        // Get player controller
        PlayerController controller = player.GetComponent<PlayerController>();
        if (controller != null)
        {
            Debug.Log("PlayerController found - use WASD to move, Shift to run");
        }
    }
    
    void DemonstrateInventorySystem()
    {
        Debug.Log("\n--- Inventory System Example ---");
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;
        
        InventorySystem inventory = player.GetComponent<InventorySystem>();
        if (inventory != null)
        {
            // Example: Add items to inventory
            if (examplePotion != null)
            {
                bool added = inventory.AddItem(examplePotion, 3);
                Debug.Log($"Added 3 potions to inventory: {added}");
            }
            
            if (exampleWeapon != null)
            {
                bool added = inventory.AddItem(exampleWeapon, 1);
                Debug.Log($"Added weapon to inventory: {added}");
            }
            
            // Example: Use item from inventory slot
            // inventory.UseItem(0); // Use item in first slot
        }
        else
        {
            Debug.LogWarning("InventorySystem not found on player!");
        }
    }
    
    void DemonstrateCombatSystem()
    {
        Debug.Log("\n--- Combat System Example ---");
        
        // Combat system is a singleton
        if (CombatSystem.Instance == null)
        {
            Debug.LogWarning("CombatSystem not found! Create a GameObject with CombatSystem component.");
            return;
        }
        
        // Example: Simulate combat between player and enemy
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        
        if (player != null && enemy != null)
        {
            CharacterStats playerStats = player.GetComponent<CharacterStats>();
            CharacterStats enemyStats = enemy.GetComponent<CharacterStats>();
            
            if (playerStats != null && enemyStats != null)
            {
                // Calculate damage
                int damage = CombatSystem.Instance.CalculateDamage(playerStats, enemyStats);
                Debug.Log($"Player would deal {damage} damage to enemy");
                
                // Check hit chance
                bool hits = CombatSystem.Instance.CheckHit();
                Debug.Log($"Attack hits: {hits}");
                
                // Check critical
                bool isCrit = CombatSystem.Instance.CheckCritical();
                Debug.Log($"Critical hit: {isCrit}");
                
                // Perform actual attack (commented out to avoid changing game state)
                // CombatSystem.Instance.PerformAttack(playerStats, enemyStats);
            }
        }
        else
        {
            Debug.LogWarning("Need both Player and Enemy GameObjects with tags to demonstrate combat");
        }
    }
    
    void DemonstrateQuestSystem()
    {
        Debug.Log("\n--- Quest System Example ---");
        
        if (exampleQuest != null)
        {
            Debug.Log($"Quest: {exampleQuest.questName}");
            Debug.Log($"Description: {exampleQuest.description}");
            Debug.Log($"Experience Reward: {exampleQuest.experienceReward}");
            
            // Example: Update quest progress
            if (exampleQuest.goals != null && exampleQuest.goals.Length > 0)
            {
                Debug.Log($"First goal: {exampleQuest.goals[0].description}");
                Debug.Log($"Progress: {exampleQuest.goals[0].currentAmount}/{exampleQuest.goals[0].requiredAmount}");
                
                // Increment progress (commented to avoid changing state)
                // exampleQuest.goals[0].currentAmount++;
                // exampleQuest.CheckCompletion();
            }
        }
        else
        {
            Debug.LogWarning("No example quest assigned! Create a Quest ScriptableObject and assign it.");
        }
    }
    
    void DemonstrateSaveSystem()
    {
        Debug.Log("\n--- Save System Example ---");
        
        if (SaveSystem.Instance == null)
        {
            Debug.LogWarning("SaveSystem not found! Create a GameObject with SaveSystem component.");
            return;
        }
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            CharacterStats stats = player.GetComponent<CharacterStats>();
            if (stats != null)
            {
                // Example: Save game (commented to avoid creating save file)
                // SaveSystem.Instance.SavePlayerData(stats, player.transform.position);
                Debug.Log("To save game, call: SaveSystem.Instance.SavePlayerData(stats, position)");
                
                // Example: Load game
                // int level, health, mana;
                // Vector3 position;
                // bool loaded = SaveSystem.Instance.LoadPlayerData(out level, out health, out mana, out position);
                Debug.Log("To load game, call: SaveSystem.Instance.LoadPlayerData(...)");
            }
        }
    }
    
    // Example: Using systems in gameplay
    void Update()
    {
        // Example hotkeys for testing systems
        if (Input.GetKeyDown(KeyCode.H))
        {
            // Heal player
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                CharacterStats stats = player.GetComponent<CharacterStats>();
                if (stats != null)
                {
                    stats.Heal(20);
                    Debug.Log("Healed 20 HP");
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            // Level up player
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                CharacterStats stats = player.GetComponent<CharacterStats>();
                if (stats != null)
                {
                    stats.GainExperience(1000);
                    Debug.Log("Gained 1000 XP");
                }
            }
        }
    }
}
