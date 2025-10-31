using UnityEngine;

/// <summary>
/// Consumable item that can restore health or mana
/// </summary>
[CreateAssetMenu(fileName = "New Potion", menuName = "RPG/Items/Potion")]
public class Potion : Item
{
    public int healthRestore = 0;
    public int manaRestore = 0;
    
    public override void Use()
    {
        base.Use();
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            CharacterStats stats = player.GetComponent<CharacterStats>();
            if (stats != null)
            {
                if (healthRestore > 0)
                {
                    stats.Heal(healthRestore);
                    Debug.Log($"Restored {healthRestore} health");
                }
                
                if (manaRestore > 0)
                {
                    stats.RestoreMana(manaRestore);
                    Debug.Log($"Restored {manaRestore} mana");
                }
            }
        }
    }
}
