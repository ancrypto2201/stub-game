using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI Manager for health and mana bars
/// </summary>
public class HealthManaUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider manaBar;
    [SerializeField] private Text healthText;
    [SerializeField] private Text manaText;
    
    [Header("Target")]
    [SerializeField] private CharacterStats targetStats;
    
    void Start()
    {
        if (targetStats == null)
        {
            // Try to find player stats
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                targetStats = player.GetComponent<CharacterStats>();
            }
        }
    }
    
    void Update()
    {
        if (targetStats == null) return;
        
        UpdateHealthBar();
        UpdateManaBar();
    }
    
    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.maxValue = targetStats.MaxHealth;
            healthBar.value = targetStats.CurrentHealth;
        }
        
        if (healthText != null)
        {
            healthText.text = $"{targetStats.CurrentHealth}/{targetStats.MaxHealth}";
        }
    }
    
    private void UpdateManaBar()
    {
        if (manaBar != null)
        {
            manaBar.maxValue = targetStats.MaxMana;
            manaBar.value = targetStats.CurrentMana;
        }
        
        if (manaText != null)
        {
            manaText.text = $"{targetStats.CurrentMana}/{targetStats.MaxMana}";
        }
    }
}
