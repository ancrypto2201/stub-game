using UnityEngine;

/// <summary>
/// Combat system manager
/// Handles turn-based combat or real-time combat calculations
/// </summary>
public class CombatSystem : MonoBehaviour
{
    public static CombatSystem Instance { get; private set; }
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    /// <summary>
    /// Calculate damage from attacker to defender
    /// </summary>
    public int CalculateDamage(CharacterStats attacker, CharacterStats defender)
    {
        // Basic damage formula: (Attack * AttackMultiplier) - Defense
        float attackMultiplier = Random.Range(0.8f, 1.2f); // Random variation
        int baseDamage = Mathf.RoundToInt(attacker.Attack * attackMultiplier);
        int finalDamage = Mathf.Max(baseDamage - defender.Defense, 1); // Minimum 1 damage
        
        return finalDamage;
    }
    
    /// <summary>
    /// Perform an attack from attacker to defender
    /// </summary>
    public void PerformAttack(CharacterStats attacker, CharacterStats defender)
    {
        int damage = CalculateDamage(attacker, defender);
        defender.TakeDamage(damage);
        
        Debug.Log($"{attacker.gameObject.name} attacks {defender.gameObject.name} for {damage} damage!");
    }
    
    /// <summary>
    /// Check if attack hits based on accuracy and evasion
    /// </summary>
    public bool CheckHit(float accuracy = 0.85f)
    {
        return Random.value <= accuracy;
    }
    
    /// <summary>
    /// Check for critical hit
    /// </summary>
    public bool CheckCritical(float critChance = 0.15f)
    {
        return Random.value <= critChance;
    }
}
