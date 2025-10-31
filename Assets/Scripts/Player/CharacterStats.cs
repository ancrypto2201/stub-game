using UnityEngine;

/// <summary>
/// Base stats class for player and enemies
/// Handles health, mana, attack, defense, etc.
/// </summary>
public class CharacterStats : MonoBehaviour
{
    [Header("Basic Stats")]
    [SerializeField] private int level = 1;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int maxMana = 50;
    
    [Header("Combat Stats")]
    [SerializeField] private int attack = 10;
    [SerializeField] private int defense = 5;
    [SerializeField] private int magicPower = 5;
    
    [Header("Current Stats")]
    private int currentHealth;
    private int currentMana;
    private int currentExperience;
    
    public int Level => level;
    public int MaxHealth => maxHealth;
    public int MaxMana => maxMana;
    public int CurrentHealth => currentHealth;
    public int CurrentMana => currentMana;
    public int Attack => attack;
    public int Defense => defense;
    public int MagicPower => magicPower;
    
    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
    }
    
    public void TakeDamage(int damage)
    {
        int actualDamage = Mathf.Max(damage - defense, 1);
        currentHealth -= actualDamage;
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
    }
    
    public void RestoreMana(int amount)
    {
        currentMana = Mathf.Min(currentMana + amount, maxMana);
    }
    
    public bool UseMana(int amount)
    {
        if (currentMana >= amount)
        {
            currentMana -= amount;
            return true;
        }
        return false;
    }
    
    public void GainExperience(int exp)
    {
        currentExperience += exp;
        // Simple level up logic
        if (currentExperience >= level * 100)
        {
            LevelUp();
        }
    }
    
    private void LevelUp()
    {
        level++;
        maxHealth += 10;
        maxMana += 5;
        attack += 2;
        defense += 1;
        magicPower += 1;
        
        currentHealth = maxHealth;
        currentMana = maxMana;
        
        Debug.Log($"Level Up! Now level {level}");
    }
    
    private void Die()
    {
        Debug.Log($"{gameObject.name} has died!");
        // Implement death logic here
    }
}
