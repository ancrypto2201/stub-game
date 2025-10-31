using UnityEngine;

/// <summary>
/// Save and load system for player data
/// Uses PlayerPrefs for simple persistence
/// </summary>
public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance { get; private set; }
    
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
    /// Save player data
    /// </summary>
    public void SavePlayerData(CharacterStats stats, Vector3 position)
    {
        // Save stats
        PlayerPrefs.SetInt("PlayerLevel", stats.Level);
        PlayerPrefs.SetInt("PlayerHealth", stats.CurrentHealth);
        PlayerPrefs.SetInt("PlayerMana", stats.CurrentMana);
        
        // Save position
        PlayerPrefs.SetFloat("PlayerPosX", position.x);
        PlayerPrefs.SetFloat("PlayerPosY", position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", position.z);
        
        PlayerPrefs.Save();
        Debug.Log("Game saved!");
    }
    
    /// <summary>
    /// Load player data
    /// </summary>
    public bool LoadPlayerData(out int level, out int health, out int mana, out Vector3 position)
    {
        if (PlayerPrefs.HasKey("PlayerLevel"))
        {
            level = PlayerPrefs.GetInt("PlayerLevel");
            health = PlayerPrefs.GetInt("PlayerHealth");
            mana = PlayerPrefs.GetInt("PlayerMana");
            
            float x = PlayerPrefs.GetFloat("PlayerPosX");
            float y = PlayerPrefs.GetFloat("PlayerPosY");
            float z = PlayerPrefs.GetFloat("PlayerPosZ");
            position = new Vector3(x, y, z);
            
            Debug.Log("Game loaded!");
            return true;
        }
        
        // Default values
        level = 1;
        health = 100;
        mana = 50;
        position = Vector3.zero;
        
        Debug.Log("No save data found!");
        return false;
    }
    
    /// <summary>
    /// Delete all save data
    /// </summary>
    public void DeleteSaveData()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Save data deleted!");
    }
}
